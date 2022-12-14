using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace game
{
    /// <summary>
    /// La classe <c>Plot</c> h�rite de la classe <c>BasicItem</c>. Elle s'occuper de cr�er des champs.
    /// Elle poss�de 6 attributs : typePlot, isPlanted, currentPlant, timeGrown, capacity, number (quantit� des graines sur le champs).
    /// </summary>
    public class Plot : BasicItem
    {
        private EnumTypePlot typePlot;
        private bool isPlanted;
        private EnumTypePlant currentPlant;
        private int timeGrown;
        private int capacity;
        private int number;

        /// <summary>
        /// Le constructeur <c>Plot</c> permet de cr�er un champs.
        /// </summary>
        /// <param name="paraTypePlot">le type de champs</param>
        /// <param name="paraCurrentPlant">la plante qui est sur le champs</param>
        /// <param name="paraTimeGrown">le temps de pousse</param>
        /// <param name="paraCapacity">la capacit� du champs</param>
        /// <param name="paraNumber">la quantit� de graines que le champs a besoin pour faire pousser une plante</param>
        public Plot(EnumTypePlot paraTypePlot, EnumTypePlant paraCurrentPlant, int paraTimeGrown, int paraCapacity, int paraNumber){
            this.typePlot = paraTypePlot;
            this.isPlanted = false;
            this.currentPlant = paraCurrentPlant;
            this.timeGrown = paraTimeGrown;
            this.capacity = paraCapacity;
            this.number = paraNumber;
        }

        /// <summary>
        /// La m�thode <c>setIsPlanted</c> permet de savoir si une plante est plant� sur le champs
        /// </summary>
        /// <param name="paraIsPlanted"></param>
        /// <returns>Elle retourne un bool�en si c'est plant� ou pas</returns>
        public bool setIsPlanted(bool paraIsPlanted){
            return this.isPlanted = paraIsPlanted;
        }

        /// <summary>
        /// La m�thode <c>getTimeGrown</c> permet d'obtenir le temps de pousse.
        /// </summary>
        /// <returns>Elle retourne le temps de pousse</returns>
        public int getTimeGrown()
        {
            return this.timeGrown;  
        }

        /// <summary>
        /// La m�thode <c>getTypePlant</c> permet de conna�tre le type de la plante qui pousse sur le champs
        /// </summary>
        /// <returns>Elle retourne le type de la plante</returns>
        public EnumTypePlant getTypePlant()
        {
            return this.currentPlant;
        }

        /// <summary>
        /// La m�thode <c>getCapacity</c> permet de conna�tre la capacit� du champs
        /// </summary>
        /// <returns>Elle retourne sa capacit�</returns>
        public int getCapacity()
        {
            return this.capacity;
        }

        /// <summary>
        /// La m�thode <c>getQuantitySeed</c> permet de conna�tre la quantit� de graines qu'� besoin le champs pour faire pousser une plante.
        /// </summary>
        /// <returns>Elle retourne la quantit� de graines.</returns>
        public int getQuantitySeed()
        {
            return this.number;
        }

        /// <summary>
        /// La m�thode <c>growSeed</c> permet de faire pousser une graine
        /// </summary>
        public void growSeed()
        {
            //make the seed grow by 1
        }


        /// <summary>
        /// La m�thode <c>changePlantSprite</c> permet de changer l'image de la plante pendant qu'elle pousse
        /// </summary>
        private void changePlantSprite()
        {
            //change the sprit
        }
    }

}
