using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace game
{
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
                    if (item.getId() > 0 && item.getId() < 101)
                        if (panelInfosVente.GetComponent<Game>().money >= item.getPrice())
                        {
                            CreateAllSeedPlant.mainInventory.addToInventory(item, 1, CreateAllSeedPlant.mainInventory.getInventory());
                            panelInfosVente.GetComponent<Game>().SubsMoney(item.getPrice());
                        }
                }
                else if (this.transform.parent.parent.name == "MarketInv")
                {
                    if (item.getId() > 100 && item.getId() <= 200)
                    {
                        panelInfosVente.GetComponent<sellScript>().changeMaxValue(qttSlot);
                        BasicPlant itemplante = (BasicPlant)item;
                        panelInfosVente.GetComponent<sellScript>().changePlant(itemplante.getTypePlante());
                        panelInfosVente.GetComponent<sellScript>().slider.interactable = true;
                    }
                }
                else if (panelInfosVente.name == "PanelPlot" && (item.getId() > 0 && item.getId() < 101))
                {
                    panelInfosVente.GetComponent<GerePlant>().sendInfoClick(item, qttSlot);
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