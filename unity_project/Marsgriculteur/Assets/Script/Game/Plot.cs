using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace game
{
    /// <summary>
    /// La classe <c>Plot</c> hérite de la classe <c>BasicItem</c>. Elle s'occuper de créer des champs.
    /// Elle possède 6 attributs : typePlot, isPlanted, currentPlant, timeGrown, capacity, number (quantité des graines sur le champs).
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
        /// Le constructeur <c>Plot</c> permet de créer un champs.
        /// </summary>
        /// <param name="paraTypePlot">le type de champs</param>
        /// <param name="paraCurrentPlant">la plante qui est sur le champs</param>
        /// <param name="paraTimeGrown">le temps de pousse</param>
        /// <param name="paraCapacity">la capacité du champs</param>
        /// <param name="paraNumber">la quantité de graines que le champs a besoin pour faire pousser une plante</param>
        public Plot(EnumTypePlot paraTypePlot, EnumTypePlant paraCurrentPlant, int paraTimeGrown, int paraCapacity, int paraNumber){
            this.typePlot = paraTypePlot;
            this.isPlanted = false;
            this.currentPlant = paraCurrentPlant;
            this.timeGrown = paraTimeGrown;
            this.capacity = paraCapacity;
            this.number = paraNumber;
        }

        /// <summary>
        /// La méthode <c>setIsPlanted</c> permet de savoir si une plante est planté sur le champs
        /// </summary>
        /// <param name="paraIsPlanted"></param>
        /// <returns>Elle retourne un booléen si c'est planté ou pas</returns>
        public bool setIsPlanted(bool paraIsPlanted){
            return this.isPlanted = paraIsPlanted;
        }

        /// <summary>
        /// La méthode <c>getTimeGrown</c> permet d'obtenir le temps de pousse.
        /// </summary>
        /// <returns>Elle retourne le temps de pousse</returns>
        public int getTimeGrown()
        {
            return this.timeGrown;  
        }

        /// <summary>
        /// La méthode <c>getTypePlant</c> permet de connaître le type de la plante qui pousse sur le champs
        /// </summary>
        /// <returns>Elle retourne le type de la plante</returns>
        public EnumTypePlant getTypePlant()
        {
            return this.currentPlant;
        }

        /// <summary>
        /// La méthode <c>getCapacity</c> permet de connaître la capacité du champs
        /// </summary>
        /// <returns>Elle retourne sa capacité</returns>
        public int getCapacity()
        {
            return this.capacity;
        }

        /// <summary>
        /// La méthode <c>getQuantitySeed</c> permet de connaître la quantité de graines qu'à besoin le champs pour faire pousser une plante.
        /// </summary>
        /// <returns>Elle retourne la quantité de graines.</returns>
        public int getQuantitySeed()
        {
            return this.number;
        }

        /// <summary>
        /// La méthode <c>growSeed</c> permet de faire pousser une graine
        /// </summary>
        public void growSeed()
        {
            //make the seed grow by 1
        }


        /// <summary>
        /// La méthode <c>changePlantSprite</c> permet de changer l'image de la plante pendant qu'elle pousse
        /// </summary>
        private void changePlantSprite()
        {
            //change the sprit
        }
    }

}
