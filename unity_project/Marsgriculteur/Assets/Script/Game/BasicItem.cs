using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace game
{
    abstract public class BasicItem
    {
        public int id;
        protected string itemName;
        protected string description;
        protected Sprite imageLink;
        protected int weight;

        public BasicItem()
        {

        }

        public BasicItem(int paraId, string paraName, string paraDescription, Sprite paraImageLink){
            this.id = paraId;
            this.itemName = paraName;
            this.description = paraDescription;
            this.imageLink = paraImageLink;
        }

        public int getWeight()
        {
            return this.weight;
        }

        public Sprite getSprite()
        {
            return this.imageLink;
        }   

        public string getDesc()
        {
            return this.description;
        }

        public string getName()
        {
            return this.itemName;
        }

        public int getId()
        {
            return id;
        }
    }

}
