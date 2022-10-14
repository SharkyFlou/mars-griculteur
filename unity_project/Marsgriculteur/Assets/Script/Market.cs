using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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

        }

        public void nextMonth()
        {

        }

        public Dictionary<EnumTypePlant, List<int>> getHistory()
        {
            return history;
        }

        public int getLastPricePlant(EnumTypePlant plant)
        {
            return 0;
        }

        public int getLastPriceSeed(EnumTypePlant plant)
        {
            return 0;
        }

        private void createNewEvent()
        {

        }

        private int nbrSell(EnumTypePlant plant, int number, int price)
        {
            return 0;
        }
    }

}
