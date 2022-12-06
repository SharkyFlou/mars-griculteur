using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OpenShop : MonoBehaviour
{
    public Canvas canvas;
    public openCanvas openCanvasShop;
    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject()) //if the mouse is on a UI element
        {
            return;
        }

        openCanvasShop.inverseAffichage();
    }
}
