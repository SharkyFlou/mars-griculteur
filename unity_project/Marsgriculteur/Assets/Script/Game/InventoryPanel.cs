using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace game
{
    public class InventoryPanel : MonoBehaviour
    {
        public GameObject PanelInventory;
        public GameObject PanelNotif;

        void Start()
        {
            PanelInventory.SetActive(false);
        }

        public void OpenPanel()
        {
            if (PanelInventory.activeSelf == false)
            {
                if (PanelNotif.activeSelf == true)
                {
                    PanelNotif.SetActive(false);
                }
                PanelInventory.SetActive(true);
            }
            else
            {
                PanelInventory.SetActive(false);
            }
        }
    }
}
