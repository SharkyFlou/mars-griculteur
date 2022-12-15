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
    /// La classe <c>NextDay</c> s'occupe de tout ce qui a � changer avant de passer au jour suivant.
    /// Elle poss�de les attributs suivant : dayText, notif, plots, plotList, nbrJour, market, dicoPossessions.
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
        public Transform render;

        //contient la liste des notifications avec leur dur�e d'apparition
        public static Dictionary<EventInfo, int> dicoPossessions = new Dictionary<EventInfo, int>();

        /// <summary>
        /// La m�thode <c>Start</c> est utilis�e pour le d�marrage. Etant donn� que Start n'est appel�e qu'une seule fois, elle permet d'initialiser les �l�ments
        /// qui doivent persister tout au long de la vie du script, mais ne doivent �tre configur�s qu'imm�diatement avant utilisation.
        /// Pour notre cas elle permet de r�cup�rer les champs pour pouvoir les faire pousser apr�s et initialise le nombre de jour.
        /// </summary>
        void Start()
        {
            if (plots == null) //pour �viter de planter (ahah "plant")
            {
                return;
            }

            //parcours les plots pour les r�cup�rer et les stocker afin de pouvoir les faire pousser
            GetPlots(plots);

            //pour l'affichage des jours
            nbrJour = 0;
            dayText.SetText(nbrJour.ToString());
        }

        /// <summary>
        /// La m�thode <c>getInventoryNotif</c> permet d'obtenir toutes les notifications.
        /// </summary>
        /// <returns>Elle retourne un dictionnaire de notifications avec la dur�e pour laquelle elles restent</returns>
        public static Dictionary<EventInfo, int> getInventoryNotif()
        {
            return dicoPossessions;
        }

        /// <summary>
        /// La m�thode <c>OnMouseDown</c> permet lorsqu'on clique de passer au jour suivant
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

            classePopup.message("Vous êtes passé au jour suivant!\nRegardez s'il y a un nouvel événement!");
            //StartCoroutine(classePopup.message("Vous êtes passé au jour suivant!\nRegardez s'il y a un nouvel événement!"));
        }

        /// <summary>
        /// La m�thode <c>faitPousser</c> parcourt chaque champs, puis appelle leur fonction fairePousser
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
                        //Debug.Log("Bug dans faire pousser, l'appel de la fonction de fairePousser avec \"" + transforme.name + "\" n'a pas march�");
                    }
                }
                else
                {
                    Debug.Log("Bug dans faire pousser, le transform \"" + transforme.name + "\" est dans la liste des plots :/'");
                }
            }
        }

        /// <summary>
        /// La m�thode <c>GetPlots</c> permet de r�cup�rer les champs.
        /// </summary>
        /// <param name="parent">l� o� se trouve les champs</param>
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
        /// La m�thode <c>addToInventory</c> permet d'ajouter un �v�nement au dictionnaire
        /// </summary>
        /// <param name="item">l'�v�nement</param>
        /// <param name="duree">la dur�e de l'�v�nement</param>
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
        /// La m�thode <c>removeFromInventory</c> permet de supprimer un item instantan�ment
        /// </summary>
        /// <param name="item">l'item � supprimer</param>
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
        /// La m�thode <c>EventDay</c> permet d'afficher les �v�nements actuels, de d�cr�menter leur dur�e et de les suppimer s'ils arrivent � la fin.
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
                render.gameObject.SetActive(true);
            }

            dicoPossessions = Market.instance.getActiveEvents();
            notif.afficheInventory();


            //Une liste pour retenir tous les events qui arrivent � la fin
            List<EventInfo> item = new List<EventInfo>();

            //Debug.Log("Nombre d'event : "+ dicoPossessions.Count);
            //parcours du dico des notifs pour voir si les events arrivent � la fin
            for (int i = 0; i < dicoPossessions.Count; i++)
            {
                EventInfo itemOfSlot = dicoPossessions.ElementAt(i).Key;
                int duree = dicoPossessions.ElementAt(i).Value;

                //Debug.Log("Name = " + itemOfSlot.getName() + "Value = " + duree);
                dicoPossessions[dicoPossessions.ElementAt(i).Key]--;

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
