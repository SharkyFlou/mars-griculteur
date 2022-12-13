using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using game;
public class OpenStorage : MonoBehaviour
{
    public Canvas canvas;
    public openCanvas openCanvasStorage;
    public ActivePanel reafficheInvOnClickMarket;

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject()) //if the mouse is on a UI element
        {
            return;
        }
        openCanvasStorage.inverseAffichage();
        reafficheInvOnClickMarket.Affiche();

    }
}
