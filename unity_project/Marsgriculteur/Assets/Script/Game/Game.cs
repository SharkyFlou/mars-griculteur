using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Scripting;
using UnityEngine.UI;
using TMPro;

namespace game
{
    /// <summary>
    /// La classe <c>Game</c> s'occupe du jeu en lui-même. Il permet d'initialiser la partie, avec un montant fixe, le nombre de jour à 0, ...
    /// Elle possède les attributs suivant :  market, shop, inventoryPlant, money, moneyText, classePopup.
    /// Elle contient 6 méthodes : Start, getDefaultSprite, AddMoney, SubsMoney, testObjective, endGame.
    /// </summary>
    public class Game : MonoBehaviour
    {

        private Market market;
        private Shop shop;
        private InventoryPlant inventoryPlant;
        public int money;
        public static int moneyObjective;
        private int totalMoneyEarned;
        public TextMeshProUGUI moneyText;

        public PopUp classePopup;

        /// <summary>
        /// La méthode <c>Start</c> est utilisée pour le démarrage. Etant donné que Start n'est appelée qu'une seule fois, elle permet d'initialiser les éléments
        /// qui doivent persister tout au long de la vie du script, mais ne doivent être configurés qu'immédiatement avant utilisation.
        /// Pour notre cas, elle permet d'initialiser l'argent du joueur et de l'afficher en haut à droite de la fenêtre du jeu.
        /// </summary>
        void Start()
        {
            money = 100000;
            moneyText.SetText(money.ToString());
            Debug.Log("Objectif : " + moneyObjective.ToString());
        }

        /// <summary>
        /// La méthode static <c>getDefaultSprite</c> permet de donner une image par défaut à un objet.
        /// </summary>
        /// <returns>Elle retourne une image de type Sprite</returns>
        public static Sprite getDefaultSprite()
        {
            Sprite newSprite = Resources.Load<Sprite>("Sprites/bg_of_bg");
            return newSprite;
        }

        /// <summary>
        /// La méthode <c>AddMoney</c> permet d'ajouter de l'argent au joueur.
        /// </summary>
        /// <param name="price">Le prix a ajouter</param>
        public void AddMoney(int price)
        {
            money += price;
            totalMoneyEarned += price;
            moneyText.SetText(money.ToString());
        }

        /// <summary>
        /// La méthode <c>SubsMoney</c> permet d'enlever de l'argent au joueur.
        /// </summary>
        /// <param name="price">Le prix a soustraire</param>
        public void SubsMoney(int price)
        {
            if ((money - price) >= 0)
            {
                money -= price;
                moneyText.SetText(money.ToString());
            }
            if (money == 0)
            {
                classePopup.message("Vous n'avez plus d'argent!");
            }
            Debug.Log(money);


        }

        /// <summary>
        /// La méthode <c>testObjective</c> permet de vérifier si l'objectif d'argent est atteint et d'appeler la fin du jeu.
        /// </summary>
        public void testObjective()
        {
            if (money >= moneyObjective)
                endGame();
        }

        /// <summary>
        /// La méthode <c>endGame</c> permet d'afficher la fin du jeu quand on clique sur "dormir"
        /// </summary>
        public void endGame()
        {
            GameStats.qttMoney = totalMoneyEarned.ToString();
            GameStats.nbDay = GameObject.Find("bed_sprite").GetComponent<NextDay>().getNbJour().ToString();
            SceneManager.LoadScene("ResultScreen");
        }

    }

}

