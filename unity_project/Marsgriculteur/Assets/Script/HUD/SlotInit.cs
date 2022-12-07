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

        private void OnMouseDown()
        {
            //CreateAllSeedPlant.mainInventory.SubstractFromInventory(item, 1);
            //Debug.Log(item.getId());
            //Debug.Log(qttSlot);

            //check if item=seed, sinon pas possible de le planter
            //seed = 1 a 100
            if (this.transform.parent.parent.name == "PanelShop")
            {
                if (item.getId() > 0 && item.getId() < 101)
                    if (panelInfosVente.GetComponent<Game>().money >= item.getPrice())
                    {
                        CreateAllSeedPlant.mainInventory.addToInventory(item, 10);
                        panelInfosVente.GetComponent<Game>().SubsMoney(item.getPrice());
                        this.transform.parent.parent.GetComponent<ActivePanel>().Affiche(panelInfosVente);
                    }
                //Debug.Log("Tu es bien dans le shop connard !");
            }
            else if (this.transform.parent.parent.name == "PanelRight")
            {
                if (item.getId() > 100 && item.getId() <= 200)
                {
                    panelInfosVente.GetComponent<sellScript>().changeMaxValue(qttSlot);
                    BasicPlant itemplante = (BasicPlant) item;
                    panelInfosVente.GetComponent<sellScript>().changePlant(itemplante.getTypePlante());
                    panelInfosVente.GetComponent<sellScript>().slider.interactable = true;
                }
            }
            else if (item.getId() > 0 && item.getId() < 101)
            {
                panelInfosVente.GetComponent<GerePlant>().sendInfoClick(item, qttSlot);
            }
            else
                Debug.Log("pas une seed");
        }

       


    }
}