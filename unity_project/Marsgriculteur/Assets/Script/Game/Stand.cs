using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace game
{

    public class Stand
    {
        Market market;
        InventoryPlant inventory;
        Game game;

        public Stand(Market Xmarket, InventoryPlant Xinventory, Game Xgame)
        {
            market = Xmarket;
            inventory = Xinventory;
            game = Xgame;
        }
        
        //item_sell
        struct Item
        {
            public EnumTypePlant item_sale { get; set; }
            public int item_number { get; set; }
            public int item_price { get; set; }
        }

        private List<Item> listeItem = new List<Item>();

        //store items for sale
        public void stock_sale(EnumTypePlant Xitem_sale, int Xitem_number, int Xitem_price)
        {
            Item item = new Item();
            item.item_sale = Xitem_sale;
            item.item_number = Xitem_number;
            item.item_price = Xitem_price;

            listeItem.Add(item);
        }

        //function that when you call it goes around all the stuff on sale and sells it
        public int sell_stock()
        {
            int price = 0;
            int number;
            foreach (Item item in listeItem)
            {
                number = item.item_number;
                int nbrSlots = inventory.getNbrSlots(item.item_sale);
                if (nbrSlots >= number){
                    inventory.setNbrSlots(item.item_sale, item.item_number);
                    price = number*item.item_price;
                }
                else{
                    Console.WriteLine("There’s not enough quantity.");
                }
            }
            return price;
        }

        //add price
        public void add_price(int price)
        {
            game.money += price;
        }
    }
}
