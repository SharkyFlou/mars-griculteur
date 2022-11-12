using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;


namespace game
{
    [System.Serializable]
    public class AllSeedPlant
    {
        public Dictionary<EnumTypePlant, PlantInfo> allPlantDico = new Dictionary<EnumTypePlant, PlantInfo>();

        [JsonConstructor]
        public AllSeedPlant(Dictionary<EnumTypePlant, PlantInfo> dico)
        {
            allPlantDico = dico;
        }

        
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

        override public string ToString()
        {
            string rtrn = string.Empty;
            foreach(KeyValuePair<EnumTypePlant, PlantInfo> kvp in allPlantDico)
            {
                rtrn += kvp.Key + " : \n{";
                rtrn += "\t" + kvp.Value.id.ToString() + "\n";
                rtrn += "\t" + kvp.Value.namePlant + "\n";
                rtrn += "\t" + kvp.Value.description + "\n";
                rtrn += "\t" + kvp.Value.growthTime.ToString() + "\n";
                rtrn += "\t" + kvp.Value.seedSpriteLink.ToString() + "\n";
                rtrn += "\t" + kvp.Value.plantSpriteLink.ToString() + "\n";
                rtrn += "\tListe de sprites :\n\t{\n";
                foreach(Sprite sprt in kvp.Value.plantedPlantSpriteLink)
                {
                    rtrn += "\t\t" + sprt.ToString() + "\n";
                }
                rtrn += "\t}\n";
                //rtrn += "\t" + kvp.Value.plantedPlantSpriteLink.ToString() + "\n";
                rtrn += "\t" + kvp.Value.seedWeight.ToString() + "\n";
                rtrn += "\t" + kvp.Value.plantWeight.ToString() + "\n";
                rtrn += "\t" + kvp.Value.basicSeedPrice.ToString() + "\n";
                rtrn += "\t" + kvp.Value.basicPlantPrice + "\n";
                rtrn += "}";
            }


            return rtrn;
        }

    }

}
