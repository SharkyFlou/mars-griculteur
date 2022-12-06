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
                CreateAllSeedPlant.mainInventory.addToInventory(item, 10);
                this.transform.parent.parent.GetComponent<ActivePanel>().Affiche();
                Debug.Log("Tu es bien dans le shop connard !");
            }
            else if (item.getId() > 0 && item.getId() < 101)
                panelInfosVente.GetComponent<GerePlant>().sendInfoClick(item, qttSlot);
            else
                Debug.Log("pas une seed");
        }

       


    }
}