using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;


namespace game
{
    /// <summary>
    /// La classe <c>Inventory</c> s'occupe des inventaires.
    /// Elle possède les attributs suivant: panel (qui correspond au panel sur lequel l'inventaire va être présenté),
    /// weightMax (tous les inventaires ont une capacité maximum), slots (qui correspond aux items qui vont remplir l'inventaire)
    /// et currentWeight qui correspond à la capacité actuelle de l'inventaire
    /// </summary>
    public class Inventory : MonoBehaviour
    {

        public InventoryInterface panel;

        private int weightMax=1000;

        //dictionnaire des items pour remplir le inventory
        //si on ajoute un item on doit ajouter à ce dico pour le afficher
        private Dictionary<BasicItem, int> slots = new Dictionary<BasicItem, int>();

        private int currentWeight = 0;


        /// <summary>
        /// La méthode <c>addToInventory</c> permet d'ajouter un slot au dictionnaire
        /// </summary>
        /// <param name="item"></param>
        /// <param name="qtt"></param>
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

        /// <summary>
        /// La méthode <c>removeFromInventory</c> permet d'enlever instantanément un item.
        /// </summary>
        /// <param name="item"></param>
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
        //@@@@@@@@@/@@@@@@@@@/@@@@@@@@@/@@@@@@@@@/@@@@@@@@@/@@@@@@@@@/@@@@@@@@@/@@@@@@@@@
        //deux fonctions diff, une ou on envoie le dico comme parametre, une ou on utilise le dico global value

        //normalement, faire de meme avec add et delete
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

        public void SubstractFromInventory(BasicItem item, int qttToRemove, Dictionary<BasicItem, int> dicoASoustraire)
        {
            if (qttToRemove < 1)
                return;
            else
            {
                foreach (BasicItem kvp in dicoASoustraire.Keys.ToList())
                {
                    if (kvp.getId() == item.getId())
                    {
                        if (dicoASoustraire[kvp] > qttToRemove)
                            dicoASoustraire[kvp] -= qttToRemove;
                        else
                            dicoASoustraire.Remove(kvp);

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

        public bool isDicoVide()
        {
            //Debug.Log("nb slots : " + slots.Count);
            //Debug.Log("nb slots THIS : " + this.slots.Count);

            if (slots.Count > 0)
            {
                return false;
            }
            
            return true;
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