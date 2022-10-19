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
            //LEO need to get the market from somewhere
        }


        public void createMarket(AllEvents allEvents)
        {
            for(int i =0; i<12; i++)
            {
                nextMonth(allEvents,i,false);
            }
            //LEO need to save it (the history)
        }

        private void nextActiveEvent()
        {
            foreach (EventInfo currentEvent in activeEvents.Keys)
            {
                if ((activeEvents[currentEvent] -= 1) <= 0) //length of the event decrease by one
                {                                           //if it hits 0, the event is finished
                    activeEvents.Remove(currentEvent);
                }
            }
        }

        private void nextImpossibleEvents()
        {
            foreach (EventInfo currentEvent in impossibleEvents.Keys)
            {
                if ((impossibleEvents[currentEvent] -= 1) <= 0) //length of the event decrease by one
                {                                           //if it hits 0, the event is finished
                    impossibleEvents.Remove(currentEvent);
                }
            }
        }

        private void generateNewHistoryMonth(int month, bool eventActiveON) 
        {
            foreach(EnumTypePlant plant in history.Keys)
            {
                //LEO get the price of the plant for the month
                int thisPlantPrice = 69; //bullshit
                System.Random rnd = new System.Random();
                thisPlantPrice = Convert.ToInt32((thisPlantPrice * rnd.NextDouble() * (1.1- 0.9)) + 0.9) ; //multiply by a number between 0.9 and 0.1


                foreach (var evTemp in activeEvents) //go around each active events
                {
                    if (evTemp.Key.targetPlant) //if it target plant
                    {
                        foreach (EnumTypePlant plantTypeTested in evTemp.Key.targetsPlant)
                        {
                            if (plantTypeTested == plant) //if this type of plant is targeted
                            {
                                thisPlantPrice = Convert.ToInt32(thisPlantPrice * evTemp.Key.mutliplier);
                                break; //to be a bit more powerfull : if the plant is targeted, no need to check for the other plant Type
                            }
                        }
                    }
                }

                history[plant].Add(thisPlantPrice); //add the new plant price
            }
            return;
        }

        public EventInfo nextMonth(AllEvents allEvents, int month, bool eventON)
        {
            nextActiveEvent();
            nextImpossibleEvents();
            generateNewHistoryMonth(month, eventON);


            //LEO modify the history for each plant, and save it
            EventInfo newEvent = createNewEvent(allEvents, month);

            return newEvent;
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
            //LEO need to get the price of a seed
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

        private EventInfo createNewEvent(AllEvents allEvents, int month)
        {
            EventInfo newEvent = allEvents.getRandomEvent(month, impossibleEvents);
            return newEvent;
        }

       

        //give the thearical nbr of sell for a certain number of a certain plant plant at a given price
        //calculated from the price of the month before, so change to next month before making the sell
        private int nbrSell(EnumTypePlant plant, int number, int price)
        {
            int currentPriceMarket = getLastPricePlant(plant);
            double ratio = ((currentPriceMarket * 100.0) / price ) - 100; //if its 9, then the pllayer price is 9% more than the market
            double mutliplier = ratio * 2.5; //so if its 40% higher, then no sells; 20% then half sells
            int nbrSells = (int) Math.Floor(number * (100.0 - mutliplier)/100.0); //result

            return nbrSells;
        }
    }

}
