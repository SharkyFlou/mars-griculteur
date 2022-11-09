using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace game
{
    public class AllPlot
    {

        public Plot createPlot(EnumTypePlot typePlot, EnumTypePlant currentPlant)
        {
            Plot pl = new Plot(typePlot, currentPlant, 2, 200, 4);
            return pl;
        }

        public List<EnumTypePlot> getAllPlot()
        {
            List<EnumTypePlot> liste = new List<EnumTypePlot>();
            return liste;
        }
    }

}