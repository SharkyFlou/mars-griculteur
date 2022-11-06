using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace game
{
    public class Shop : Inventory
    {
        private Dictionary<BasicItem, int> stock = new Dictionary<BasicItem, int>();

        public void getAllPrice()
        {
            foreach (KeyValuePair<BasicItem, int> st in stock)
            {
                Console.WriteLine("BasicItem: {0}, prix: {1}", st.Key, st.Value);
            }
        }
    }

}
