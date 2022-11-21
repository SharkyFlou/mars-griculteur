using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using game;

public class MarketBase : MonoBehaviour
{
    // Start is called before the first frame update
    public Market market = new Market();
    void Start()
    {
        market = new Market();
        market.createMarket();
    }
}
