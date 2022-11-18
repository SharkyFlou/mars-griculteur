using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlite : MonoBehaviour
{
    public Sprite sprite_highlight;
    public Sprite sprite;

    void OnMouseOver()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = sprite_highlight;
    }

    void OnMouseExit()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
    }
}
