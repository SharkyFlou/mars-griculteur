using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace game
{
    /// <summary>
    /// BasicItem est la classe parent de tous les objets du jeu, les plantes, les graines, les outils (pas implémenté), les champs, ...
    /// Elle possède les attributs suivant : id, itemName (nom de l'item), description, imageLink (lien de l'image), weight (le poids), price (le prix).
    /// </summary>
    public abstract class BasicItem
    {
        public int id;
        protected string itemName;
        protected string description;
        protected Sprite imageLink;
        protected int weight;
        protected int price;

        /// <summary>
        /// Ce constructeur est là, même s'il est vide, car sinon ça ne compilait pas.
        /// </summary>
        public BasicItem()
        {

        }

        /// <summary>
        /// Le constructeur <c>BasicItem</c> permet de créer un objet grace à son ID, son nom, sa description et son image.
        /// </summary>
        /// <param name="paraId">l'id de l'item</param>
        /// <param name="paraName">le nom de l'item</param>
        /// <param name="paraDescription">la description de l'item</param>
        /// <param name="paraImageLink">le lien de l'item</param>
        public BasicItem(int paraId, string paraName, string paraDescription, Sprite paraImageLink)
        {
            id = paraId;
            itemName = paraName;
            description = paraDescription;
            imageLink = paraImageLink;
        }

        /// <summary>
        /// La méthode <c>getWeight</c> permet d'obtenir le poids de l'item (s'il en a un)
        /// </summary>
        /// <returns>Elle retourne son poids</returns>
        public int getWeight()
        {
            return weight;
        }

        /// <summary>
        /// La méthode <c>getSprite</c> permet d'obtenir l'image de l'item
        /// </summary>
        /// <returns>Elle retourne son image</returns>
        public Sprite getSprite()
        {
            return imageLink;
        }

        /// <summary>
        /// La méthode <c>getDesc</c> permet d'obtenir la description de l'item
        /// </summary>
        /// <returns>Elle retourne sa description</returns>
        public string getDesc()
        {
            return description;
        }

        /// <summary>
        /// La méthode <c>getName</c> permet d'obtenir le nom de l'item
        /// </summary>
        /// <returns>Elle retourne son nom</returns>
        public string getName()
        {
            return itemName;
        }

        /// <summary>
        /// La méthode <c>getId</c> permet d'obtenir l'identifiant de l'item
        /// </summary>
        /// <returns>Elle retourne son identifiant</returns>
        public int getId()
        {
            return id;
        }

        /// <summary>
        /// La méthode <c>getPrice</c> permet d'obtenir le prix de l'item
        /// </summary>
        /// <returns>Elle retourne son prix</returns>
        public int getPrice()
        {
            return price;
        }
    }

}
