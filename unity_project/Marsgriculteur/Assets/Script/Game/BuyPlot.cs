using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyPlot : MonoBehaviour
{

    private PlotEvents plot;
    public game.Game money;
    public game.PopUp popUp;
    
 
    public void open(PlotEvents plo)
    {
        setPlot(plo);
        this.transform.parent.Find("openCloseBuyPlot").GetComponent<OpenCanvas>().inverseAffichage();
    }

    public void setPlot(PlotEvents plo)
    {
        plot = plo;
    }

    public void buyPlot()
    {
        if (money.money >= 1500)
        {
            money.SubsMoney(1500);
            plot.setPlotActive();
        }
        else
        {
            popUp.message("Vous n'avez pas assez d'argent pour débloquer un Plot.");
            //StartCoroutine(popUp.message("Vous n'avez pas assez d'argent pour débloquer un Plot."));
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
