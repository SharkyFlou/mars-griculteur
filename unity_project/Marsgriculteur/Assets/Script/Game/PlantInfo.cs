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
        private int id;
        private EnumTypePlant namePlant;
        private string description;
        private int growthTime;
        private Sprite seedSpriteLink;
        private Sprite plantSpriteLink;
        private List<Sprite> plantedPlantSpriteLink;
        private int seedWeight;
        private int plantWeight;
        private int basicSeedPrice;
        private List<int> basicPlantPrice;

        // Le contructeur utiliser pour instancier avec un Json
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

        public int getId()
        {
            return this.id;
        }

        public EnumTypePlant getEnum()
        {
            return this.namePlant;
        }

        public string getDesc()
        {
            return this.description;
        }

        public int getGrowth()
        {
            return this.growthTime;
        }

        public Sprite getSeedSprite()
        {
            return this.seedSpriteLink;
        }

        public Sprite getPlantSprite()
        {
            return this.plantSpriteLink;
        }

        public List<Sprite> getPlantedPlantSprites()
        {
            return this.plantedPlantSpriteLink;
        }

        public int getSeedWeight()
        {
            return this.seedWeight;
        }

        public int getPlantWeight()
        {
            return this.plantWeight;
        }

        public int getSeedPrice()
        {
            return this.basicSeedPrice;
        }

        public List<int> getPlantPrice()
        {
            return this.basicPlantPrice;
        }

    }

    
}

