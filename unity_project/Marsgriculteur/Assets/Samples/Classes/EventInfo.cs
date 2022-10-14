using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventInfo : MonoBehaviour
{
    public string name;
    public string description;
    public int lenght;
    public double mutliplier;
    public bool targetPlant;
    public bool targetSeed;
    public bool targetTool;
    public List<EnumTypePlant> targetsPlant = new List<EnumTypePlant>();
    public List<Tool> targetsTool = new List<Tool>();
    public int probability;
    public int unlockableAfter;
    public string imageLink;
    public int timeBetween;
}
