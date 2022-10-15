using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopEvents : MonoBehaviour
{
    public Sprite shop_sprite_highlight;
    public Sprite shop_sprite;
    void OnMouseDown()
    {

    }

    void OnMouseOver()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = shop_sprite_highlight;
    }

    void OnMouseExit()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = shop_sprite;
    }
}
