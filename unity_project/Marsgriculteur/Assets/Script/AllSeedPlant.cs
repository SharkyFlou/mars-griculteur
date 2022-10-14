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
            Plant pl = new Plant();
            return pl;
        }

        public Seed createSeed(EnumTypePlant typePlant)
        {
            Seed pl = new Seed();
            return pl;
        }

        public PlantedPlant createPlantedPlant(EnumTypePlant typePlant)
        {
            PlantedPlant pl = new PlantedPlant();
            return pl;
        }

        public List<EnumTypePlant> getAllPlantType()
        {
            List<EnumTypePlant> liste = new List<EnumTypePlant>();
            return liste;
        }



        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}
