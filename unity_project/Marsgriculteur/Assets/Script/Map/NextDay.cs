using game;
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
        public Transform plots;
        List<Transform> plotList; //contient tous les plots pour les faire pousser
        private int nbrJour;
        private Market market;
        //private AllEvents allEvents;

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

            market = new Market();
            market.createMarket();
            //dicoPossessions = market.getActiveEvents();

            AllEvents all = new AllEvents();

            dicoPossessions.Add(all.allEventDico["vegeTrend"], all.allEventDico["vegeTrend"].length);
            dicoPossessions.Add(all.allEventDico["qualiMeat"], all.allEventDico["qualiMeat"].length);
            dicoPossessions.Add(all.allEventDico["solarStorm"], all.allEventDico["solarStorm"].length);

            Debug.Log("dic" + dicoPossessions.Count);

        }

        public static Dictionary<EventInfo, int> getInventoryNotif()
        {
            return dicoPossessions;
        }

        void OnMouseDown()
        {
            faitPousser();
            nbrJour++;
            dayText.SetText(nbrJour.ToString());
        }

        public void faitPousser() //parcours chaque plot, puis appelle leur fonction fairePousser
        {
            foreach (Transform transforme in plotList)
            {
                if(transforme.name.Length>4 || transforme.name.Substring(0, 4) == "plot")
                {
                    try
                    {
                        transforme.gameObject.SendMessage("fairePousser");
                    }
                    catch
                    {
                        Debug.Log("Bug dans faire pousser, l'appel de la fonction de fairePousser avec \"" + transforme.name + "\" n'a pas marché");
                    }
                    
                }
                else
                {
                    Debug.Log("Bug dans faire pousser, le transform \"" + transforme.name + "\" est dans la liste des shops :/");
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
    }
}
