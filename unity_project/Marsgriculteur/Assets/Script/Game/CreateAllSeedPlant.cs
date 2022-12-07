using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

namespace game
{
    public class CreateAllSeedPlant : MonoBehaviour
    {
        public TextAsset JSONSeedPlant;

        public TextAsset JSONTool;

        public static Inventory mainInventory;

        public static AllSeedPlant dicoPlant;

        public static AllTools dicoTool;

        public static Inventory shopInv;
        // Start is called before the first frame update
        void Awake()
        {
            dicoPlant = JsonConvert.DeserializeObject<AllSeedPlant>(JSONSeedPlant.text);

            dicoTool = JsonConvert.DeserializeObject<AllTools>(JSONTool.text);

            mainInventory = new Inventory();
            mainInventory.addToInventory(dicoPlant.createPlant(EnumTypePlant.ELB), 10);
            mainInventory.addToInventory(dicoPlant.createSeed(EnumTypePlant.ELB), 100);
            mainInventory.addToInventory(dicoPlant.createSeed(EnumTypePlant.AJOS), 100);
            mainInventory.addToInventory(dicoPlant.createPlant(EnumTypePlant.AJOS), 100);

            shopInv = new Inventory();
            shopInv.addToInventory(dicoPlant.createSeed(EnumTypePlant.ELB), 999);
            shopInv.addToInventory(dicoPlant.createSeed(EnumTypePlant.EGRO), 999);
            shopInv.addToInventory(dicoPlant.createSeed(EnumTypePlant.AJOS), 999);
            shopInv.addToInventory(dicoPlant.createSeed(EnumTypePlant.AZLOC), 999);

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
