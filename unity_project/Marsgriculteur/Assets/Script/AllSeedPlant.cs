using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace game
{
    public class AllSeedPlant
    {
        private Dictionary<EnumTypePlant, PlantInfo> allPlantDico = new Dictionary<EnumTypePlant, PlantInfo>();

        public Plant createPlant(EnumTypePlant typePlant)
        {
            //EnumTypePlant typePlante;
            if (allPlantDico.ContainsKey(typePlant))
            {
                Plant pl = new Plant(typePlant,
                    allPlantDico[typePlant].id+100,
                    typePlant.ToString(),
                    allPlantDico[typePlant].description,
                    allPlantDico[typePlant].plantSpriteLink,
                    allPlantDico[typePlant].basicPlantPrice,
                    allPlantDico[typePlant].plantWeight);
                return pl;
            }
            else
            {
                return new Plant();
            }
        }

        public Seed createSeed(EnumTypePlant typePlant)
        {
            if (allPlantDico.ContainsKey(typePlant))
            {
                Seed pl = new Seed(typePlant,
                    allPlantDico[typePlant].id,
                    typePlant.ToString(),
                    allPlantDico[typePlant].description,
                    allPlantDico[typePlant].seedSpriteLink,
                    allPlantDico[typePlant].growthTime,
                    allPlantDico[typePlant].seedWeight,
                    allPlantDico[typePlant].basicSeedPrice);
                return pl;
            }
            else
            {
                return new Seed();
            }
        }
        public PlantedPlant createPlantedPlant(EnumTypePlant typePlant)
        {
            if (allPlantDico.ContainsKey(typePlant))
            {
                PlantedPlant pl = new PlantedPlant(typePlant, 
                    allPlantDico[typePlant].id+200,
                    typePlant.ToString(),
                    allPlantDico[typePlant].description,
                    allPlantDico[typePlant].plantSpriteLink,
                    allPlantDico[typePlant].plantedPlantSpriteLink,
                    allPlantDico[typePlant].growthTime);
                return pl;
            }
            else
            {
                return new PlantedPlant();
            }
        }

        public List<EnumTypePlant> getAllPlantType()
        {
            List< EnumTypePlant> listPl =  new List<EnumTypePlant>();
            foreach(EnumTypePlant typePl in allPlantDico.Keys)
            {
                listPl.Add(typePl);
            }
            
            return listPl;
        }
    }

}
