using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Highlite : MonoBehaviour
{
    public Sprite sprite_highlight;
    public Sprite sprite;

    void OnMouseOver()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
            return;
        }
        this.gameObject.GetComponent<SpriteRenderer>().sprite = sprite_highlight;
    }

    void OnMouseExit()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
    }
}
