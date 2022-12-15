using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace game
{
    /// <summary>
    /// La classe <c>OpenShop</c> permet d'ouvrir le panel shop, quand on clique sur la "maison" du shop.
    /// Elle possède 3 attributs : canvas, openCanvasShop et shop.
    /// </summary>
    public class OpenShop : MonoBehaviour
    {
        public Canvas canvas;
        public OpenCanvas openCanvasShop;
        public ActivePanel shop;

        /// <summary>
        /// La méthode <c>OnMouseDown</c> permet l'affichage du shop, quand on clique.
        /// </summary>
        private void OnMouseDown()
        {
            if (EventSystem.current.IsPointerOverGameObject()) //si la souris est sur un élément UI
            {
                return;
            }

            openCanvasShop.inverseAffichage();
            shop.Affiche();
        }
    }
}
