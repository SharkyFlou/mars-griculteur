using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace game
{
    /// <summary>
    /// La classe <c>Shop</c> permet de créer un magasin avec toutes les graines qu'on peut acheter.
    /// Elle possède un attribut inventory et un dictionnaire qui contient tous les item du magasin.
    /// </summary>
    public class Shop : MonoBehaviour
    {

        public Inventory inventory;
        // Magasin de vente de graines
        // C'est un inventaire à haute quantité qui ne peut pas être réduit
        public Dictionary<BasicItem, int> slots = new Dictionary<BasicItem, int>();

        /// <summary>
        /// Ce constructeur est là pour la compilation
        /// </summary>
        public Shop()
        {
            /*
            this.slots.Add(CreateAllSeedPlant.dicoPlant.createSeed(EnumTypePlant.ELB), 999);
            this.slots.Add(CreateAllSeedPlant.dicoPlant.createSeed(EnumTypePlant.EGRO), 999);
            this.slots.Add(CreateAllSeedPlant.dicoPlant.createSeed(EnumTypePlant.AJOS), 999);
            this.slots.Add(CreateAllSeedPlant.dicoPlant.createSeed(EnumTypePlant.AZLOC), 999);/*
            this.slots.Add(CreateAllSeedPlant.dicoPlant.createSeed(EnumTypePlant.ECHAV), 999);
            this.slots.Add(CreateAllSeedPlant.dicoPlant.createSeed(EnumTypePlant.ONTOUM), 999);
            this.slots.Add(CreateAllSeedPlant.dicoPlant.createSeed(EnumTypePlant.ELUOP), 999);
            this.slots.Add(CreateAllSeedPlant.dicoPlant.createSeed(EnumTypePlant.NIPAL), 999);*/
        }

        /// <summary>
        /// La méthode <c>Start</c> est utilisée pour le démarrage. Étant donné que Start n'est appelée qu'une seule fois, elle permet d'initialiser les éléments
        /// qui doivent persister tout au long de la vie du script, mais ne doivent être configurés qu'immédiatement avant utilisation.
        /// Pour notre cas elle initialise le magasin.
        /// </summary>
        void Start()
        {
            //Debug.Log("Shop présent au clique");
            this.slots.Add(CreateAllSeedPlant.dicoPlant.createSeed(EnumTypePlant.ELB), 999);
            this.slots.Add(CreateAllSeedPlant.dicoPlant.createSeed(EnumTypePlant.EGRO), 999);
            this.slots.Add(CreateAllSeedPlant.dicoPlant.createSeed(EnumTypePlant.AJOS), 999);
            this.slots.Add(CreateAllSeedPlant.dicoPlant.createSeed(EnumTypePlant.AZLOC), 999);
            //inventory.afficheInventory(slots);
        }

        /*
        public void getAllPrice()
        {
            foreach (KeyValuePair<string, int> st in stock)
            {
                Console.WriteLine("BasicItem: {0}, prix: {1}", st.Key, st.Value);
            }
        }*/



    }

}
