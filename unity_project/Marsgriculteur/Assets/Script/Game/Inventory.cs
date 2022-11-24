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
        private int weightMax=1000;
        //permet de prendre le Dictionary inventory du player
        public PlayerInventory playerInventory;

        public Shop shop;

        //correspond au slot a initialiser
        public GameObject SlotImage;
        //correspond au panel parent
        public Transform slotPanel;

        //dictionnaire des items pour remplir le inventory
        //si on ajoute un item on doit ajouter à ce dico pour le afficher
        public Dictionary<BasicItem, int> slots = new Dictionary<BasicItem, int>();

        public int currentWeight;



        //dès qu'on ouvre l'inventory on l'affiche , appele depuis player inventory
        public void WakeUp(Dictionary<BasicItem,int> dico){
            slots=dico;

            if(slots.Count==0){
                //Debug.Log("nbSlots est de : "+slots.Count);
                Debug.Log("ERROR, DICO VIDE");
            }
            /*
            else{
                Debug.Log("nbSlots est de : "+slots.Count);

                Debug.Log("LE DICTIONNAIRE EST: \n");
                foreach(KeyValuePair<BasicItem,int> kvp in this.slots){
                Debug.Log("item : "+kvp.Key.getName()+", qtt : "+kvp.Value);
                }
            }*/
            
            afficheInventory();

            //normalement ici on devrait avoir une variable globale qui permet de 
            //afficher le weightInventory/maxWeight
            //comme ça on fait des tests pour voir s'il peut charger encore plus de poids
            //de ce qu'il porte maintenant
            /*Debug.Log(currentWeight);
            Debug.Log(this.weightMax);*/
        }

        //retourne le maxWeight de l'inventory
        public int getWeightMax(){
            return this.weightMax;
        }

        //pour tout element on instancie son slot (qui aura une image etc etc) et on l'ajoute
        //si on change un slot:
        //il faut appeler updateslot ou un truc du sort
        //qui change
        // ---la qtt
        // ---le weight
        // ---le (ou les) dicos inventory.cs et playerInventory.cs
        void afficheInventory(){
            for(int i=0;i<slots.Count;i++){
                //Debug.Log("on entre dans la boucle");
                //on cree l'objet prefab slot
                GameObject slot = (GameObject) Instantiate(SlotImage);//, new Vector3(1,1,0)

                //MOMENT DE REMPLIR LE SLOT
                //on prend la key/value du dico a la pos i ##########################
                BasicItem itemOfSlot = slots.ElementAt(i).Key;
                int qttDuSlot = slots.ElementAt(i).Value;

                currentWeight+=itemOfSlot.getWeight()*qttDuSlot;



                //pour remplir les infos a l'interieur du slot
                //IL FAUT FAIRE GET COMPONENTS ET PARCOURIR TAB, PARENT[0] FAIRE GAFFE
                Image[] imgDuSlot = slot.GetComponentsInChildren<Image>();
                foreach(Image imgS in imgDuSlot){
                    if(imgS.gameObject.transform.parent != null){
                        imgS.sprite = itemOfSlot.getSprite();
                        imgS.transform.localScale = new Vector3(1.0f,1.0f,1.0f);
                    }
                }

                TextMeshProUGUI[] qtt = slot.GetComponentsInChildren<TextMeshProUGUI>();
                foreach(TextMeshProUGUI text in qtt){
                    if(text.gameObject.transform.parent != null){
                        text.SetText(qttDuSlot.ToString());
                    }
                }

                //on dit que son parent est le Grid Layout Group PANEL INVENTORY
                slot.transform.SetParent(slotPanel);


                //CHANGER LA TAILLE APRES DAVOIR AJOUTE AU PARENT !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                slot.transform.localScale = new Vector3(1.0f,1.0f,1.0f);

            }
            
        }


        


        //permet d'ajouter un slot au dictionnaire, ainsi qu'a l'affichage
        void addItem(BasicItem item){
            GameObject slot = Instantiate(SlotImage);


            //au moment d'ajouter dans le dico, il faut
            //chercher si key existe
            //si yes, on augmente/diminue la value,
            //sinon on ajoute key et value
            //si value == 0 alors on efface element
        }

        public override string ToString()
        {
            string rtrn = string.Empty;
            foreach (KeyValuePair<BasicItem, int> kvp in slots)
            {
                rtrn += kvp.Key + " : \n{";
                rtrn += "\t" + kvp.Key.getName() + "\n";
                rtrn += "\t" + kvp.Key.getId() + "\n";
                rtrn += "\t" + kvp.Key.getDesc() + "\n";
                rtrn += "\t" + kvp.Key.getSprite().ToString() + "\n";
                //rtrn += "\t" + kvp.Key.getPrice().ToString() + "\n";
                rtrn += "\tQuantité" + kvp.Value.ToString() + "\n";
                rtrn += "}";
            }


            return rtrn;
        }





    }
}