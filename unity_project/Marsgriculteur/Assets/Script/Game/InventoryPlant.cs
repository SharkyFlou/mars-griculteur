using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace game
{
    /// <summary>
    /// La classe <c>InventoryPlant</c> h�rite de la classe <c>Inventory</c>. Cette classe repr�sente l'inventaire des plantes.
    /// Elle poss�de un dictionnaire <c>PlantSlots</c> qui regroupe toutes les plantes avec leur quantit�.
    /// </summary>
    public class InventoryPlant : Inventory
    {
        public Dictionary<EnumTypePlant, int> PlantSlots = new Dictionary<EnumTypePlant, int>();

        /// <summary>
        /// La m�thode <c>getNbrSlots</c> permet d'avoir la quantit� d'une plante donn�e en param�tre.
        /// </summary>
        /// <param name="item">Le type de la plante.</param>
        /// <returns>Elle retourne la quantit� de la plante.</returns>
        public int getNbrSlots(EnumTypePlant item)
        {
            int number = -1;
            foreach (KeyValuePair<EnumTypePlant, int> slot in PlantSlots)
            {

                if (item == slot.Key)
                {
                    number = slot.Value;
                }
            }
            return number;
        }

        /// <summary>
        /// La m�thode <c>setNbrSlots</c> permet d'enlever de la quantit�.
        /// </summary>
        /// <param name="item">Le type de la plante.</param>
        /// <param name="number">La quantit� � enlever.</param>
        public void setNbrSlots(EnumTypePlant item, int number)
        {
            PlantSlots[item] -= number;
        }
    }
}


