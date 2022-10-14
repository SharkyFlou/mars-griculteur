using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace game
{
    public class Plot : BasicItem
    {
        private EnumTypePlot typePlot;
        private bool isPlanted;
        private PlantedPlant currentPlant;
        private int timeGrown;
        private int capacity;
        private int number;


        public int getTimeGrown()
        {
            return timeGrown;
        }

        public EnumTypePlant getTypePlant()
        {
            return EnumTypePlant.ELB;
        }

        public int getCapacity()
        {
            return capacity;
        }

        public int getQuantitySeed()
        {
            return number;
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
