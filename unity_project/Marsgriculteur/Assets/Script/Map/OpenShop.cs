using UnityEngine;
using UnityEngine.EventSystems;
using game;

/// <summary>
/// La classe <c>OpenShop</c> permet d'ouvrir le panel shop, quand on clique sur la "maison" du shop.
/// Elle possède 3 attributs : canvas, openCanvasShop et shop.
/// </summary>
public class OpenShop : MonoBehaviour
{
    public Canvas canvas;
    public OpenCanvas openCanvasShop;
    public InventoryPanel shop;

    /// <summary>
    /// La méthode <c>OnMouseDown</c> permet l'affichage du shop, quand on clique dessus.
    /// </summary>
    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject()) //si la souris est sur un élément UI
        {
            return;
        }

        openCanvasShop.inverseAffichage();
        shop.Start();
    }
}
