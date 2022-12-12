using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace game
{
    /// <summary>
    /// La classe <c>AllPlot</c> permet cr�er des champs et de tous les r�cup�rer.
    /// Elle comporte 2 m�thodes : <c>createPlot</c> et <c>getAllPlot</c>
    /// </summary>
    public class AllPlot
    {
        /// <summary>
        /// La m�thode <c>createPlot</c> permet de cr�er des champs.
        /// </summary>
        /// <param name="typePlot"></param>
        /// <param name="currentPlant"></param>
        /// <returns></returns>
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