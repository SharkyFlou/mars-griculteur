using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace game
{
    public abstract class Inventory
    {
        private const int MAX_WEIGHT = 1000;

        private int weight;

        //Ajouter méthode allSeedPlant qui donne accès au données des basicItem
        protected Dictionary<BasicItem, int> slots = new();

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

        public int getNumberItem(BasicItem key)
        {
            return slots[key];
        }

        public void addItem(BasicItem key, int number)
        {
            slots[key] += number;
        }

        public int getMaxWeight()
        {
            return MAX_WEIGHT;
        }
    }
}