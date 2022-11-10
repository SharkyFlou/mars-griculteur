using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotEvents : MonoBehaviour
{
    public Sprite plot_sprite_highlight;
    public Sprite plot_sprite;
    void OnMouseDown()
    {
        
    }

    void OnMouseOver()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = plot_sprite_highlight;
    }

    void OnMouseExit()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = plot_sprite;
    }
}
