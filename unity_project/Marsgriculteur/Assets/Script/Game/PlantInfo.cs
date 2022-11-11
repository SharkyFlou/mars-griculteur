using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace game
{
    [System.Serializable]
    public class PlantInfo
    {
        public int id;
        public EnumTypePlant namePlant;
        public string description;
        public int growthTime;
        public Sprite seedSpriteLink;
        public Sprite plantSpriteLink;
        public List<Sprite> plantedPlantSpriteLink;
        public int seedWeight;
        public int plantWeight;
        public int basicSeedPrice;
        public List<int> basicPlantPrice;
    }

}

