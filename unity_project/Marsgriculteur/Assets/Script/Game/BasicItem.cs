using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace game
{
    abstract public class BasicItem
    {
        public int id;
        protected string nam;
        protected string description;
        protected Sprite imageLink;
        protected int weight;

        public BasicItem()
        {

        }

        public BasicItem(int paraId, string paraName, string paraDescription, Sprite paraImageLink, int paraWeight){
            this.id = paraId;
            this.nam = paraName;
            this.description = paraDescription;
            this.imageLink = paraImageLink;
            this.weight = paraWeight;
        }

        public Sprite getImageLink()
        {
            return this.imageLink;
        }   

        public string getDescription()
        {
            return this.description;
        }

        public string getName()
        {
            return this.nam;
        }

        public int getWeight(){
            return this.weight;
        }

    }

}
