using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

namespace game
{
    abstract public class Inventory
    {
        private const int MAX_WEIGHT = 1000;

        private int weight;

        //Garder <string, int>
        //Ajouter méthode allSeedPlant qui donne accès au données des basicItem
        protected Dictionary<BasicItem, int> slots = new Dictionary<BasicItem, int>();

        public Inventory()
        {

        }
        
        public string toString()
        {
            string rtrn = string.Empty;
            foreach (KeyValuePair<BasicItem, int> kvp in slots)
            {
                rtrn += kvp.Key.getName() + " : ";
                rtrn += kvp.Value + "\n";
            }

            return rtrn;
        }

        //voir comment the fuck on recoit l'info de chaque item dans le slot
        public int getNumberItem(BasicItem key)
        {
            return this.slots[key];
        }

        public void addItem(BasicItem key, int number)
        {
            this.slots[key] += number;
        }

        public int getMaxWeight()
        {
            return MAX_WEIGHT;
        }
    }
}