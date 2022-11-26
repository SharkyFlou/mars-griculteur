using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using game;

public class marketBase : MonoBehaviour
{
    Market market;
    // Start is called before the first frame update
    void Start()
    {
        market = Market.instance;
    }
}
