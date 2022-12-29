using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// La classe <c>OpenCanvas</c> décide d'ouvrir le canvas ou non (utile pour le magasin par exemple)
/// Elle possède les attributs suivant : thingsToHide, thingsToShow, cam, camZoom, isShown, PanelPlotPlant.
/// </summary>
public class OpenCanvas : MonoBehaviour
{
    public Transform[] thingsToHide;
    public Transform[] thingsToShow;
    public CameraMovement cam;
    public Zoom camZoom;
    private bool isShown = true;

    //connait le panel plot plant pour nettoyer a chaque lancement son affichage
    public GameObject PanelPlotPlant;

    /// <summary>
    /// La méthode <c>inverseAffichage</c> permet d'afficher le canvas et de fermer ceux qu'on ne veut pas. De plus la caméra est bloquée.
    /// </summary>
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

    /// <summary>
    /// La méthode <c>displayCanvasON</c> 
    /// </summary>
    /// <param name="trans"></param>
    /// <param name="state"></param>
    private void displayCanvasON(Transform[] trans, bool state)
    {
        foreach (Transform t in trans)
        {
            t.GameObject().SetActive(state);
        }
    }
}
