using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

namespace game
{
    [System.Serializable]
    public class Tool : BasicItem
    {
        private int price;


        public Tool(){
        }
        public Tool(int paraPrice, string name, int id, string description, Sprite imageLink){
            this.itemName = name;
            this.id = id;
            this.description = description;
            this.imageLink = imageLink;
            this.price = paraPrice;
        }

        [JsonConstructor]
        public Tool(int paraPrice, string name, int id, string description, string spriteLink)
        {
            this.itemName = name;
            this.id = id;
            this.description = description;
            this.imageLink = Resources.Load<Sprite>("Sprites/" + spriteLink);
            this.price = paraPrice;
        }

        

        public int getPrice()
        {
            return price;
        }
    }

}
