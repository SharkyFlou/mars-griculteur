using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Scripting;

namespace game
{
    public class Game : MonoBehaviour
    {

        private Market market;
        private Shop shop;
        private InventoryPlant inventoryPlant;
        private InventorySeed inventorySeed;
        public int money;

        public void startGame()
        {
            money = 1000;
        }

        public void endGame()
        {

        }

        private void sellItems()
        {

        }

        private void eachMonth()
        {

        }

        private void displayNotification()
        {

        }

        public static Sprite getDefaultSprite()
        {
            Sprite newSprite = Resources.Load<Sprite>("Sprites/bg_of_bg");
            return newSprite;
        }
    }

}

