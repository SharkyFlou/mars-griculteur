using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Market : MonoBehaviour
{
    private Dictonary<EnumTypePlant, List<Integer>> history = new Dictonary<EnumTypePlant, List<Integer>>();
    private Dictonary<EventInfo, int> intactiveEvents = Dictonary<EventInfo, int>();


    public void initMarket()
    {

    }

    public void nextMonth()
    {

    }

    public Dictonary<EnumTypePlant, List<Integer>> getHistory()
    {
        return history;
    }

    public int getLastPricePlant(plant EnumTypePlant)
    {
        return 0;
    }

    public int getLastPriceSeed(plant EnumTypePlant)
    {
        return 0;
    }

    private void createNewEvent()
    {

    }

    private int nbrSell(plant EnumTypePlant)
    {
        return 0;
    }




    // Start is called before the first frame update
    void Start()
    {
        
    }
    



}

}