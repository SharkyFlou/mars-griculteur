using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace game
{
    public class Shop : MonoBehaviour
    {

        public Inventory inventory;
        // Magasin de vente de graines
        // C'est un inventaire à haute quantité qui ne peut pas être réduit
        public Dictionary<BasicItem, int> slots = new Dictionary<BasicItem, int>();

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
