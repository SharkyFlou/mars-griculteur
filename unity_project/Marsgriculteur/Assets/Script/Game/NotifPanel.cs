using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace game
{
    public class NotifPanel : MonoBehaviour
    {
        public GameObject PanelInventory;
        public GameObject PanelNotif;

        void Start()
        {
            PanelNotif.SetActive(false);
        }

        public void OpenPanel()
        {
            if(!PanelInventory.activeSelf)
                PanelNotif.SetActive(!PanelNotif.activeSelf);
            /*if (PanelNotif.activeSelf == false)
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
            }*/
        }
    }
}
