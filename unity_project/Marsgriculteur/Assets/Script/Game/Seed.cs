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

        public Seed(EnumTypePlant paraTypePlant, int paraId, string paraName, string paraDescription, Sprite paraImagelink, int paraTimeGroth, int paraWeight, int paraPrice)
        {
            this.typePlante = paraTypePlant;
            this.id = paraId;
            this.nam = paraName;
            this.description = paraDescription;
            this.imageLink = paraImagelink;
            this.timeGrowth = paraTimeGroth;
            this.weight = paraWeight;
            this.price = paraPrice;
        }

        public Seed()
        {
            this.typePlante = EnumTypePlant.ELB;
            this.id = 666;
            this.nam = "Error";
            this.description = "Error, using an empty constructor";
            this.imageLink = Game.getDefaultSprite();
            this.timeGrowth = -1;
            this.weight = -1;
            this.price = -1;
        }

        public int getPrice()
        {
            return this.price;
        }

        public int getTimeGrowth()
        {
            return this.timeGrowth;
        }

        public int getWeighth()
        {
            return this.weight;
        }
    }

}
