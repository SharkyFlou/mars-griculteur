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

        public Transform panelAvecInfos;

        void Start()
        {
            OuvrePanel();
        }

        public void OuvrePanel()
        {
            clearInventoryDisplay();


            // R�cup�re le pr�fab pour le GridBagLayout de l'inventaire
            GameObject gridBag = Instantiate(Resources.Load<GameObject>("Prefabs/InventoryGridLayout"));

            // Ajoute les slots avec les item de l'inventaire
            panel = new InventoryPanel(gridBag.transform);

            //Debug.Log("Transform panelAvecInfos = " + panelAvecInfos.name);
            Affiche();

            //definit les parents de l'inventory cree
            //#########################################@//#########################################@//#########################################@
            //c'est ici qu'on change les tailles de chaque inventory


            //panel inventory normal, quand on clique sur le backpack
            if (this.name == "PanelInventory")
            {
                //Debug.Log("on entre dans la boucle normale");
                gridBag.transform.SetParent(PanelInventory.transform);
                gridBag.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                gridBag.transform.localPosition = gridBag.transform.localPosition + new Vector3Int(0, -20);
            }
            //panel lorsqu'on essaye de planter un truc
            else if (this.name == "PanelInv")
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
                gridBag.transform.localScale = new Vector3(1.6f, 1.0f, 0f);

                // Encadre bien dans le parent et le met pas trop loin de la caméra (évitr qu'il disparaisse au dézoom)
                gridBag.transform.GetComponent<RectTransform>().sizeDelta = new Vector3(0, 0, 0);

                // Met la position z à 0 pour pas qu'il sort du render de la caméra au dézoom
                gridBag.transform.localPosition = new Vector3(0, 0, 0);

                // Magouille pour que l'inventaire soit pas n'importe où (change valeur left et right en fonction de la largeur du parent)
                gridBag.transform.GetComponent<RectTransform>().offsetMin = new Vector2(gridBag.transform.parent.GetComponent<RectTransform>().rect.width / 4, gridBag.transform.GetComponent<RectTransform>().offsetMin.y);
                gridBag.transform.GetComponent<RectTransform>().offsetMax = new Vector2(-gridBag.transform.parent.GetComponent<RectTransform>().rect.width / 4, gridBag.transform.GetComponent<RectTransform>().offsetMax.y);

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

                // Met la position z à 0 pour pas qu'il sort du render de la caméra au dézoom
                gridBag.transform.localPosition = new Vector3(0, 0, 0);

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

                Affiche();
                PanelInventory.SetActive(true);
            }
            else
            {
                PanelInventory.SetActive(false);
            }
        }

        // Update affichage d'un inventaire
        public void Affiche()
        {
            if (panelAvecInfos == null)
            {
                Debug.Log("la boucle est nulle");
                panel.afficheInventory(CreateAllSeedPlant.mainInventory.getInventory());
            }
            else if (panel != null)
            {
                //OUBLIER PAS LES RETURNS
                if (PanelInventory.name == "Shop")
                {
                    //Debug.Log("on rentre dans l'inventory shop, no problem");
                    panel.afficheInventory(CreateAllSeedPlant.shopInv.getInventory(), panelAvecInfos);
                    return;
                }


                else if (panelAvecInfos.name == "PanelInvToStore" || panelAvecInfos.name == "PanelInventory")
                {
                    Debug.Log("On rentre dans l'inventory du joueur, pour stocker");
                    panel.afficheInventory(CreateAllSeedPlant.mainInventory.getInventory(), panelAvecInfos);
                    return;
                }
                else if (panelAvecInfos.name == "PanelPlot")
                {
                    //false == ajout que des graines
                    panel.afficheInventory(CreateAllSeedPlant.mainInventory.getInventory(), panelAvecInfos, false);
                    return;
                }
                else if (panelAvecInfos.name == "SliderContainter")
                {
                    //true == ajout que des plantes pour la vente
                    Debug.Log("main inventory #### = " + CreateAllSeedPlant.mainInventory.getInventory().Count);
                    Debug.Log("panelAvecInfos #### = " + panelAvecInfos.name);
                    //Debug.Log(panel.name);
                    panel.affiche();

                    panel.afficheInventory(CreateAllSeedPlant.mainInventory.getInventory(), panelAvecInfos, true);
                    return;
                }

                Debug.Log("la boucle est vraie");
                panel.afficheInventory(CreateAllSeedPlant.mainInventory.getInventory(), panelAvecInfos);

            }
        }

        public void clearInventoryDisplay()
        {
            foreach (Transform child in PanelInventory.GetComponentsInChildren<Transform>())
            {
                if (child.name == "InventoryGridLayout(Clone)")
                    GameObject.Destroy(child.gameObject);
            }
        }


        //public void Affiche(Transform panelAvecInfos)
        //{
        //    panel.afficheInventory(CreateAllSeedPlant.mainInventory.getInventory(), panelAvecInfos);
        //}
    }
}
