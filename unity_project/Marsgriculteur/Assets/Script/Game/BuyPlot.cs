using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyPlot : MonoBehaviour
{

    private PlotEvents plot;
    public game.Game money;
    
 
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
        money.SubsMoney(1500);
        plot.setPlotActive();
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
