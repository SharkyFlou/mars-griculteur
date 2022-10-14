using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace game
{
    public class PlantInfo
    {
        public EnumTypePlant namePlant;
        public string description;
        public int growthTime;
        public string seedSpriteLink;
        public string plantSpriteLink;
        public List<string> plantedPlantSpriteLink;
        public int seedWeight;
        public int plantWeight;
        public int basicSeedPrice;
        public List<int> basicPlantPrice;
    }
}

