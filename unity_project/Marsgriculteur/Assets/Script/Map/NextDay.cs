using game;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextDay : MonoBehaviour
{
    public Transform plots;
    List<Transform> plotList; //contient tous les plots pour les faire pousser
    private int nbrJour;
    private Market market;
    private Dictionary<EventInfo, int> activeEvents = new Dictionary<EventInfo, int>();
    private EventInfo newEvent;

    void Start()
    {
        if (plots == null) //pour éviter de planter (ahah "plant")
        {
            return;
        }


        GetPlots(plots);
        nbrJour = 0;

        market = new Market();
        market.createMarket(new AllEvents(), CreateAllSeedPlant.dicoPlant);
    }

    void OnMouseDown()
    {
        faitPousser();
        nbrJour++;

        if (nbrJour % 5 == 0)//si jour%5 == 0 fait vendre les trucs
        {
            newEvent = market.nextMonth(new AllEvents(), nbrJour/5, true, CreateAllSeedPlant.dicoPlant);
            activeEvents = market.getActiveEvents();
        }
    }


        public void faitPousser() //parcours chaque plot, puis appelle leur fonction fairePousser
    {
        foreach (Transform transform in plotList)
        {
            transform.gameObject.SendMessage("fairePousser");
        }   
    }


    private void GetPlots(Transform parent) //recupere les plots
    {
        plotList = new List<Transform>();
        foreach (Transform child in parent)
        {
            plotList.Add(child);
        }
        return;
    }
}
