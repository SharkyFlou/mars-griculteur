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
    /// La classe <c>Game</c> s'occupe du jeu en lui-m�me. Il permet d'initialiser la partie, avec un montant fixe, le nombre de jour � 0, ...
    /// Elle poss�de les attributs suivant :  market, shop, inventoryPlant, money et moneyText, classePopup
    /// Elle contient 4 m�thodes : Start, getDefaultSprite, AddMoney, SubsMoney.
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
        /// La m�thode <c>Start</c> est utilis�e pour le d�marrage. �tant donn� que Start n'est appel�e qu'une seule fois, elle permet d'initialiser les �l�ments
        /// qui doivent persister tout au long de la vie du script, mais ne doivent �tre configur�s qu'imm�diatement avant utilisation.
        /// Pour notre cas, elle permet d'initialiser l'argent du joueur et de l'afficher en haut � droite de la fen�tre du jeu.
        /// </summary>
        void Start()
        {
            money = 2500;
            moneyText.SetText(money.ToString());
            Debug.Log("Objectif : " + moneyObjective.ToString());
        }

        /// <summary>
        /// La m�thode static <c>getDefaultSprite</c> permet de donner une image par d�faut � un objet.
        /// </summary>
        /// <returns>Elle retourne une image de type Sprite</returns>
        public static Sprite getDefaultSprite()
        {
            Sprite newSprite = Resources.Load<Sprite>("Sprites/bg_of_bg");
            return newSprite;
        }

        /// <summary>
        /// La m�thode <c>AddMoney</c> permet d'ajouter de l'argent au joueur.
        /// </summary>
        /// <param name="price"></param>
        public void AddMoney(int price)
        {
            money += price;
            totalMoneyEarned += price;
            moneyText.SetText(money.ToString());
        }

        /// <summary>
        /// La m�thode <c>SubsMoney</c> permet d'enlever de l'argent au joueur.
        /// </summary>
        /// <param name="price"></param>
        public void SubsMoney(int price)
        {
            if ((money - price) >= 0)
            {
                money -= price;
                moneyText.SetText(money.ToString());
            }
            if (money == 0)
            {
                StartCoroutine(classePopup.message("Vous n'avez plus d'argent!"));
            }
            Debug.Log(money);


        }

        public void testObjective()
        {
            if (money >= moneyObjective)
                endGame();
        }

        public void endGame()
        {
            GameStats.qttMoney = totalMoneyEarned.ToString();
            GameStats.nbDay = GameObject.Find("bed_sprite").GetComponent<NextDay>().getNbJour().ToString();
            SceneManager.LoadScene("ResultScreen");
        }

    }

}

