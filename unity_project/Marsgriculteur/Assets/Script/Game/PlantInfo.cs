using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Newtonsoft.Json;
using System.Linq;

namespace game
{
    /// <summary>
    /// La classe <c>PlantInfo</c> permet de créer une plante (en général) avec toutes ses informations.
    /// Elle possède les attributs suivant : id, namePlant, description, growthTime, seedSpriteLink, plantSpriteLink, plantedPlantSprite,
    /// seeWeight, plantWeight, basicSeedPrice, basicPlantPrice, nbPlantCollect.
    /// </summary>
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
        private int nbPlantCollect;

        /// <summary>
        /// Le constructeur <c>PlantInfo</c> permet de créer une plante à partir du JSON
        /// </summary>
        /// <param name="id">l'id de la plante</param>
        /// <param name="namePlant">le nom de la plante</param>
        /// <param name="description">la description de la plante</param>
        /// <param name="growthTime">le temps de pousse de la plante</param>
        /// <param name="SeedSpriteLink">l'image de la graine de la plante</param>
        /// <param name="PlantSpriteLink">l'image de la plante qui sera vendu</param>
        /// <param name="PlantedPlantSpriteLink">l'imagede la plante qui sera à mettre dans son champs</param>
        /// <param name="seedWeight">le poids de la graine</param>
        /// <param name="plantWeight">le poids de la plante</param>
        /// <param name="basicSeedPrice">le prix de la graine</param>
        /// <param name="basicPlantPrice">le prix de la plante</param>
        [JsonConstructor]
        public PlantInfo(int id, EnumTypePlant namePlant, string description, int growthTime, string SeedSpriteLink, string PlantSpriteLink, string PlantedPlantSpriteLink, int seedWeight, int plantWeight, int basicSeedPrice, List<int> basicPlantPrice, int nbPlantCollect)
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
            this.nbPlantCollect = nbPlantCollect;
        }

        /// <summary>
        /// La méthode <c>getId</c> permet d'obtenir l'id de la plante
        /// </summary>
        /// <returns>Elle retourne son ID</returns>
        public int getId()
        {
            return this.id;
        }

        /// <summary>
        /// La méthode <c>getEnum</c> permet d'obtenir le type de la plante
        /// </summary>
        /// <returns>Elle retourne son type</returns>
        public EnumTypePlant getEnum()
        {
            return this.namePlant;
        }

        /// <summary>
        /// La méthode <c>getDesc</c> permet d'obtenir la description de la plante
        /// </summary>
        /// <returns>Elle retourne sa description</returns>
        public string getDesc()
        {
            return this.description;
        }

        /// <summary>
        /// La méthode <c>getGrowth</c> permet d'obtenir le temps de pousse de la plante
        /// </summary>
        /// <returns>Elle retourne son temps de pousse</returns>
        public int getGrowth()
        {
            return this.growthTime;
        }

        /// <summary>
        /// La méthode <c>getSeedSprite</c> permet d'obtenir l'image de la graine
        /// </summary>
        /// <returns>Elle retourne l'image de la graine correspondant à la plante</returns>
        public Sprite getSeedSprite()
        {
            return this.seedSpriteLink;
        }

        /// <summary>
        /// La méthode <c>getPlantSprite</c> permet d'obtenir l'image de la plante à vendre
        /// </summary>
        /// <returns>Elle retourne l'image de la plante à vendre</returns>
        public Sprite getPlantSprite()
        {
            return this.plantSpriteLink;
        }

        /// <summary>
        /// La méthode <c>getPlantedPlantSprites</c> permet d'obtenir les images de la plante lorsqu'elle pousse
        /// </summary>
        /// <returns>Elle retourne la liste des images</returns>
        public List<Sprite> getPlantedPlantSprites()
        {
            return this.plantedPlantSpriteLink;
        }

        /// <summary>
        /// La méthode <c>getSeedWeight</c> permet d'obtenir le poids de la graine correspondant à la plante
        /// </summary>
        /// <returns>Elle retourne le poids de la graine</returns>
        public int getSeedWeight()
        {
            return this.seedWeight;
        }

        /// <summary>
        /// La méthode <c>getPlantWeight</c> permet d'obtenir le poids de la plante
        /// </summary>
        /// <returns>Elle retourne le poids de la plante</returns>
        public int getPlantWeight()
        {
            return this.plantWeight;
        }

        /// <summary>
        /// La méthode <c>getSeedPrice</c> permet d'obtenir le prix de la graine
        /// </summary>
        /// <returns>Elle retourne le prix de sa graine</returns>
        public int getSeedPrice()
        {
            return this.basicSeedPrice;
        }

        /// <summary>
        /// La méthode <c>getPlantPrice</c> permet d'obtenir le prix de la plante
        /// </summary>
        /// <returns>Elle retourne le prix de la plante</returns>
        public List<int> getPlantPrice()
        {
            return this.basicPlantPrice;
        }

        /// <summary>
        /// La méthode <c>getNbCollect</c> permet de connaître la quantité de plante collectée après la pousse.
        /// </summary>
        /// <returns>Elle retourne la quantité de plante collectée</returns>
        public int getNbCollect()
        {
            return nbPlantCollect;
        }

    }

    
}

