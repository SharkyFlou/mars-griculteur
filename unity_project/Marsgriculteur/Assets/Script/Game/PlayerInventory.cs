using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace game{
    public class PlayerInventory : MonoBehaviour{

        public Inventory inventory;
        //on cree un dictionnaire avec des items pour le joueur
        //ceci sera utilise dans inventory.cs pour afficher l'inventory du joueur
        public Dictionary<BasicItem, int> dicoPossessions = new Dictionary<BasicItem, int>();

        void Start(){
            dicoPossessions.Add(CreateAllSeedPlant.dicoPlant.createSeed(EnumTypePlant.ELB),10);
            dicoPossessions.Add(CreateAllSeedPlant.dicoPlant.createSeed(EnumTypePlant.ELB),5);
            dicoPossessions.Add(CreateAllSeedPlant.dicoPlant.createSeed(EnumTypePlant.ELB),100);
            
            inventory.WakeUp(dicoPossessions);

        }
        
        
        public Dictionary<BasicItem,int> getInventory(){

            return this.dicoPossessions;
        }




    }
}