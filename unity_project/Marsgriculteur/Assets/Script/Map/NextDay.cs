using game;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

namespace game
{
    public class NextDay : MonoBehaviour
    {
        public TextMeshProUGUI dayText;
        public Notification notif;
        public Transform plots;
        List<Transform> plotList; //contient tous les plots pour les faire pousser
        private int nbrJour;
        [SerializeField] public Market market;

        //contient la liste des notifications avec leur durée d'apparition
        public static Dictionary<EventInfo, int> dicoPossessions = new Dictionary<EventInfo, int>();

        void Start()
        {
            if (plots == null) //pour éviter de planter (ahah "plant")
            {
                return;
            }


            GetPlots(plots);

            //pour l'affichage des jours
            nbrJour = 0;
            dayText.SetText(nbrJour.ToString());

            EventDay(nbrJour);
            
        }


        //avoir le dico des notifs
        public static Dictionary<EventInfo, int> getInventoryNotif()
        {
            return dicoPossessions;
        }

        //lorsqu'on clique pour passer au jour suivant
        void OnMouseDown()
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }

            //on fait pousser les plantes
            faitPousser();

            EventDay(nbrJour);

            nbrJour++;
            dayText.SetText(nbrJour.ToString());
        }

        public void faitPousser() //parcours chaque plot, puis appelle leur fonction fairePousser
        {
            foreach (Transform transforme in plotList)
            {
                if(transforme.name.Length>4 && transforme.name.Substring(0, 4) == "plot")
                {
                    try
                    {
                        transforme.gameObject.SendMessage("fairePousser");
                    }
                    catch //THIS NEVER RUNS
                    {
                        //Debug.Log("Bug dans faire pousser, l'appel de la fonction de fairePousser avec \"" + transforme.name + "\" n'a pas marché");
                    }
                }
                else
                {
                    Debug.Log("Bug dans faire pousser, le transform \"" + transforme.name + "\" est dans la liste des plots :/'");
                }
            }
        }


        private void GetPlots(Transform parent) //recupere les plots
        {
            plotList = new List<Transform>();
            foreach (Transform child in parent)
            {
                plotList.Add(child);
            }
            return;
        }


        //permet d'ajouter un slot au dictionnaire
        public void addToInventory(EventInfo item, int duree)
        {
            bool trouve = false;

            if (duree < 1)
                return;
            else
            {
                //on parcourt chaque key pour acceder a son getName()
                foreach (EventInfo kvp in dicoPossessions.Keys)
                {
                    if (kvp.getName() == item.getName())
                    {
                        dicoPossessions[kvp] += duree;
                        trouve = true;
                        break;
                    }
                }
                //si on le trouve pas on l'ajoute a notre 
                if (!trouve)
                {
                    dicoPossessions.Add(item, duree);
                }
            }

            notif.afficheInventory();

        }

        //removes an item instantly
        public void removeFromInventory(EventInfo item)
        {
            foreach (EventInfo kvp in dicoPossessions.Keys)
            {
                if (kvp.getName() == item.getName())
                {
                    dicoPossessions.Remove(kvp);
                    break;
                }
            }

            notif.afficheInventory();
        }

        public void EventDay(int nbrJour)
        {
            //debug pour voir les events du premier jour (jour 0)
            EventInfo evt = Market.instance.nextDay(nbrJour, true);
            if (evt == null)
            {
                Debug.Log("Jour " + nbrJour + " : Pas d'event");
            }
            else
            {
                Debug.Log("Jour " + nbrJour + " Nouveau evt : " + evt.namee);
            }


            AllEvents all =  new AllEvents();

            //ajoute l'event à la liste
            if (evt != null)
            {
                addToInventory(evt, evt.getLength());
            }

            //Une liste pour retenir tous les events qui arrivent à la fin
            List<EventInfo> item = new List<EventInfo>();

            //parcours du dico des notifs pour voir si les events arrivent à la fin
            for (int i = 0; i < dicoPossessions.Count; i++)
            {
                EventInfo itemOfSlot = dicoPossessions.ElementAt(i).Key;
                int duree = dicoPossessions.ElementAt(i).Value;

                Debug.Log("Name = " + itemOfSlot.getName() + "Value = " + duree);
                dicoPossessions[dicoPossessions.ElementAt(i).Key] --;

                duree = dicoPossessions.ElementAt(i).Value;

                if (duree == -1)
                {
                    item.Add(itemOfSlot);
                }
            }

            //supprime les events du dico et donc de l'affichage
            foreach (EventInfo et in item)
            {
                removeFromInventory(et);
            }
        }
    }
}
