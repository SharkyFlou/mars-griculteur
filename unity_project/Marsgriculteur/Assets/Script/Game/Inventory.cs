using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;


namespace game
{
    public class Inventory
    {

        public InventoryInterface panel;

        private int weightMax=1000;
        //permet de prendre le Dictionary inventory du player
        
        //public PlayerInventory playerInventory;

        //correspond au slot a initialiser
        
        //correspond au panel parent
        

        //dictionnaire des items pour remplir le inventory
        //si on ajoute un item on doit ajouter à ce dico pour le afficher
        private Dictionary<BasicItem, int> slots = new Dictionary<BasicItem, int>();

        private int currentWeight = 0;



        //permet d'ajouter un slot au dictionnaire
        public void addToInventory(BasicItem item, int qtt)
        {
            bool trouve = false;
            
            if (qtt < 1)
                return;
            else
            {
                //on parcourt chaque key pour acceder a son getId()
                foreach (BasicItem kvp in slots.Keys.ToList())
                {
                    if (kvp.getId() == item.getId())
                    {
                        slots[kvp] += qtt;
                        trouve = true;
                        break;
                    }
                }
                //si on le trouve pas on l'ajoute a notre 
                if (!trouve)
                {
                    slots.Add(item, qtt);
                }
                currentWeight += item.getWeight() * qtt;
            }
            
            //displayInventory();

        }

        //removes an item instantly
        public void removeFromInventory(BasicItem item)
        {
            foreach (BasicItem kvp in slots.Keys.ToList())
            {
                if (kvp.getId() == item.getId())
                {
                    slots.Remove(kvp);
                    break;
                }
            }

            //displayInventory();
        }

        //permet de soustraire une qtt a un item qui se trouve deja dans notre inventory 
        //ou l'elilminer completement
        public void SubstractFromInventory(BasicItem item, int qttToRemove)
        {
            if (qttToRemove < 1)
                return;
            else
            {
                foreach (BasicItem kvp in slots.Keys.ToList())
                {
                    if (kvp.getId() == item.getId())
                    {
                        if (slots[kvp] > qttToRemove)
                            slots[kvp] -= qttToRemove;
                        else
                            slots.Remove(kvp);

                        break;
                    }
                }
            }

            //displayInventory();

        }

        public Dictionary<BasicItem, int> getInventory()
        {

            return this.slots;
        }

        //retourne le maxWeight de l'inventory
        public int getWeightMax()
        {
            return this.weightMax;
        }

        public int getCurrentWeight()
        {
            return this.currentWeight;
        }

        //pour tout element on instancie son slot (qui aura une image etc etc) et on l'ajoute
        
        public void displayInventory()
        {
            panel.afficheInventory(slots);
        }
        override public string ToString()
        {
            string rtr = string.Empty;
            foreach(KeyValuePair<BasicItem, int> kvp in slots)
            {
                rtr += kvp.Key.getName() + "\t : " + kvp.Value.ToString() + "\n";
            }
            return rtr;
        }


    }
}