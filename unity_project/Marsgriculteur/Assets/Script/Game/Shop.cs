using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace game
{
    /// <summary>
    /// La classe <c>Shop</c> permet de cr�er un magasin avec toutes les graines qu'on peut acheter.
    /// Elle poss�de un attribut inventory et un dictionnaire qui contient tous les item du magasin.
    /// </summary>
    public class Shop : MonoBehaviour
    {

        public Inventory inventory;
        // Magasin de vente de graines
        // C'est un inventaire � haute quantit� qui ne peut pas �tre r�duit
        public Dictionary<BasicItem, int> slots = new Dictionary<BasicItem, int>();

        /// <summary>
        /// Ce constructeur est l� pour la compilation
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
        /// La m�thode <c>Start</c> est utilis�e pour le d�marrage. �tant donn� que Start n'est appel�e qu'une seule fois, elle permet d'initialiser les �l�ments
        /// qui doivent persister tout au long de la vie du script, mais ne doivent �tre configur�s qu'imm�diatement avant utilisation.
        /// Pour notre cas elle initialise le magasin.
        /// </summary>
        void Start()
        {
            //Debug.Log("Shop pr�sent au clique");
            /* this.slots.Add(CreateAllSeedPlant.dicoPlant.createSeed(EnumTypePlant.ELB), 999);
            this.slots.Add(CreateAllSeedPlant.dicoPlant.createSeed(EnumTypePlant.EGRO), 999);
            this.slots.Add(CreateAllSeedPlant.dicoPlant.createSeed(EnumTypePlant.AJOS), 999);
            this.slots.Add(CreateAllSeedPlant.dicoPlant.createSeed(EnumTypePlant.AZLOC), 999); */
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
