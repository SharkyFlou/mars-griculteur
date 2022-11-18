using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace game
{
    public class Plant : BasicPlant
    {
        public List<int> basicPlantPrice;
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

        public int getPrice(int month)
        {
            return basicPlantPrice[month];
        }
    }

}
