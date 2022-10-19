using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace game
{
    public class Plot : BasicItem
    {
        private EnumTypePlot typePlot;
        private bool isPlanted;
        private EnumTypePlant currentPlant;
        private int timeGrown;
        private int capacity;
        private int number;

        public Plot(EnumTypePlot paraTypePlot, EnumTypePlant paraCurrentPlant, int paraTimeGrown, int paraCapacity, int paraNumber){
            this.typePlot = paraTypePlot;
            this.isPlanted = false;
            this.currentPlant = paraCurrentPlant;
            this.timeGrown = paraTimeGrown;
            this.capacity = paraCapacity;
            this.number = paraNumber;
        }

        public bool setIsPlanted(bool paraIsPlanted){
            return this.isPlanted = paraIsPlanted;
        }
        public int getTimeGrown()
        {
            return this.timeGrown;  
        }

        public EnumTypePlant getTypePlant()
        {
            return this.currentPlant;
        }

        public int getCapacity()
        {
            return this.capacity;
        }

        public int getQuantitySeed()
        {
            return this.number;
        }

        public void growSeed()
        {
            //make the seed grow by 1
        }

        private void changePlantSprite()
        {
            //change the sprit
        }

    }

}
