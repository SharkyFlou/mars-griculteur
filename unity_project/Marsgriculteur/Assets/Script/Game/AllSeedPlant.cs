using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;


namespace game
{
    [System.Serializable]
    public class AllSeedPlant
    {
        private Dictionary<EnumTypePlant, PlantInfo> allPlantDico = new Dictionary<EnumTypePlant, PlantInfo>();

        [JsonConstructor]
        public AllSeedPlant(Dictionary<EnumTypePlant, PlantInfo> allPlantDico)
        {
            this.allPlantDico = allPlantDico;
        }

        
        public Plant createPlant(EnumTypePlant typePlant)
        {
            //EnumTypePlant typePlante;
            if (allPlantDico.ContainsKey(typePlant))
            {
                Plant pl = new Plant(typePlant,
                    allPlantDico[typePlant].getId()+100,
                    typePlant.ToString(),
                    allPlantDico[typePlant].getDesc(),
                    allPlantDico[typePlant].getPlantSprite(),
                    allPlantDico[typePlant].getPlantPrice(),
                    allPlantDico[typePlant].getPlantWeight());
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
                    allPlantDico[typePlant].getId(),
                    typePlant.ToString(),
                    allPlantDico[typePlant].getDesc(),
                    allPlantDico[typePlant].getSeedSprite(),
                    allPlantDico[typePlant].getGrowth(),
                    allPlantDico[typePlant].getSeedWeight(),
                    allPlantDico[typePlant].getSeedPrice());
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
                    allPlantDico[typePlant].getId()+200,
                    typePlant.ToString(),
                    allPlantDico[typePlant].getDesc(),
                    allPlantDico[typePlant].getPlantSprite(),
                    allPlantDico[typePlant].getPlantedPlantSprites(),
                    allPlantDico[typePlant].getGrowth());
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
            if (allPlantDico.Count == 0)
            {
                Debug.Log("Erreur dico vide ??");
            }
            else
            {
                foreach (EnumTypePlant typePl in allPlantDico.Keys)
                {
                    listPl.Add(typePl);
                }
            }
            
            return listPl;
        }

        override public string ToString()
        {
            string rtrn = string.Empty;
            foreach(KeyValuePair<EnumTypePlant, PlantInfo> kvp in allPlantDico)
            {
                rtrn += kvp.Key + " : \n{";
                rtrn += "\t" + kvp.Value.getId().ToString() + "\n";
                rtrn += "\t" + kvp.Value.getEnum() + "\n";
                rtrn += "\t" + kvp.Value.getDesc() + "\n";
                rtrn += "\t" + kvp.Value.getGrowth().ToString() + "\n";
                rtrn += "\t" + kvp.Value.getSeedSprite().ToString() + "\n";
                rtrn += "\t" + kvp.Value.getPlantSprite().ToString() + "\n";
                rtrn += "\tListe de sprites :\n\t{\n";
                foreach(Sprite sprt in kvp.Value.getPlantedPlantSprites())
                {
                    rtrn += "\t\t" + sprt.ToString() + "\n";
                }
                rtrn += "\t}\n";
                //rtrn += "\t" + kvp.Value.getPlantedPlantSprites().ToString() + "\n";
                rtrn += "\t" + kvp.Value.getSeedWeight().ToString() + "\n";
                rtrn += "\t" + kvp.Value.getPlantWeight().ToString() + "\n";
                rtrn += "\t" + kvp.Value.getSeedPrice().ToString() + "\n";
                rtrn += "\t" + kvp.Value.getPlantPrice() + "\n";
                rtrn += "}";
            }


            return rtrn;
        }

    }

}
