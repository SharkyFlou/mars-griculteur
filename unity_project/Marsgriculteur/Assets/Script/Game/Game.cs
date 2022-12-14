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
    /// Elle possède les attributs suivant :  market, shop, inventoryPlant, money et moneyText.
    /// Elle contient 4 méthodes : Start, getDefaultSprite, AddMoney, SubsMoney.
    /// </summary>
    public class Game : MonoBehaviour
    {

        private Market market;
        private Shop shop;
        private InventoryPlant inventoryPlant;
        public int money;
        public TextMeshProUGUI moneyText;

        /// <summary>
        /// La méthode <c>Start</c> est utilisée pour le démarrage. Étant donné que Start n'est appelée qu'une seule fois, elle permet d'initialiser les éléments
        /// qui doivent persister tout au long de la vie du script, mais ne doivent être configurés qu'immédiatement avant utilisation.
        /// Pour notre cas, elle permet d'initialiser l'argent du joueur et de l'afficher en haut à droite de la fenêtre du jeu.
        /// </summary>
        void Start()
        {
            money = 5000;
            moneyText.SetText(money.ToString());
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
        /// <param name="price"></param>
        public void AddMoney(int price)
        {
            money += price;
            moneyText.SetText(money.ToString());
        }

        /// <summary>
        /// La méthode <c>SubsMoney</c> permet d'enlever de l'argent au joueur.
        /// </summary>
        /// <param name="price"></param>
        public void SubsMoney(int price)
        {
            money -= price;
            moneyText.SetText(money.ToString());
        }
    }

}

