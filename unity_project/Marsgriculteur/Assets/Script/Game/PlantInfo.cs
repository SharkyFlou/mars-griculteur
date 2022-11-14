using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Newtonsoft.Json;
using System.Linq;

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


        [JsonConstructor]
        public PlantInfo(int id, EnumTypePlant namePlant, string description, int growthTime, string SeedSpriteLink, string PlantSpriteLink, string PlantedPlantSpriteLink, int seedWeight, int plantWeight, int basicSeedPrice, List<int> basicPlantPrice)
        {
            this.id = id;
            this.namePlant = namePlant;
            this.description = description;
            this.growthTime = growthTime;
            this.seedSpriteLink = Resources.Load<Sprite>("Sprites/" + SeedSpriteLink);
            this.plantSpriteLink = Resources.Load<Sprite>("Sprites/" + PlantSpriteLink);
            this.plantedPlantSpriteLink = Resources.LoadAll("Sprites/" + PlantedPlantSpriteLink, typeof(Sprite)).Cast<Sprite>().ToList();
            this.seedWeight = seedWeight;
            this.plantWeight = plantWeight;
            this.basicSeedPrice = basicSeedPrice;
            this.basicPlantPrice = basicPlantPrice;
        }

    }

    
}

