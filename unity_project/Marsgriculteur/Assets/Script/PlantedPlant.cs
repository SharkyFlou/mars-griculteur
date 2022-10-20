using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace game
{
    public class PlantedPlant : BasicPlant
    {
        private List<string> spriteLinks;
        private int growthTime;
        private EnumTypePlant typePlant;

        public PlantedPlant(EnumTypePlant paraTypePlant, int paraGrowthTime)
        {
            this.typePlant = paraTypePlant;
            this.growthTime = paraGrowthTime;
        }

        public PlantedPlant(EnumTypePlant paraTypePlant, int paraId, string paraName, string paraDescription, string paraImagelink, List<string> paraSpriteLinks, int paraGrowthTime)
        {
            this.typePlante = paraTypePlant;
            this.id = paraId;
            this.name = paraName;
            this.description = paraDescription;
            this.imageLink = paraImagelink;
            this.spriteLinks = paraSpriteLinks;
            this.growthTime = paraGrowthTime;
        }

        public PlantedPlant()
        {
            this.typePlante = EnumTypePlant.ELB;
            this.id = 666;
            this.name = "Error";
            this.description = "Error, using an empty constructor";
            this.imageLink = Game.getDefaultImage();
            this.spriteLinks  = new List<string>();
            this.growthTime = -1;

        }

        public List<string> getSpriteLinks()
        {
            return spriteLinks;
        }

        public int getGrowthTime()
        {
            return growthTime;
        }
    }

}
