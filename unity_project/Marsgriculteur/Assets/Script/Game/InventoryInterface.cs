using System.Collections.Generic;

namespace game
{
    /// <summary>
    /// L'interface <c>InventoryInterface</c> permet de déclarer une fonction <c>afficheInventory</c>, qui va être implémenté dans les classes qui l'implémentent.
    /// </summary>
    public interface InventoryInterface
    {
        /// <summary>
        /// La méthode <c>afficheInventory</c> permet d'afficher l'inventaire.
        /// </summary>
        /// <param name="dico">Le dictionnaire qui contient les items.</param>
        public void afficheInventory(Dictionary<BasicItem, int> dico);
    }
}
