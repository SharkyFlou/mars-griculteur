using System.Collections;
using System.Collections.Generic;
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

            // R�cup�re le pr�fab pour le GridBagLayout de l'inventaire
            GameObject gridBag = Instantiate(Resources.Load<GameObject>("Prefabs/InventoryGridLayout"));

            // Ajoute les slots avec les item de l'inventaire
            panel = new InventoryPanel(gridBag.transform);
            panel.afficheInventory(CreateAllSeedPlant.mainInventory.getInventory());

            //definit les parents de l'inventory cree
            //#########################################@//#########################################@//#########################################@
            //c'est ici qu'on change les tailles de chaque inventory


            //panel inventory normal, quand on clique sur le backpack
            if (this.name == "PanelInventory")
            {




                //Debug.Log("on entre dans la boucle normale");
                gridBag.transform.SetParent(PanelInventory.transform);
                gridBag.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
                gridBag.transform.localPosition = gridBag.transform.localPosition + new Vector3Int(0, -20);
            }
            //panel lorsqu'on essaye de planter un truc
            else if (this.name == "PanelPlotInv")
            {
                //Debug.Log("on entre dans la boucle");
                Transform PanelPourPlanterEtInv = this.transform.Find("PanelInv");
                gridBag.transform.SetParent(PanelPourPlanterEtInv);
                gridBag.transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);


                gridBag.GetComponent<RectTransform>().sizeDelta =
                    new Vector2(PanelPourPlanterEtInv.GetComponent<RectTransform>().rect.width,
                    PanelPourPlanterEtInv.GetComponent<RectTransform>().rect.height);


                //Debug.Log("##### nom panel : " + PanelPourPlanterEtInv.name);


                //on prend le 80% du parent
                //RectTransform gridRectT = gridBag.GetComponent<RectTransform>();                    //fils
                //RectTransform parentRectT = (PanelPourPlanterEtInv as RectTransform);               //parent

                //gridRectT.sizeDelta = new Vector2(parentRectT.rect.width * 0.8f, parentRectT.rect.height * 0.8f);

                //gridBag.transform.localScale = new Vector3(1f, 1f, 1f);


                /*

                gridRectT.localPosition = new Vector2(parentRectT.anchoredPosition.x - gridRectT.sizeDelta.x / 2, parentRectT.anchoredPosition.y);
                */



                //getWeightStatus();
                PanelInventory.SetActive(false);
            }
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
                PanelInventory.SetActive(true);
            }
            else
            {
                PanelInventory.SetActive(false);
            }
        }
    }
}
