using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace game
{
    /// <summary>
    /// 
    /// </summary>
    public class SlotInit : MonoBehaviour
    {
        public BasicItem item;
        public int qttSlot;

        public Transform panelInfosVente;

        private ActivePanel reafficheInv;

        private void OnMouseDown()
        {
            //CreateAllSeedPlant.mainInventory.SubstractFromInventory(item, 1);
            //Debug.Log(item.getId());
            //Debug.Log(qttSlot);

            //check if item=seed, sinon pas possible de le planter
            //seed = 1 a 100
            if (panelInfosVente != null)
            {
                if (this.transform.parent.parent.name == "Shop")
                {
                    if (item.getId() is > 0 and < 101)
                    {
                        // Prix de la graine dans le slot.
                        int price = GameObject.Find("marketBase").GetComponent<Market>().getLastPriceSeed(((Seed)item).getTypePlante());
                        if (panelInfosVente.GetComponent<Game>().money >= price)
                        {
                            CreateAllSeedPlant.mainInventory.addToInventory(item, 1, CreateAllSeedPlant.mainInventory.getInventory());
                            panelInfosVente.GetComponent<Game>().SubsMoney(price);
                        }
                    }
                }
                else if (this.transform.parent.parent.name == "MarketInv")
                {
                    if (item.getId() is > 100 and <= 200)
                    {
                        panelInfosVente.GetComponent<SellScript>().changeMaxValue(qttSlot);
                        BasicPlant itemplante = (BasicPlant)item;
                        panelInfosVente.GetComponent<SellScript>().changePlant(itemplante.getTypePlante());
                        panelInfosVente.GetComponent<SellScript>().slider.interactable = true;
                    }
                }
                else if (panelInfosVente.name == "PanelPlot" && (item.getId() is > 0 and < 101))
                {
                    //panelInfosVente.GetComponent<GerePlant>().sendInfoClick(item, qttSlot);
                    panelInfosVente.GetComponent<GerePlant>().StockedPlot.planteGraine(item);
                    this.transform.root.GetComponentInChildren<OpenCanvas>().inverseAffichage();
                }


            }


        }

        public void af(ActivePanel[] deuxInvs, bool isStorage)
        {
            foreach (ActivePanel ap in deuxInvs)
            {
                /* if (isStorage)
                {
                    if (ap.panelAvecInfos.name == "PanelStorage")
                    {
                        ap.Affiche();
                    }
                }
                else
                {
                    if ((ap.panelAvecInfos.name == "PanelInvToStore"))
                    {
                        ap.Affiche();
                    }
                } */
                ap.Affiche();


            }
        }




    }
}