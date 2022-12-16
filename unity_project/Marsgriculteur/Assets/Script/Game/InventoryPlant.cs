using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace game
{
    /// <summary>
    /// La classe <c>InventoryPlant</c> hérite de la classe <c>Inventory</c>. Cette classe représente l'inventaire des plantes.
    /// Elle possède un dictionnaire <c>PlantSlots</c> qui regroupe toutes les plantes avec leur quantité.
    /// </summary>
    public class InventoryPlant : Inventory
    {
        public Dictionary<EnumTypePlant, int> PlantSlots = new Dictionary<EnumTypePlant, int>();

        /// <summary>
        /// La méthode <c>getNbrSlots</c> permet d'avoir la quantité d'une plante donnée en paramètre.
        /// </summary>
        /// <param name="item">Le type de la plante.</param>
        /// <returns>Elle retourne la quantité de la plante.</returns>
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
        /// La méthode <c>setNbrSlots</c> permet d'enlever de la quantité.
        /// </summary>
        /// <param name="item">Le type de la plante.</param>
        /// <param name="number">La quantité à enlever.</param>
        public void setNbrSlots(EnumTypePlant item, int number)
        {
            PlantSlots[item] -= number;
        }
    }
}


