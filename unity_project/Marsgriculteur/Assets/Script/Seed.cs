using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace game
{
    public class Seed : BasicPlant
    {
        private EnumTypePlant name;
        private int timeGrowth;
        private int weight;
        private int price;

        public Seed(EnumTypePlant paraName, int paraTimeGrowth, int paraWeight, int paraPrice){
            this.name = paraName;
            this.timeGrowth = paraTimeGrowth;
            this.weight = paraWeight;
            this.price = paraPrice;
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
