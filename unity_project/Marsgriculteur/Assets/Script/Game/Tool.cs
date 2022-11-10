using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace game
{
    public class Tool : BasicItem
    {
        private int price;


        public Tool(){
            price = 666;
        }

        public Tool(int paraPrice, string name, int id, string description, Sprite imageLink){
            this.name = name;
            this.id = id;
            this.description = description;
            this.imageLink = imageLink;
            this.price = paraPrice;
        }


        public int getPrice()
        {
            return price;
        }
    }

}
