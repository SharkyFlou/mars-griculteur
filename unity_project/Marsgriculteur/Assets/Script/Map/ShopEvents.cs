using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace game
{
    public class ShopEvents : MonoBehaviour
    {
        public InventoryPanel shop;
        void OnMouseUp()
        {
            shop.OpenPanel();
        }


    }
}