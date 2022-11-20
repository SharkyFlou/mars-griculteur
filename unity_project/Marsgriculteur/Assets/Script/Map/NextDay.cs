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
        private Dictionary<EventInfo, int> activeEvents = new Dictionary<EventInfo, int>();
        private EventInfo newEvent;
        public Transform PanelNotif;
        public GameObject PrefabNotifButton;


        public TextMeshProUGUI NameText;
        public TextMeshProUGUI DescText;
        public TextMeshProUGUI PlantText;
        public TextMeshProUGUI SeedText;
        public TextMeshProUGUI ToolText;

        void Awake()
        {
            NameText.SetText("nom");
            DescText.SetText("description");
            PlantText.SetText("listePlant");
            SeedText.SetText("listeSeed");
            ToolText.SetText("listeTool");
            Instantiate(PrefabNotifButton, PanelNotif);
        }

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
        }

        void OnMouseDown()
        {
            faitPousser();
            nbrJour++;
            dayText.SetText(nbrJour.ToString());

            List<EventInfo> events = new List<EventInfo>();

            foreach (KeyValuePair<EventInfo, int> ev in activeEvents)
            {
                events.Add(ev.Key);
            }

            foreach (EventInfo ev in events)
            {
                activeEvents[ev] -= 1;

                if (activeEvents[ev] == 0)
                {
                    //suppr notif
                }
            }
        }

        public void faitPousser() //parcours chaque plot, puis appelle leur fonction fairePousser
        {
            foreach (Transform transform in plotList)
            {
                if(transform.name.Length>4 || transform.name.Substring(0, 4) == "plot")
                {
                    try
                    {
                        transform.gameObject.SendMessage("fairePousser");
                    }
                    catch
                    {
                        Debug.Log("Bug dans faire pousser, l'appel de la fonction de fairePousser avec \"" + transform.name + "\" n'a pas marché");
                    }
                    
                }
                else
                {
                    Debug.Log("Bug dans faire pousser, le transform \"" + transform.name + "\" est dans la liste des shops :/");
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

        public void AddNotif(string nom, string description, string listePlant, string listeSeed, string listeTool)
        {
            NameText.SetText(nom);
            DescText.SetText(description);
            PlantText.SetText(listePlant);
            SeedText.SetText(listeSeed);
            ToolText.SetText(listeTool);
            Instantiate(PrefabNotifButton, PanelNotif);
        }
    }
}
