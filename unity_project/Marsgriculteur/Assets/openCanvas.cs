using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class openCanvas : MonoBehaviour
{
    public Transform[] thingsToHide;
    public Transform[] thingsToShow;
    public CameraMovement cam;
    public Zoom camZoom;
    private bool isShown = true;


    public void inverseAffichage()
    {
        displayCanvasON(thingsToShow, isShown);
        displayCanvasON(thingsToHide, !isShown);
        cam.playerCanMoove(!isShown); //block the cam when displaying
        camZoom.playerCanZoom(!isShown); //block the cam when displaying
        isShown = !isShown;
    }

    private void displayCanvasON(Transform[] trans, bool state)
    {
        foreach(Transform t in trans)
        {
            t.GameObject().SetActive(state);
        }
    }
}
