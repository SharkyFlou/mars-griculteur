using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

namespace game{
    public class CreateAllSeedPlant : MonoBehaviour
    {
        public TextAsset txtJSON;


        public static AllSeedPlant dicoPlant;
        // Start is called before the first frame update
        void Awake()
        {
            dicoPlant = JsonConvert.DeserializeObject<AllSeedPlant>(txtJSON.text);

            Debug.Log(dicoPlant.ToString());
            /*
            foreach (KeyValuePair<EnumTypePlant, PlantInfo> kvp in dicoPlant.allPlantDico)
            {
                Debug.Log(kvp.Key);
                Debug.Log(kvp.Value.id);
            }*/
        }
    }
}
