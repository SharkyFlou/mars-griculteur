using System;
using System.Collections.Generic;


namespace game
{
    /// <summary>
    /// La classe <c>Stand</c> permet de vendre les plantes, possède un lien vers le Market, vers l'inventory et vers le game (pour l'argent)
    /// </summary>
    public class Stand
    {
        private InventoryPlant inventory;
        private Game game;

        /// <summary>
        /// La méthode <c>Stand</c> instancie un nouveau Stand
        /// </summary>
        /// <param name="Xmarket">The market.</param>
        /// <param name="Xinventory">The inventory.</param>
        /// <param name="Xgame">The game.</param>
        public Stand(InventoryPlant Xinventory, Game Xgame)
        {
            inventory = Xinventory;
            game = Xgame;
        }

        //item_sell        
        /// <summary>
        /// Permet d'avoir le prix de l'item, son id, et donc de pouvoir le vendre
        /// </summary>
        struct Item
        {
            public EnumTypePlant item_sale { get; set; }
            public int item_number { get; set; }
            public int item_price { get; set; }
        }

        private List<Item> listeItem = new List<Item>();

        //store items for sale        
        /// <summary>
        /// La méthode <c>stock_sale</c> ajoute un item dans la listeItem.
        /// </summary>
        /// <param name="Xitem_sale">The xitem sale.</param>
        /// <param name="Xitem_number">The xitem number.</param>
        /// <param name="Xitem_price">The xitem price.</param>
        public void stock_sale(EnumTypePlant Xitem_sale, int Xitem_number, int Xitem_price)
        {
            Item item = new Item();
            item.item_sale = Xitem_sale;
            item.item_number = Xitem_number;
            item.item_price = Xitem_price;

            listeItem.Add(item);
        }

        //function that when you call it goes around all the stuff on sale and sells it        
        /// <summary>
        /// La méthode <c>sell_stock</c> vend l'item choisit.
        /// </summary>
        /// <returns>System.Int32.</returns>
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
        /// <summary>
        /// La méthode <c>add_price</c> ajoute l'argent au joueur.
        /// </summary>
        /// <param name="price">The price.</param>
        public void add_price(int price)
        {
            game.money += price;
        }
    }
}
