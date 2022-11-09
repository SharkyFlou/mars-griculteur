using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace game
{
    abstract public class Inventory : MonoBehaviour
    {
        private int weightMax;
        private Dictionary<BasicItem, int> slots = new Dictionary<BasicItem, int>();
        public string getInfoSlot()
        {
            return "AAAAAAH";
        }
    }
}