using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// La classe <c>Highlite</c> change de sprite lors du survol de la souris.
/// </summary>
public class Highlite : MonoBehaviour
{
    public Sprite sprite_highlight;
    public Sprite sprite;

    /// <summary>
    /// La m�thode <c>OnMouseOver</c> change de sprite lors du survol de la souris.
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
    /// La m�thode <c>OnMouseExit</c> remet le sprite initial lorsque la souris ne survol plus l'�l�ment.
    /// </summary>
    void OnMouseExit()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
    }
}
