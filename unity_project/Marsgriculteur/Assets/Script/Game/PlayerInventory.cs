using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

namespace game{
    public class PlayerInventory : MonoBehaviour{

        public Inventory inventory;
        //on cree un dictionnaire avec des items pour le joueur
        //ceci sera utilise dans inventory.cs pour afficher l'inventory du joueur
        public Dictionary<BasicItem, int> dicoPossessions = new Dictionary<BasicItem, int>();
        public List<int> listIDS = new List<int>();


        void Start(){
            dicoPossessions.Add(CreateAllSeedPlant.dicoPlant.createSeed(EnumTypePlant.ELB),1000);
            /* dicoPossessions.Add(CreateAllSeedPlant.dicoPlant.createSeed(EnumTypePlant.ELB),5);
            dicoPossessions.Add(CreateAllSeedPlant.dicoPlant.createSeed(EnumTypePlant.ELB),100); */
            
            inventory.afficheInventory(dicoPossessions);

        }
        
        
        public Dictionary<BasicItem,int> getInventory(){

            return this.dicoPossessions;
        }

        //permet d'ajouter un slot au dictionnaire
        public void addToInventory(BasicItem item, int qtt){
            bool trouve=false;

            if(qtt<1)
                return;
            else{
                //on parcourt chaque key pour acceder a son getId()
                foreach(BasicItem kvp in dicoPossessions.Keys.ToList()){
                    if(kvp.getId()==item.getId()){
                        dicoPossessions[kvp] += qtt;
                        trouve=true;
                        break;
                    }
                }
                //si on le trouve pas on l'ajoute a notre 
                if(!trouve){
                    dicoPossessions.Add(item,qtt);
                }
            }

            inventory.afficheInventory(dicoPossessions);

        }

        //removes an item instantly
        public void removeFromInventory(BasicItem item){
            foreach(BasicItem kvp in dicoPossessions.Keys.ToList()){
                if(kvp.getId()==item.getId()){
                    dicoPossessions.Remove(kvp);
                    break;
                }
            }

            inventory.afficheInventory(dicoPossessions);
        }

        //permet de soustraire une qtt a un item qui se trouve deja dans notre inventory 
        //ou l'elilminer completement
        public void SubstractFromInventory(BasicItem item, int qttToRemove){
            if(qttToRemove<1)
                return;
            else{
                foreach(BasicItem kvp in dicoPossessions.Keys.ToList()){
                    if(kvp.getId()==item.getId()){
                        if(dicoPossessions[kvp] > qttToRemove)
                            dicoPossessions[kvp] -= qttToRemove;
                        else
                            dicoPossessions.Remove(kvp);
                        
                        break;
                    }
                }
            }

            inventory.afficheInventory(dicoPossessions);

        }
    }
}