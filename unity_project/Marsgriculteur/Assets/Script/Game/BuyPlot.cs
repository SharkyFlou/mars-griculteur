using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// La classe <c>BuyPlot</c> permet d'acheter des champs.
/// Elle poss�de 3 attributs : plot, money, popUp.
/// </summary>
public class BuyPlot : MonoBehaviour
{
    private PlotEvents plot;
    public game.Game money;
    public game.PopUp popUp;

    /// <summary>
    /// La m�thode <c>open</c> permet d'ouvrir la fen�tre de confirmation pour acheter un champs.
    /// </summary>
    /// <param name="plo">Le champs</param>
    public void open(PlotEvents plo)
    {
        setPlot(plo);
        this.transform.parent.Find("openCloseBuyPlot").GetComponent<OpenCanvas>().inverseAffichage();
    }

    /// <summary>
    /// La m�thode <c>setPlot</c> permet de "set" le champs.
    /// </summary>
    /// <param name="plo">Le champs</param>
    public void setPlot(PlotEvents plo)
    {
        plot = plo;
    }

    /// <summary>
    /// La m�thode <c>buyPlot</c> permet d'acheter un champs.
    /// </summary>
    public void buyPlot()
    {
        if (money.money >= 1500)
        {
            money.SubsMoney(1500);
            plot.setPlotActive();
        }
        else
        {
            popUp.message("Vous n'avez pas assez d'argent pour d�bloquer un Plot.");
        }
    }
}
