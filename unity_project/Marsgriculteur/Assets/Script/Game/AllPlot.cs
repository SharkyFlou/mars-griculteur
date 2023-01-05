using System.Collections.Generic;


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
        /// <param name="typePlot">le type de champs qui doit �tre cr��</param>
        /// <param name="currentPlant">le type de plante</param>
        /// <returns>Elle retourne le champs cr��</returns>
        public Plot createPlot(EnumTypePlot typePlot, EnumTypePlant currentPlant)
        {
            Plot pl = new Plot(typePlot, currentPlant, 2, 200, 4);
            return pl;
        }

        /// <summary>
        /// La m�thode <c>getAllPlot</c> permet d'avoir une liste de tous les champs.
        /// </summary>
        /// <returns>Elle retourne la liste de tous les champs</returns>
        public List<EnumTypePlot> getAllPlot()
        {
            List<EnumTypePlot> liste = new List<EnumTypePlot>();
            return liste;
        }
    }

}