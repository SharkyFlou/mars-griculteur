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
            notif.afficheInventory();
        }

        public void OpenPanel()
        {
            if(!PanelInventory.activeSelf)
                PanelNotif.SetActive(!PanelNotif.activeSelf);
        }
    }
}
