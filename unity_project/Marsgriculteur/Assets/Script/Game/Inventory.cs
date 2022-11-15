using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace game
{
    abstract public class Inventory : MonoBehaviour
    {
        private int weightMax=1000;
        private Dictionary<BasicItem, int> slots = new Dictionary<BasicItem, int>();

//voir comment the fuck on recoit l'info de chaque item dans le slot
        public string getInfoSlot()
        {
            return "AAAAAAH";
        }

        public int getWeightMax(){
            return this.weightMax;
        }
    }
}