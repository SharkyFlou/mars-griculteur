using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace game
{
    /// <summary>
    /// La classe <c>Shop</c> permet de cr�er un magasin avec toutes les graines qu'on peut acheter.
    /// Elle possède un attribut inventory et un dictionnaire qui contient tous les item du magasin.
    /// </summary>
    public class Shop : MonoBehaviour
    {

        public Inventory inventory;
        // Magasin de vente de graines
        // C'est un inventaire à haute quantité qui ne peut pas être réduit
        public Dictionary<BasicItem, int> slots = new Dictionary<BasicItem, int>();

        /// <summary>
        /// Ce constructeur est là pour la compilation
        /// </summary>
        public Shop()
        {
        }



    }

}
