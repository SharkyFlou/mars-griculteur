using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

namespace game{
    public class CreateAllSeedPlant : MonoBehaviour
    {
        public TextAsset JSONSeedPlant;

        public TextAsset JSONTool;

        public static AllSeedPlant dicoPlant;

        public static Shop shopInventory;

        public static AllTools dicoTool;
        // Start is called before the first frame update
        void Awake()
        {
            dicoPlant = JsonConvert.DeserializeObject<AllSeedPlant>(JSONSeedPlant.text);

            shopInventory = new Shop();

            dicoTool = JsonConvert.DeserializeObject<AllTools>(JSONTool.text);
            /*
            Debug.Log(dicoPlant.ToString());
            Debug.Log(dicoTool.ToString());
            Debug.Log(shopInventory.ToString());*/
            /*
            foreach (KeyValuePair<EnumTypePlant, PlantInfo> kvp in dicoPlant.allPlantDico)
            {
                Debug.Log(kvp.Key);
                Debug.Log(kvp.Value.id);
            }*/
        }
    }
}
