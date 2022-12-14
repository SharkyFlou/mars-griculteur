using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
namespace game
{
    public class OpenShop : MonoBehaviour
    {
        public Canvas canvas;
        public OpenCanvas openCanvasShop;

        public ActivePanel shop;
        private void OnMouseDown()
        {
            if (EventSystem.current.IsPointerOverGameObject()) //if the mouse is on a UI element
            {
                return;
            }

            openCanvasShop.inverseAffichage();
            shop.Affiche();
        }
    }
}
