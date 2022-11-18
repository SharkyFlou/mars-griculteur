using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace game
{
    public class Shop : Inventory
    {
        
        public Shop()
        {
            this.slots.Add(CreateAllSeedPlant.dicoPlant.createSeed(EnumTypePlant.ELB), 999);
            this.slots.Add(CreateAllSeedPlant.dicoPlant.createSeed(EnumTypePlant.EGRO), 999);
            this.slots.Add(CreateAllSeedPlant.dicoPlant.createSeed(EnumTypePlant.AJOS), 999);
            this.slots.Add(CreateAllSeedPlant.dicoPlant.createSeed(EnumTypePlant.AZLOC), 999);/*
            this.slots.Add(CreateAllSeedPlant.dicoPlant.createSeed(EnumTypePlant.ECHAV), 999);
            this.slots.Add(CreateAllSeedPlant.dicoPlant.createSeed(EnumTypePlant.ONTOUM), 999);
            this.slots.Add(CreateAllSeedPlant.dicoPlant.createSeed(EnumTypePlant.ELUOP), 999);
            this.slots.Add(CreateAllSeedPlant.dicoPlant.createSeed(EnumTypePlant.NIPAL), 999);*/
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
