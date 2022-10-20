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
            Plant pl = new Plant(typePlant, 122, "ba", "ba", "ba");
            return pl;
        }

        public Seed createSeed(EnumTypePlant typePlant)
        {
            Seed pl = new Seed(typePlant, 2, 30, 4);
            return pl;
        }

        public PlantedPlant createPlantedPlant(EnumTypePlant typePlant)
        {
            PlantedPlant pl = new PlantedPlant(typePlant, 3);
            return pl;
        }

        public List<EnumTypePlant> getAllPlantType()
        {
            List<EnumTypePlant> liste = new List<EnumTypePlant>();
            return liste;
        }
    }

}
