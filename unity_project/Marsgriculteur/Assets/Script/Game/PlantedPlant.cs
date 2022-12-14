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
        private int nbPlantCollect;

        public PlantedPlant(EnumTypePlant paraTypePlant, int paraGrowthTime)
        {
            this.typePlant = paraTypePlant;
            this.growthTime = paraGrowthTime;
        }

        public PlantedPlant(EnumTypePlant paraTypePlant, int paraId, string paraName, string paraDescription, Sprite paraImagelink, List<Sprite> paraSpriteLinks, int paraGrowthTime, int paraNbCollect)
        {
            this.typePlante = paraTypePlant;
            this.id = paraId;
            this.itemName = paraName;
            this.description = paraDescription;
            this.imageLink = paraImagelink;
            this.spriteLinks = paraSpriteLinks;
            this.growthTime = paraGrowthTime;
            this.nbPlantCollect = paraNbCollect;
        }

        public PlantedPlant()
        {
            this.typePlante = EnumTypePlant.ELB;
            this.id = 666;
            this.itemName = "Error";
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

        public int getNbCollect()
        {
            return nbPlantCollect;
        }
    }


}
