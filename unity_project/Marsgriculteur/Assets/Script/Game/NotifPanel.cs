using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;

namespace game
{
    public class NotifPanel : MonoBehaviour
    {
        public GameObject PanelInventory;
        public GameObject PanelNotif;
        public Notification notif;
        public Dictionary<EventInfo, int> dico = new Dictionary<EventInfo, int>();

        void Start()
        {
            PanelNotif.SetActive(false);

            dico = NextDay.getInventoryNotif();
            Debug.Log("dicooooooo : " + dico);
            notif.WakeUp(dico);
        }

        public void OpenPanel()
        {
            if (PanelNotif.activeSelf == false)
            {
                if (PanelInventory.activeSelf == true)
                {
                    PanelInventory.SetActive(false);
                }
                PanelNotif.SetActive(true);
            }
            else
            {
                PanelNotif.SetActive(false);
            }
        }
    }
}
