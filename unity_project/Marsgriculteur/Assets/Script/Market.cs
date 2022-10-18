using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


namespace game
{
    public class Market
    {
        private Dictionary<EnumTypePlant, List<int>> history = new Dictionary<EnumTypePlant, List<int>>();
        //active events
        private Dictionary<EventInfo, int> activeEvents = new Dictionary<EventInfo, int>();
        //event in cooldown
        private Dictionary<EventInfo, int> impossibleEvents = new Dictionary<EventInfo, int>();

        public void initMarket()
        {
            //need to get the market somewhere
        }

        public void nextMonth()
        {
            //modify the history for each plant, and save it
        }

        public Dictionary<EnumTypePlant, List<int>> getHistory()
        {
            return history;
        }

        //give the price of the plant last month
        public int getLastPricePlant(EnumTypePlant plant)
        {
            if (history.ContainsKey(plant))
            {
                if(history[plant].Count > 0)
                {
                    return history[plant][history[plant].Count - 1];
                }

            }
            return -1;
        }

        //calculate the actual seed price
        public int getLastPriceSeed(EnumTypePlant plant)
        {
            //need to get the price of a seed
            int seedPrice = 14; //bullshit
            foreach(var evTemp in activeEvents) //go around each active events
            {
                if (evTemp.Key.targetSeed) //if it target seeds
                {
                    foreach(EnumTypePlant plantTypeTested in evTemp.Key.targetsPlant) 
                    {
                        if(plantTypeTested == plant) //if this type of seed is targeted
                        {
                            seedPrice = Convert.ToInt32( seedPrice * evTemp.Key.mutliplier);
                            break; //to be a bit more powerfull : if the seed is targeted, no need to check for the other plant Type
                        }
                    }
                } 
            }
            return 0;
        }

        private void createNewEvent()
        {

        }

        private int nbrSell(EnumTypePlant plant, int number, int price)
        {
            int currentPrice = 10;


            return 0;
        }
    }

}
