using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Inventory : MonoBehaviour
{
    private int weightMax;
    private Dictionary<object, int> slots;
    public void getInfoSlot();
}
