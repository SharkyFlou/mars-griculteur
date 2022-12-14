using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using game;

/// <summary>
/// La classe <c>OpenMarket</c> permet d'afficher le market et mettre à jour le graphe
/// </summary>
public class OpenMarket : MonoBehaviour
{
    public Canvas canvas;
    public Transform graphContainer;
    public OpenCanvas openCanvasMarket;
    public ActivePanel reafficheInvOnClickMarket;

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject()) //if the mouse is on a UI element
        {
            return;
        }

        openCanvasMarket.inverseAffichage();
        try
        {
            graphContainer.SendMessage("affiche");
        }
        catch (Exception e)
        { //THIS NEVER RUNS :/
            Debug.LogError("mmmh" + e.Message);
        }

        reafficheInvOnClickMarket.Affiche();
    }
}
