using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace game
{
    public class PlantedPlant : BasicPlant
    {
        private List<Sprite> spriteLinks;
        private int growthTime;
        private EnumTypePlant typePlant;

        public PlantedPlant(EnumTypePlant paraTypePlant, int paraGrowthTime)
        {
            this.typePlant = paraTypePlant;
            this.growthTime = paraGrowthTime;
        }

        public PlantedPlant(EnumTypePlant paraTypePlant, int paraId, string paraName, string paraDescription, Sprite paraImagelink, List<Sprite> paraSpriteLinks, int paraGrowthTime)
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
            this.imageLink = Game.getDefaultSprite();
            this.spriteLinks  = new List<Sprite>();
            this.growthTime = -1;

        }

        public List<Sprite> getSpriteLinks()
        {
            return spriteLinks;
        }

        public int getGrowthTime()
        {
            return growthTime;
        }
    }

}
