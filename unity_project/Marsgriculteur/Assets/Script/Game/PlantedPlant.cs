using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace game
{
    /// <summary>
    /// La classe <c>PlantedPlant</c> h�rite de BasicPlant. Elle permet de cr�er une plante qui sera mise dans un champs.
    /// Elle poss�de 2 sprites, un pour quand elle n'a pas pouss� et un quand elle a pouss�. Elle a aussi un temps de pousse et un type.
    /// </summary>
    public class PlantedPlant : BasicPlant
    {
        private List<Sprite> spriteLinks;
        private int growthTime;
        private EnumTypePlant typePlant;
        private int nbPlantCollect;

        /// <summary>
        /// Le constructeur <c>PlantedPlant</c> permet de cr�er une plante qui va �tre plant� (juste avec son temps de pousse et � son type)
        /// </summary>
        /// <param name="paraTypePlant">le type de la plante</param>
        /// <param name="paraGrowthTime">le temps de pousse</param>
        public PlantedPlant(EnumTypePlant paraTypePlant, int paraGrowthTime)
        {
            this.typePlant = paraTypePlant;
            this.growthTime = paraGrowthTime;
        }

        /// <summary>
        /// Le constructeur <c>PlantedPlant</c> permet de cr�er une plante qui va �tre plant�.
        /// </summary>
        /// <param name="paraTypePlant">le type de plante</param>
        /// <param name="paraId">l'id de la plante</param>
        /// <param name="paraName">le nom de la plante</param>
        /// <param name="paraDescription">la description de la plante</param>
        /// <param name="paraImagelink">le lien de l'image de la plante</param>
        /// <param name="paraSpriteLinks">le liste des images de la plante</param>
        /// <param name="paraGrowthTime">le temps de pousse de la plante</param>
        /// <param name="paraNbCollect">la quantit� de plante collect�e apr�s la pousse</param>
        public PlantedPlant(EnumTypePlant paraTypePlant, int paraId, string paraName, string paraDescription, Sprite paraImagelink, List<Sprite> paraSpriteLinks, int paraGrowthTime, int paraNbCollect)
        {
            this.typePlante = paraTypePlant;
            this.id = paraId;
            this.itemName = paraName;
            this.description = paraDescription;
            this.imageLink = paraImagelink;
            this.spriteLinks = paraSpriteLinks;
            this.growthTime = paraGrowthTime;
            this.nbPlantCollect = paraNbCollect;
        }

        /// <summary>
        /// Le constructeur <c>PlantedPlant</c> permet de cr�er une plante "Error" si jamais il y a une erreur.
        /// </summary>
        public PlantedPlant()
        {
            this.typePlante = EnumTypePlant.ELB;
            this.id = 666;
            this.itemName = "Error";
            this.description = "Error, using an empty constructor";
            this.imageLink = Game.getDefaultSprite();
            this.spriteLinks  = new List<Sprite>();
            this.growthTime = -1;

        }

        /// <summary>
        /// La m�thode <c>getSpriteLinks</c> permet d'obtenir les 2 images de la plante
        /// </summary>
        /// <returns>Elle retourne une liste des images.</returns>
        public List<Sprite> getSpriteLinks()
        {
            return spriteLinks;
        }

        /// <summary>
        /// La m�thode <c>getGrowthTime</c> permet d'obtenir le temps de pousse de la plante.
        /// </summary>
        /// <returns>Elle retourne son temps de pousse</returns>
        public int getGrowthTime()
        {
            return growthTime;
        }

        /// <summary>
        /// La m�thode <c>getNbCollect</c> permet de conna�tre la quantit� de plante collect�e apr�s la pousse.
        /// </summary>
        /// <returns>Elle retourne la quantit� de plante collect�e</returns>
        public int getNbCollect()
        {
            return nbPlantCollect;
        }
    }


}
