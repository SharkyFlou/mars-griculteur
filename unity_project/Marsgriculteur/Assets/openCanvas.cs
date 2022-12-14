using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using game;

public class openCanvas : MonoBehaviour
{
    public Transform[] thingsToHide;
    public Transform[] thingsToShow;
    public CameraMovement cam;
    public Zoom camZoom;
    private bool isShown = true;

    //connait le panel plot plant pour nettoyer a chaque lancement son affichage
    public GameObject PanelPlotPlant;

    public void inverseAffichage()
    {
        //PanelPlotPlant.GetComponent<GerePlant>().cleanAffichage();

        displayCanvasON(thingsToShow, isShown);
        displayCanvasON(thingsToHide, !isShown);
        cam.playerCanMoove(!isShown); //block the cam when displaying
        camZoom.playerCanZoom(!isShown); //block the cam when displaying
        isShown = !isShown;


        //PlotSupervisor.GetComponent<GerePlant>().StockedPlot = this.gameObject.GetComponent<PlotEvents>();

    }

    private void displayCanvasON(Transform[] trans, bool state)
    {
        foreach (Transform t in trans)
        {
            t.GameObject().SetActive(state);
        }
    }
}
