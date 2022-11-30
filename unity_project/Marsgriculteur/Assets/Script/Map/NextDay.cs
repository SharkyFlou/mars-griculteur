using game;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace game
{
    public class NextDay : MonoBehaviour
    {
        public TextMeshProUGUI dayText;
        public Notification notif;
        public Transform plots;
        List<Transform> plotList; //contient tous les plots pour les faire pousser
        private int nbrJour;
        //private AllEvents allEvents;
        [SerializeField] public Market market;

        public static Dictionary<EventInfo, int> dicoPossessions = new Dictionary<EventInfo, int>();

        void Start()
        {
            if (plots == null) //pour éviter de planter (ahah "plant")
            {
                return;
            }


            GetPlots(plots);
            nbrJour = 0;
            dayText.SetText(nbrJour.ToString());

            //Market.instance.afficheEtatDebug();

            EventInfo evt = Market.instance.nextDay(nbrJour, true);
            if (evt == null)
            {
                Debug.Log("Jour " + nbrJour + " : Pas d'event");
            }
            else
            {
                Debug.Log("Jour " + nbrJour + " Nouveau evt : " + evt.namee);
            }

            AllEvents all = new AllEvents();
            //Debug.Log("Aaah : " + evt.getName());
            if (evt != null)
            {
                //dicoPossessions.Add(evt, evt.getLength());
                addToInventory(evt, evt.getLength());
            }

            List<EventInfo> item = new List<EventInfo>();

            foreach (EventInfo et in dicoPossessions.Keys)
            {
                if (et.getLength() == 0)
                {
                    item.Add(et);
                }
            }

            foreach (EventInfo et in item)
            {
                removeFromInventory(et);
            }

            /*dicoPossessions.Add(all.allEventDico["vegeTrend"], all.allEventDico["vegeTrend"].length);
            dicoPossessions.Add(all.allEventDico["qualiMeat"], all.allEventDico["qualiMeat"].length);
            dicoPossessions.Add(all.allEventDico["solarStorm"], all.allEventDico["solarStorm"].length);*/

            Debug.Log("dic" + dicoPossessions.Count);

            //notif.afficheInventory();

        }

        public static Dictionary<EventInfo, int> getInventoryNotif()
        {
            return dicoPossessions;
        }

        void OnMouseDown()
        {
            faitPousser();
            EventInfo evt = Market.instance.nextDay(nbrJour, true);
            if (evt == null)
            {
                Debug.Log("Jour "+nbrJour+ " : Pas d'event");
            }
            else
            {
                Debug.Log("Jour " + nbrJour + " Nouveau evt : " + evt.namee);
            }

            AllEvents all = new AllEvents();
            //Debug.Log("Aaah : " + evt.getName());
            if(evt != null)
            {
                //dicoPossessions.Add(evt, evt.getLength());
                addToInventory(evt, evt.getLength());
            }

            List<EventInfo> item = new List<EventInfo>();

            foreach( EventInfo et in dicoPossessions.Keys)
            {
                if(et.getLength() == 0)
                {
                    item.Add(et);
                }
            }

            foreach(EventInfo et in item)
            {
                removeFromInventory(et);
            }
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
    }
}
