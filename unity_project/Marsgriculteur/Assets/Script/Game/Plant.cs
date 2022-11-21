using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace game
{
    public class Plant : BasicPlant
    {
        public List<int> basicPlantPrice;
        public int plantWeight;
        public Plant(EnumTypePlant paraTypePlant, int paraId, string paraName, string paraDescription, Sprite paraImagelink, List<int> paraBasicPlantPrice, int paraPlantWeight)
        {
            this.typePlante = paraTypePlant;
            this.id = paraId;
            this.nam = paraName;
            this.description = paraDescription;
            this.imageLink = paraImagelink;
            this.basicPlantPrice = paraBasicPlantPrice;
            this.plantWeight = paraPlantWeight;
        }

        public Plant()
        {
            this.typePlante = EnumTypePlant.ELB;
            this.id = 666;
            this.nam = "Error";
            this.description = "Error, using an empty constructor";
            this.imageLink = Game.getDefaultSprite();
            this.basicPlantPrice = new List<int>();
            this.plantWeight = -1;
        }

        public int getPrice(int month)
        {
            return basicPlantPrice[month % 12];
        }
    }

}
