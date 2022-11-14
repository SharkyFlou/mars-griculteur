using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace game
{
    abstract public class BasicItem : MonoBehaviour
    {
        public int id;
        protected string name;
        protected string description;
        protected Sprite imageLink;

        public BasicItem()
        {

        }

        public BasicItem(int paraId, string paraName, string paraDescription, Sprite paraImageLink){
            this.id = paraId;
            this.name = paraName;
            this.description = paraDescription;
            this.imageLink = paraImageLink;
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
            return this.name;
        }
    }

}
