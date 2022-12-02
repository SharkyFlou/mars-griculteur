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
        public double mutliplierBase;
        public double mutliplierProg;
        public bool targetPlant;
        public bool targetSeed;
        public bool targetTool;
        public List<EnumTypePlant> targetsPlant = new List<EnumTypePlant>();
        public List<string> targetsTool = new List<string>();
        public int probability;
        public int unlockableAfter;
        public Sprite imageLink;
        public int cooldown;


        public EventInfo(string namee,
            string description,
            int lenght,
            double mutliplier,
            double mutliplierProg,
            bool targetPlant,
            bool targetSeed,
            bool targetTool,
            List<EnumTypePlant> targetsPlant,
            List<string> targetsTool,
            int probability,
            int unlockableAfter,
            Sprite imageLink,
            int cooldown)
        {
            this.namee = namee;
            this.description = description;
            this.length = lenght;
            this.mutliplierBase = mutliplier;
            this.mutliplierProg = mutliplierProg;
            this.targetPlant = targetPlant;
            this.targetSeed = targetSeed;
            this.targetTool = targetTool;
            this.targetsPlant = targetsPlant;
            this.targetsTool = targetsTool;
            this.probability = probability;
            this.unlockableAfter = unlockableAfter;
            this.imageLink = imageLink;
            this.cooldown = cooldown;
        }

        public EventInfo()
        {
            this.namee = "Error";
            this.description = "Error, using an empty constructor";
            this.length = -1;
            this.mutliplierBase = -1;
            this.mutliplierProg = 0;
            this.targetPlant = false;
            this.targetSeed = false;
            this.targetTool = false;
            this.targetsPlant = new List<EnumTypePlant>();
            this.targetsTool = new List<string>();
            this.probability = -1;
            this.unlockableAfter = -1;
            this.imageLink = Game.getDefaultSprite();
            this.cooldown = -1;
        }

        public string getName()
        {
            return this.namee;
        }

        public int getLength()
        {
            return this.length;
        }

        public string getDescription()
        {
            return this.description;
        }

        public string getTarget()
        {
            string rtr = string.Empty;
            for (int i = 0; i < targetsPlant.Count; i++)
            {
                rtr += targetsPlant[i] + ", ";
            }
            rtr = rtr.Substring(0, rtr.Length - 2);
            return rtr;
        }
    }
}