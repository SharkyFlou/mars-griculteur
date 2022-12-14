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
            mainInventory.addToInventory(dicoPlant.createSeed(EnumTypePlant.ELB), 10);
            mainInventory.addToInventory(dicoPlant.createSeed(EnumTypePlant.AJOS), 5);
            //mainInventory.addToInventory(dicoPlant.createPlant(EnumTypePlant.AJOS), 100);

            //ceci pose un probleme... pas de partie infinie possible?
            shopInv = new Inventory();
            foreach (EnumTypePlant plante in dicoPlant.getAllPlantType())
            {
                shopInv.addToInventory(dicoPlant.createSeed(plante), 9999);
                shopInv.addToInventory(dicoPlant.createSeed(plante), 9999);
                shopInv.addToInventory(dicoPlant.createSeed(plante), 9999);
                shopInv.addToInventory(dicoPlant.createSeed(plante), 9999);
            }




        }
    }
}
