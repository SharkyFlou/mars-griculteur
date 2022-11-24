using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace game
{
    public class InventoryPanel : MonoBehaviour
    {
        public GameObject PanelInventory;
        public GameObject PanelNotif;
        
        public TextMeshProUGUI textWeight;



        void Start()
        {
            //getWeightStatus();

            PanelInventory.SetActive(false);
        }

        public void getWeightStatus(){
            //textWeight = Inventory.getCurrentWeight().ToString() + "/" + Inventory.getWeightMax().ToString();
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
