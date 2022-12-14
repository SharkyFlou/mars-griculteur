using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// La classe <c>Highlite</c> permet de surligner les items quand la souris les survole.
/// </summary>
public class Highlite : MonoBehaviour
{
    public Sprite sprite_highlight;
    public Sprite sprite;

    /// <summary>
    /// La méthode <c>OnMouseOver</c> permet de surligner l'item quand la souris le survole.
    /// </summary>
    void OnMouseOver()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
            return;
        }
        this.gameObject.GetComponent<SpriteRenderer>().sprite = sprite_highlight;
    }

    /// <summary>
    /// La méthode <c>OnMouseExit</c> permet de ne plus surligner l'item quand la souris ne survole plus l'item
    /// </summary>
    void OnMouseExit()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
    }
}
