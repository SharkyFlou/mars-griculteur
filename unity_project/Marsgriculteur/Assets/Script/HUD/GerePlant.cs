using UnityEngine;
using game;


public class GerePlant : MonoBehaviour
{
    public Inventory inventoryFunctions;
    public PlotEvents StockedPlot;

    private BasicItem stockedItem;
    private int stockedQtt;

    /// <summary>
    /// La méthode <c>getStockedItem</c> retourne le BasicItem stockedItem.
    /// </summary>
    /// <returns>le BasicItem stockedItem</returns>
    public BasicItem getStockedItem()
    {
        return this.stockedItem;
    }

    /// <summary>
    /// La méthode <c>getStockedQtt</c> retourne stockedQtt.
    /// </summary>
    /// <returns>System.Int32. : stockedQtt </returns>
    public int getStockedQtt()
    {
        return this.stockedQtt;
    }


}
