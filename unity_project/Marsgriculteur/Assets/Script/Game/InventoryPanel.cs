using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using UnityEngine.UI;

namespace game
{
    public class InventoryPanel : InventoryInterface
    {
        public Transform slotPanel;

        //public TextMeshProUGUI textWeight;
        public InventoryPanel(Transform slotPanel)
        {
            this.slotPanel = slotPanel;
        }

        public void afficheInventory(Dictionary<BasicItem, int> dico)
        {
            clearInventoryDisplay();
            int currentWeight = 0;
            //slots = dico;

            for (int i = 0; i < dico.Count; i++)
            {

                /*Debug.Log("LE DICTIONNAIRE EST: \n");
                foreach(KeyValuePair<BasicItem,int> kvp in slots){
                    Debug.Log("item : "+kvp.Key.getName()+", qtt : "+kvp.Value);
                }  
                */
                //on cree l'objet prefab slot
                GameObject slot = InventorySlot.createSlot();

                //MOMENT DE REMPLIR LE SLOT
                //on prend la key/value du dico a la pos i ##########################
                BasicItem itemOfSlot = dico.ElementAt(i).Key;
                int qttDuSlot = dico.ElementAt(i).Value;


                //ceci affiche tous les weights de inventory
                currentWeight += itemOfSlot.getWeight() * qttDuSlot;

                //pour remplir les infos a l'interieur du slot
                //IL FAUT FAIRE GET COMPONENTS ET PARCOURIR TAB, PARENT[0] FAIRE GAFFE
                Image[] imgDuSlot = slot.GetComponentsInChildren<Image>();
                foreach (Image imgS in imgDuSlot)
                {
                    if (imgS.gameObject.transform.parent != null)
                    {
                        imgS.sprite = itemOfSlot.getSprite();
                        imgS.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                    }
                }

                TextMeshProUGUI[] qtt = slot.GetComponentsInChildren<TextMeshProUGUI>();
                foreach (TextMeshProUGUI text in qtt)
                {
                    if (text.gameObject.transform.parent != null)
                    {
                        text.SetText(qttDuSlot.ToString());
                    }
                }

                //on dit que son parent est le Grid Layout Group PANEL INVENTORY
                slot.transform.SetParent(slotPanel);


                //CHANGER LA TAILLE APRES DAVOIR AJOUTE AU PARENT !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                slot.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            }
        }
        
        public void clearInventoryDisplay()
        {
            foreach (Transform child in slotPanel)
            {
                GameObject.Destroy(child.gameObject);
            }
        }

    }
}
