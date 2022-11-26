using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;


namespace game
{
    public class Inventory : MonoBehaviour
    {
        private int weightMax = 1000;
        //permet de prendre le Dictionary inventory du player
        public PlayerInventory playerInventory;

        //correspond au slot a initialiser
        public GameObject SlotImage;
        //correspond au panel parent
        public Transform slotPanel;

        //dictionnaire des items pour remplir le inventory
        //si on ajoute un item on doit ajouter à ce dico pour le afficher
        public Dictionary<BasicItem, int> slots = new Dictionary<BasicItem, int>();

        public int currentWeight;



        //retourne le maxWeight de l'inventory
        public int getWeightMax()
        {
            return this.weightMax;
        }

        public int getCurrentWeight()
        {
            return this.currentWeight;
        }

        public void clearInventoryDisplay()
        {
            foreach (Transform child in slotPanel)
                /* slotPanel.DetachChildren(child);*/
                Destroy(child.gameObject);

            //slotPanel.DetachChildren();
            //Destroy();
        }

        //pour tout element on instancie son slot (qui aura une image etc etc) et on l'ajoute

        public void afficheInventory(Dictionary<BasicItem, int> dico)
        {
            clearInventoryDisplay();
            currentWeight = 0;
            slots = dico;

            for (int i = 0; i < slots.Count; i++)
            {

                Debug.Log("LE DICTIONNAIRE EST: \n");
                foreach (KeyValuePair<BasicItem, int> kvp in slots)
                {
                    Debug.Log("item : " + kvp.Key.getName() + ", qtt : " + kvp.Value);
                }


                //on cree l'objet prefab slot
                GameObject slot = (GameObject)Instantiate(SlotImage);

                //MOMENT DE REMPLIR LE SLOT
                //on prend la key/value du dico a la pos i ##########################
                BasicItem itemOfSlot = slots.ElementAt(i).Key;
                int qttDuSlot = slots.ElementAt(i).Value;


                //ceci affiche tous les weights de inventory
                currentWeight += itemOfSlot.getWeight() * qttDuSlot;

                //pour remplir les infos a l'interieur du slot
                //IL FAUT FAIRE GET COMPONENTS ET PARCOURIR TAB, PARENT[0] FAIRE GAFFE
                Image[] imgDuSlot = slot.GetComponentsInChildren<Image>();
                foreach (Image imgS in imgDuSlot)
                {
                    if (imgS.gameObject.transform.parent != null)
                    {
                        imgS.sprite = itemOfSlot.getImageLink();
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
                slot.transform.localScale = new Vector3(1 / slotPanel.localScale.x, 1 / slotPanel.localScale.y, 0);

            }
        }
    }
}