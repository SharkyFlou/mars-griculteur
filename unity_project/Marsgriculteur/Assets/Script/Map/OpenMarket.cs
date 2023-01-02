using System;
using UnityEngine;
using UnityEngine.EventSystems;
using game;

/// <summary>
/// La classe <c>OpenMarket</c> permet d'afficher le market et mettre à jour le graphe.
/// Elle possède 4 attributs : canvas, graphContainer, openCanvasMarket, reafficheInvOnClickMarket.
/// </summary>
public class OpenMarket : MonoBehaviour
{
    public Canvas canvas;
    public Transform graphContainer;
    public OpenCanvas openCanvasMarket;
    public InventoryPanel reafficheInvOnClickMarket;
    public SellScript sellScript;

    /// <summary>
    /// La méthode <c>OnMouseDown</c> permet, lors du click, d'afficher le stand, et l'inventaire.
    /// </summary>
    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject()) //if the mouse is on a UI element
        {
            return;
        }

        openCanvasMarket.inverseAffichage();
        sellScript.valueChanged();
        try
        {
            graphContainer.SendMessage("affiche");
        }
        catch (Exception e)
        { //THIS NEVER RUNS :/
            Debug.LogError("mmmh" + e.Message);
        }

        reafficheInvOnClickMarket.Start();
    }
}
