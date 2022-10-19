using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace game
{
    abstract public class Tool : BasicItem
    {
        private int price;

         public Tool(){
            price = 666;
        }

        public Tool(int paraPrice){
            price = paraPrice;
        }

        public int getPrice()
        {
            return price;
        }

    }

}
