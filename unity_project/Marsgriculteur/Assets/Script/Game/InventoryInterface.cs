using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace game
{
    /// <summary>
    /// L'interface <c>InventoryInterface</c> permet de déclarer une fonction afficheInventory, qui va être implémenté dans les classes qui l'implémentent
    /// </summary>
    public interface InventoryInterface
    {
        /// <summary>
        /// La méthode <c>afficheInventory</c> permet d'afficher l'inventaire
        /// </summary>
        /// <param name="dico"></param>
        public void afficheInventory(Dictionary<BasicItem, int> dico);
    }
}
