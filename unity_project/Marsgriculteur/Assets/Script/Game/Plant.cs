using System.Collections.Generic;
using UnityEngine;

namespace game
{
    /// <summary>
    /// La classe <c>Plant</c> h�rite de BasicPlant. Elle permet de cr�er les plantes qui seront r�colt�s et qui vont �tre vendu.
    /// Elle poss�de une liste de prix.
    /// </summary>
    public class Plant : BasicPlant
    {
        public List<int> basicPlantPrice;

        /// <summary>
        /// Le constructeur <c>Plant</c> permet de cr�er une plante.
        /// </summary>
        /// <param name="paraTypePlant">le type de la plante</param>
        /// <param name="paraId">l'id de la plante</param>
        /// <param name="paraName">le nom de la plante</param>
        /// <param name="paraDescription">la description de la plante</param>
        /// <param name="paraImagelink">le lien de l'image de la plante</param>
        /// <param name="paraBasicPlantPrice">le prix de la plante</param>
        /// <param name="paraPlantWeight">le poids de la plante</param>
        public Plant(EnumTypePlant paraTypePlant, int paraId, string paraName, string paraDescription, Sprite paraImagelink, List<int> paraBasicPlantPrice, int paraPlantWeight)
        {
            this.typePlante = paraTypePlant;
            this.id = paraId;
            this.itemName = paraName;
            this.description = paraDescription;
            this.imageLink = paraImagelink;
            this.basicPlantPrice = paraBasicPlantPrice;
            this.weight = paraPlantWeight;
        }

        /// <summary>
        /// Ce constructeur cr�e une plante "Error" si jamais il y a un probl�me
        /// </summary>
        public Plant()
        {
            this.typePlante = EnumTypePlant.ELB;
            this.id = 666;
            this.itemName = "Error";
            this.description = "Error, using an empty constructor";
            this.imageLink = Game.getDefaultSprite();
            this.basicPlantPrice = new List<int>();
            this.weight = -1;
        }

        /// <summary>
        /// La m�thode <c>getPrice</c> permet d'obtenir le prix de la plante
        /// </summary>
        /// <param name="month">la valeur du mois</param>
        /// <returns>Elle retourne le prix</returns>
        public int getPrice(int month)
        {
            return basicPlantPrice[month % 12];
        }
    }

}
