using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace game
{
    public class Seed : BasicPlant
    {
        private int timeGrowth;
        private int price;
        public Seed() 
        {
        
        }
        public Seed(EnumTypePlant paraTypePlant, int paraId, string paraName, string paraDescription, Sprite paraImagelink, int paraTimeGroth, int paraWeight, int paraPrice)
        {
            this.typePlante = paraTypePlant;
            this.id = paraId;
            this.itemName = paraName;
            this.description = paraDescription;
            this.imageLink = paraImagelink;
            this.timeGrowth = paraTimeGroth;
            this.weight = paraWeight;
            this.price = paraPrice;
        }
        /*
        public Seed(EnumTypePlant seed)
        {
            CreateAllSeedPlant.dicoPlant.createSeed(seed);
        }*/

        public int getPrice()
        {
            return this.price;
        }

        public int getTimeGrowth()
        {
            return this.timeGrowth;
        }

    }

}
