using System.Collections.Generic;


namespace game
{
    /// <summary>
    /// La classe <c>AllPlot</c> permet créer des champs et de tous les récupérer.
    /// Elle comporte 2 méthodes : <c>createPlot</c> et <c>getAllPlot</c>
    /// </summary>
    public class AllPlot
    {
        /// <summary>
        /// La méthode <c>createPlot</c> permet de créer des champs.
        /// </summary>
        /// <param name="typePlot">le type de champs qui doit être créé</param>
        /// <param name="currentPlant">le type de plante</param>
        /// <returns>Elle retourne le champs créé</returns>
        public Plot createPlot(EnumTypePlot typePlot, EnumTypePlant currentPlant)
        {
            Plot pl = new Plot(typePlot, currentPlant, 2, 200, 4);
            return pl;
        }

        /// <summary>
        /// La méthode <c>getAllPlot</c> permet d'avoir une liste de tous les champs.
        /// </summary>
        /// <returns>Elle retourne la liste de tous les champs</returns>
        public List<EnumTypePlot> getAllPlot()
        {
            List<EnumTypePlot> liste = new List<EnumTypePlot>();
            return liste;
        }
    }

}