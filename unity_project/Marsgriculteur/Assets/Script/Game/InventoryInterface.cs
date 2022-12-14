using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace game
{
    /// <summary>
    /// L'interface <c>InventoryInterface</c> permet de d�clarer une fonction afficheInventory, qui va �tre impl�ment� dans les classes qui l'impl�mentent
    /// </summary>
    public interface InventoryInterface
    {
        /// <summary>
        /// La m�thode <c>afficheInventory</c> permet d'afficher l'inventaire
        /// </summary>
        /// <param name="dico"></param>
        public void afficheInventory(Dictionary<BasicItem, int> dico);
    }
}
