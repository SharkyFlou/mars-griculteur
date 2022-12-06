using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Scripting;
using UnityEngine.UI;
using TMPro;

namespace game
{
    public class Game : MonoBehaviour
    {

        private Market market;
        private Shop shop;
        private InventoryPlant inventoryPlant;
        private InventorySeed inventorySeed;
        public int money;
        public TextMeshProUGUI moneyText;

        void Start()
        {
            money = 5000;
            moneyText.SetText(money.ToString());
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

        public void AddMoney(int price)
        {
            money += price;
            moneyText.SetText(money.ToString());
        }

        public void SubsMoney(int price)
        {
            money -= price;
            moneyText.SetText(money.ToString());
        }
    }

}

