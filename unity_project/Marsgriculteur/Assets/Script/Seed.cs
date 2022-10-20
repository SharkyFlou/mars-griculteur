using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace game
{
    public class Seed : BasicPlant
    {
        private int timeGrowth;
        private int weight;
        private int price;

        public Seed(EnumTypePlant paraTypePlant, int paraId, string paraName, string paraDescription, string paraImagelink, int paraTimeGrowth, int paraWeight, int paraPrice)
        {
            this.typePlante = paraTypePlant;
            this.id = paraId;
            this.name = paraName;
            this.description = paraDescription;
            this.imageLink = paraImagelink;
            this.timeGrowth = paraTimeGrowth;
            this.weight = paraWeight;
            this.price = paraPrice;
        }

        public Seed()
        {
            this.typePlante = EnumTypePlant.ELB;
            this.id = 666;
            this.name = "Error";
            this.description = "Error, using an empty constructor";
            this.imageLink = Game.getDefaultImage();
            this.timeGrowth = -1;
            this.weight = -1;
            this.price = -1;
        }

        public int getPrice()
        {
            return price;
        }

        public int getTimeGrowth()
        {
            return timeGrowth;
        }

        public int getWeight()
        {
            return weight;
        }
    }

}