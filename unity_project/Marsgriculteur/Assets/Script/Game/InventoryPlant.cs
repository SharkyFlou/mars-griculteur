using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace game
{
    public class InventoryPlant : Inventory
    {
        public new Dictionary<EnumTypePlant, int> slots;

        public int getNbrSlots(EnumTypePlant item)
        {
            int number = -1;
            foreach (KeyValuePair<EnumTypePlant, int> slot in slots)
            {

                if (item == slot.Key)
                {
                    number = slot.Value;
                }
            }
            return number;
        }

        public void setNbrSlots(EnumTypePlant item, int number)
        {
            slots[item] -= number;
        }
    }
}


