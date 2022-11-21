using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace game
{
    public abstract class BasicItem
    {
        // Classe de tous les objets/item qui sont stockable dans un inventaire
        
        public int id;
        protected string itemName;
        protected string description;
        protected Sprite imageLink;
        protected int weight;

        public BasicItem()
        {

        }

        public BasicItem(int paraId, string paraName, string paraDescription, Sprite paraImageLink){
            id = paraId;
            itemName = paraName;
            description = paraDescription;
            imageLink = paraImageLink;
        }

        public int getWeight()
        {
            return weight;
        }

        public Sprite getSprite()
        {
            return imageLink;
        }

        public string getDesc()
        {
            return description;
        }

        public string getName()
        {
            return itemName;
        }

        public int getId()
        {
            return id;
        }
    }

}
