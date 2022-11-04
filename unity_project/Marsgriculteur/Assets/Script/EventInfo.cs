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
        public List<string> targetsTool = new List<string>();
        public int probability;
        public int unlockableAfter;
        public string imageLink;
        public int timeBetween;


        public EventInfo(string namee,
            string description,
            int lenght,
            double mutliplier,
            bool targetPlant,
            bool targetSeed,
            bool targetTool,
            List<EnumTypePlant> targetsPlant,
            List<string> targetsTool,
            int probability,
            int unlockableAfter,
            string imageLink,
            int timeBetween)
        {
            this.namee = namee;
            this.description = description;
            this.length = lenght;
            this.mutliplier = mutliplier;
            this.targetPlant = targetPlant;
            this.targetSeed = targetSeed;
            this.targetTool = targetTool;
            this.targetsPlant = targetsPlant;
            this.targetsTool = targetsTool;
            this.probability = probability;
            this.unlockableAfter = unlockableAfter;
            this.imageLink = imageLink;
            this.timeBetween = timeBetween;
        }

        public EventInfo()
        {
            this.namee = "Error";
            this.description = "Error, using an empty constructor";
            this.length = -1;
            this.mutliplier = -1;
            this.targetPlant = false;
            this.targetSeed = false;
            this.targetTool = false;
            this.targetsPlant = new List<EnumTypePlant>();
            this.targetsTool = new List<string>();
            this.probability = -1;
            this.unlockableAfter = -1;
            this.imageLink = Game.getDefaultImage();
            this.timeBetween = -1;
        }
    }

}