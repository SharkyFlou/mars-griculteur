using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

namespace game
{
    /// <summary>
    /// La classe <c>CreateAllSeedPlant</c> permet de créer les plantes et les graines dans les inventaires : inventaire récapitulatif du joueur, et celui dans le shop
    /// Elle possède les attributs suivant : JSONSeedPlant, JSONTool, mainInventory, dicoPlant, dicoTool, shopInv et storageInventory
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

        public static Inventory storageInventory;

        /// <summary>
        /// La méthode <c>Awake</c> est appelée lorsque l'instance de script est en cours de chargement.
        /// Elle permet d'instancier les dictionnaire à partir des fichiers textes, des JSON et elle crée les inventaires.
        /// </summary>
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
            shopInv.addToInventory(dicoPlant.createSeed(EnumTypePlant.ELB), 999);
            shopInv.addToInventory(dicoPlant.createSeed(EnumTypePlant.EGRO), 999);
            shopInv.addToInventory(dicoPlant.createSeed(EnumTypePlant.AJOS), 999);
            shopInv.addToInventory(dicoPlant.createSeed(EnumTypePlant.AZLOC), 999);


            storageInventory = new Inventory();

        }
    }
}
