using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace game
{
    public class ActivePanel : MonoBehaviour
    {
        public GameObject PanelInventory;
        public GameObject PanelNotif;

        private InventoryPanel panel;
        // Start is called before the first frame update

        void Start()
        {
            // Récupère le préfab pour le GridBagLayout de l'inventaire
            GameObject gridBag = Instantiate(Resources.Load<GameObject>("Prefabs/InventoryGridLayout"));
            

            // Ajoute les slots avec les item de l'inventaire
            panel = new InventoryPanel(gridBag.transform);
            //panel.afficheInventory(CreateAllSeedPlant.mainInventory.getInventory());

            // Attache le gridbag au PanelInventaire
            gridBag.transform.SetParent(PanelInventory.transform);
            gridBag.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
            float x, y;
            x = gridBag.GetComponent<RectTransform>().sizeDelta.x;
            y = gridBag.GetComponent<RectTransform>().sizeDelta.y;
            gridBag.GetComponent<RectTransform>().sizeDelta = new Vector2(500, y);
            
            gridBag.transform.localPosition = gridBag.transform.localPosition + new Vector3Int(0, -20);
            //getWeightStatus();
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
                // Test maj de l'inventaire
                /*CreateAllSeedPlant.mainInventory.addToInventory(CreateAllSeedPlant.dicoPlant.createPlant(EnumTypePlant.ELB), 10);
                Debug.Log(CreateAllSeedPlant.mainInventory.ToString());*/
                panel.afficheInventory(CreateAllSeedPlant.mainInventory.getInventory());

                //gridBag.transform.localPosition = new Vector3Int(0, 50);
                //gridBag.


                PanelInventory.SetActive(true);
            }
            else
            {
                PanelInventory.SetActive(false);
            }
        }
    }
}
