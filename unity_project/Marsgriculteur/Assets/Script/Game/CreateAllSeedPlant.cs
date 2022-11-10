using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

namespace game{
    public class CreateAllSeedPlant : MonoBehaviour
    {
        public TextAsset txtJSON;


        public AllSeedPlant dicoPlant = new AllSeedPlant();
        // Start is called before the first frame update
        void Start()
        {
            dicoPlant = JsonConvert.DeserializeAnonymousType(txtJSON.text, dicoPlant);

            Debug.Log(dicoPlant.ToString());
            /*
            foreach (KeyValuePair<EnumTypePlant, PlantInfo> kvp in dicoPlant.allPlantDico)
            {
                Debug.Log(kvp.Key);
                Debug.Log(kvp.Value.id);
            }*/
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}