using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace game
{
    abstract public class Inventory : MonoBehaviour
    {
        private const int MAX_WEIGHT = 1000;

        private int weight;
        
        //Garder <string, int>
        //Ajouter méthode allSeedPlant qui donne accès au données des basicItem
        private Dictionary<string, int> slots = new Dictionary<string, int>();

        //voir comment the fuck on recoit l'info de chaque item dans le slot
        public int getNumberSlot(string key)
        {
            return this.slots[key];
        }

        public int getWeightMax(){
            return MAX_WEIGHT;
        }
    }
}