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
    /// <summary>
    /// La classe <c>NextDay</c> s'occupe de tout ce qui a à changer avant de passer au jour suivant.
    /// Elle possède les attributs suivant : dayText, notif, plots, plotList, nbrJour, market, dicoPossessions.
    /// </summary>
    public class NextDay : MonoBehaviour
    {
        public TextMeshProUGUI dayText;
        public Notification notif;
        public Transform plots;
        public Game game;
        List<Transform> plotList; //contient tous les plots pour les faire pousser
        private int nbrJour;
        [SerializeField] public Market market;

        public PopUp classePopup;
        public Transform renderer;

        //contient la liste des notifications avec leur durée d'apparition
        public static Dictionary<EventInfo, int> dicoPossessions = new Dictionary<EventInfo, int>();

        /// <summary>
        /// La méthode <c>Start</c> est utilisée pour le démarrage. Etant donné que Start n'est appelée qu'une seule fois, elle permet d'initialiser les éléments
        /// qui doivent persister tout au long de la vie du script, mais ne doivent être configurés qu'immédiatement avant utilisation.
        /// Pour notre cas elle permet de récupérer les champs pour pouvoir les faire pousser après et initialise le nombre de jour.
        /// </summary>
        void Start()
        {
            if (plots == null) //pour éviter de planter (ahah "plant")
            {
                return;
            }

            //parcours les plots pour les récupérer et les stocker afin de pouvoir les faire pousser
            GetPlots(plots);

            //pour l'affichage des jours
            nbrJour = 0;
            dayText.SetText(nbrJour.ToString());
        }

        /// <summary>
        /// La méthode <c>getInventoryNotif</c> permet d'obtenir toutes les notifications.
        /// </summary>
        /// <returns>Elle retourne un dictionnaire de notifications avec la durée pour laquelle elles restent</returns>
        public static Dictionary<EventInfo, int> getInventoryNotif()
        {
            return dicoPossessions;
        }

        /// <summary>
        /// La méthode <c>OnMouseDown</c> permet lorsqu'on clique de passer au jour suivant
        /// </summary>
        void OnMouseDown()
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }
            game.testObjective();
            //on fait pousser les plantes
            faitPousser();

            EventDay(nbrJour);

            nbrJour++;
            dayText.SetText(nbrJour.ToString());

            StartCoroutine(classePopup.message("Vous êtes passé au jour suivant!\nRegardez s'il y a un nouvel événement!"));
        }

        /// <summary>
        /// La méthode <c>faitPousser</c> parcourt chaque champs, puis appelle leur fonction fairePousser
        /// </summary>
        public void faitPousser()
        {
            foreach (Transform transforme in plotList)
            {
                if (transforme.name.Length > 4 && transforme.name.Substring(0, 4) == "plot")
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

        /// <summary>
        /// La méthode <c>GetPlots</c> permet de récupérer les champs.
        /// </summary>
        /// <param name="parent">là où se trouve les champs</param>
        private void GetPlots(Transform parent)
        {
            plotList = new List<Transform>();
            foreach (Transform child in parent)
            {
                plotList.Add(child);
            }
            return;
        }

        /// <summary>
        /// La méthode <c>addToInventory</c> permet d'ajouter un événement au dictionnaire
        /// </summary>
        /// <param name="item">l'événement</param>
        /// <param name="duree">la durée de l'événement</param>
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

        /// <summary>
        /// La méthode <c>removeFromInventory</c> permet de supprimer un item instantanément
        /// </summary>
        /// <param name="item">l'item à supprimer</param>
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

        /// <summary>
        /// La méthode <c>EventDay</c> permet d'afficher les événements actuels, de décrémenter leur durée et de les suppimer s'ils arrivent à la fin.
        /// </summary>
        /// <param name="nbrJour"></param>
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
                renderer.gameObject.SetActive(true);
            }

            dicoPossessions = Market.instance.getActiveEvents();
            notif.afficheInventory();


            //Une liste pour retenir tous les events qui arrivent à la fin
            List<EventInfo> item = new List<EventInfo>();

            //Debug.Log("Nombre d'event : "+ dicoPossessions.Count);
            //parcours du dico des notifs pour voir si les events arrivent à la fin
            for (int i = 0; i < dicoPossessions.Count; i++)
            {
                EventInfo itemOfSlot = dicoPossessions.ElementAt(i).Key;
                int duree = dicoPossessions.ElementAt(i).Value;

                //Debug.Log("Name = " + itemOfSlot.getName() + "Value = " + duree);
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

        public int getNbJour()
        {
            return nbrJour;
        }
        
    }
}
