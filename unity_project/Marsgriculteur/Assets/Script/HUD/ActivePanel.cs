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
        public Transform panelAvecInfos;

        void Start()
        {
            // R�cup�re le pr�fab pour le GridBagLayout de l'inventaire
            GameObject gridBag = Instantiate(Resources.Load<GameObject>("Prefabs/InventoryGridLayout"));

            // Ajoute les slots avec les item de l'inventaire
            panel = new InventoryPanel(gridBag.transform);
            if (panelAvecInfos != null)
                Affiche(panelAvecInfos);
            else
                Affiche();

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
            else if (this.name == "PanelInv")
            {

                //Debug.Log("on entre dans la boucle");
                //Transform PanelPourPlanterEtInv = this.transform.Find("PanelInv");
                gridBag.transform.SetParent(PanelInventory.transform);
                gridBag.transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);

                float y;
                y = gridBag.GetComponent<RectTransform>().sizeDelta.y;
                gridBag.GetComponent<RectTransform>().sizeDelta = new Vector2(300, y);
                gridBag.transform.localPosition = new Vector2(0, 0);


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
                //PanelInventory.SetActive(false);
            }
            else
            {
                // Devient enfant du PanelInventory
                gridBag.transform.SetParent(PanelInventory.transform);

                // Points d'accroches en haut à gauche et en haut à droite pour remplir la totalité de la taille du parent
                gridBag.transform.GetComponent<RectTransform>().anchorMin = new Vector2(0, 0);
                gridBag.transform.GetComponent<RectTransform>().anchorMax = new Vector2(1, 1);
                gridBag.transform.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);

                // Place le point d'accroche au mileu.
                gridBag.transform.GetComponent<RectTransform>().anchoredPosition = gridBag.transform.parent.GetComponent<RectTransform>().position;

                // Met la scale a celle de base pour que les slots ont la bonne taille
                gridBag.transform.localScale = new Vector3(1, 1, 1);

                // Encadre bien dans le parent et le met pas trop loin de la caméra (évitr qu'il disparaisse au dézoom)
                gridBag.transform.GetComponent<RectTransform>().sizeDelta = new Vector3(0, 0, 0);

            }
            else if(this.name == "PanelRight")
            {
                gridBag.transform.SetParent(PanelInventory.transform);
                gridBag.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
                gridBag.transform.localPosition = gridBag.transform.localPosition + new Vector3Int(2200, -10);
                /*gridBag.transform.GetComponent<RectTransform>().anchorMin = new Vector2(1, 0);
                gridBag.transform.GetComponent<RectTransform>().anchorMax = new Vector2(0, 2);
                gridBag.transform.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);*/
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
                Affiche();
                PanelInventory.SetActive(true);
            }
            else
            {
                PanelInventory.SetActive(false);
            }
        }

        //deux fonctions qui permettent d'afficher de deux façons differentes le meme inventory
        public void Affiche()
        {
            Debug.Log("J'affiche !!!!");
            panel.afficheInventory(CreateAllSeedPlant.mainInventory.getInventory());

        }



        public void Affiche(Transform panelAvecInfos)
        {
            panel.afficheInventory(CreateAllSeedPlant.mainInventory.getInventory(), panelAvecInfos);
        }
    }
}
