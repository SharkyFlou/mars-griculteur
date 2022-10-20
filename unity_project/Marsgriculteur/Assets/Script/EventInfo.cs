using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace game
{
    public class EventInfo
    {
        public string namee;
        public string description;
        public int length;
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

}