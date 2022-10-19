using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace game
{
    public class PlantedPlant : BasicPlant
    {
        private List<string> spriteLinks = new List<string>();
        private int growthTime;
        private EnumTypePlant typePlant;

        public PlantedPlant(EnumTypePlant paraTypePlant, int paraGrowthTime)
        {
            this.typePlant = paraTypePlant;
            this.growthTime = paraGrowthTime;
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
