using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

namespace game
{
    /// <summary>
    /// La classe <c>CreateAllSeedPlant</c> permet de cr�er les plantes et les graines dans les inventaires : inventaire r�capitulatif du joueur, et celui dans le shop
    /// Elle poss�de les attributs suivant : JSONSeedPlant, JSONTool, mainInventory, dicoPlant, dicoTool, shopInv et storageInventory
    /// </summary>
    public class CreateAllSeedPlant : MonoBehaviour
    {
        // Fichier texte descriptif de l'instance dicoplant
        public TextAsset JSONSeedPlant;

        // Fichier texte descriptif de l'instance allTools
        public TextAsset JSONTool;

        public static Inventory mainInventory;

        public static AllSeedPlant dicoPlant;

        public static AllTools dicoTool;

        public static Inventory shopInv;

        /// <summary>
        /// La m�thode <c>Awake</c> est appel�e lorsque l'instance de script est en cours de chargement.
        /// Elle permet d'instancier les dictionnaire � partir des fichiers textes, des JSON et elle cr�e les inventaires.
        /// </summary>
        void Awake()
        {
            dicoPlant = JsonConvert.DeserializeObject<AllSeedPlant>(JSONSeedPlant.text);

            dicoTool = JsonConvert.DeserializeObject<AllTools>(JSONTool.text);

            mainInventory = new Inventory();

            /* mainInventory.addToInventory(dicoPlant.createPlant(EnumTypePlant.ELB), 1);
            mainInventory.addToInventory(dicoPlant.createPlant(EnumTypePlant.AJOS), 1);
            mainInventory.addToInventory(dicoPlant.createPlant(EnumTypePlant.EGRO), 1);
            mainInventory.addToInventory(dicoPlant.createPlant(EnumTypePlant.AZLOC), 1);
            mainInventory.addToInventory(dicoPlant.createPlant(EnumTypePlant.OUNTOUM), 1);
            mainInventory.addToInventory(dicoPlant.createPlant(EnumTypePlant.EHCAV), 1);
            mainInventory.addToInventory(dicoPlant.createPlant(EnumTypePlant.NIPAL), 1);
            mainInventory.addToInventory(dicoPlant.createPlant(EnumTypePlant.ELUOP), 1);

            mainInventory.addToInventory(dicoPlant.createSeed(EnumTypePlant.ELB), 1);
            mainInventory.addToInventory(dicoPlant.createSeed(EnumTypePlant.AJOS), 1);
            mainInventory.addToInventory(dicoPlant.createSeed(EnumTypePlant.EGRO), 1);
            mainInventory.addToInventory(dicoPlant.createSeed(EnumTypePlant.AZLOC), 1);
            mainInventory.addToInventory(dicoPlant.createSeed(EnumTypePlant.OUNTOUM), 1);
            mainInventory.addToInventory(dicoPlant.createSeed(EnumTypePlant.EHCAV), 1);
            mainInventory.addToInventory(dicoPlant.createSeed(EnumTypePlant.NIPAL), 1);
            mainInventory.addToInventory(dicoPlant.createSeed(EnumTypePlant.ELUOP), 1); */


            //mainInventory.addToInventory(dicoPlant.createPlant(EnumTypePlant.AJOS), 100);

            //ceci pose un probleme... pas de partie infinie possible?
            shopInv = new Inventory();
            foreach (EnumTypePlant plante in dicoPlant.getAllPlantType())
            {
                shopInv.addToInventory(dicoPlant.createSeed(plante), 9999);
            }

        }
    }
}
