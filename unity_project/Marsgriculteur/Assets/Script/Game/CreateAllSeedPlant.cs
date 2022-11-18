using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

namespace game{
    public class CreateAllSeedPlant : MonoBehaviour
    {
        public TextAsset JSONSeedPlant;

        public static AllSeedPlant dicoPlant;

        public static Shop shopInventory;
        // Start is called before the first frame update
        void Awake()
        {
            dicoPlant = JsonConvert.DeserializeObject<AllSeedPlant>(JSONSeedPlant.text);

            shopInventory = new Shop();

            Debug.Log(dicoPlant.ToString());
            Debug.Log(shopInventory.toString());
            /*
            foreach (KeyValuePair<EnumTypePlant, PlantInfo> kvp in dicoPlant.allPlantDico)
            {
                Debug.Log(kvp.Key);
                Debug.Log(kvp.Value.id);
            }*/
        }
    }
}
