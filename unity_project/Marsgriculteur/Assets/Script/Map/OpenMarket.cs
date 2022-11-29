using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMarket : MonoBehaviour
{
    public Canvas canvas;
    public Transform graphContainer;
    private void OnMouseDown()
    {
        canvas.gameObject.SetActive(true);
        try
        {
            graphContainer.SendMessage("affiche");
        }
        catch (Exception e) { //THIS NEVER RUNS :/
            Debug.LogError("mmmh"+e.Message);
        }
    }
}
