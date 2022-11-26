using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

namespace game
{
    public class Market : MonoBehaviour
    {
        private Dictionary<EnumTypePlant, List<int>> history = new Dictionary<EnumTypePlant, List<int>>();
        //active events
        private Dictionary<EventInfo, int> activeEvents = new Dictionary<EventInfo, int>();
        //event in cooldown
        private Dictionary<EventInfo, int> impossibleEvents = new Dictionary<EventInfo, int>();
        private int actualDays;

        public static Market instance;

        // Méthode d'accès statique (point d'accès global)

        void Awake()
        {
            if (instance != null)
            {
                Debug.LogError("Plus d'une instance de Market");
                return;
            }
            instance = this;
        }

        void Start()
        {
            createMarket();
            actualDays = 0;
        }

        public void createMarket()
        {
            List<EnumTypePlant> listeType = CreateAllSeedPlant.dicoPlant.getAllPlantType();

            foreach (EnumTypePlant plant in listeType)
            {
                history.Add(plant, new List<int>());
            }

            for (int i = 0; i < 60; i++)
            {
                nextDay(i, false);
            }
        }

        private void nextActiveEvent()
        {
            foreach (EventInfo currentEvent in activeEvents.Keys.ToList())
            {
                activeEvents[currentEvent] -= 1;
                if (activeEvents[currentEvent] <= 0) //length of the event decrease by one
                {
                    //if it hits 0, the event is finished
                    activeEvents.Remove(currentEvent);
                }
            }
        }

        public Dictionary<EventInfo, int> getActiveEvents()
        {
            return activeEvents;
        }

        private void nextImpossibleEvents()
        {
            foreach (EventInfo currentEvent in impossibleEvents.Keys.ToList())
            {
                impossibleEvents[currentEvent] -= 1;
                if (impossibleEvents[currentEvent] <= 0) //length of the event decrease by one
                {                                           //if it hits 0, the event is finished
                    impossibleEvents.Remove(currentEvent);
                }
            }
        }

        private void generateNewHistoryDay(int days, bool eventActiveON)
        {
            int month = (days / 5) % 12; //the adequate month
            //Debug.Log("Creation jour " + days + " mois " + month);
            foreach (EnumTypePlant plant in history.Keys)
            {
                Plant pl = CreateAllSeedPlant.dicoPlant.createPlant(plant);
                int thisPlantPrice;
                System.Random rnd = new System.Random();

                thisPlantPrice = ezRound(plantBasic(pl, month, days) * ((rnd.NextDouble() * (1.1 - 0.9)) + 0.9)); //multiply by a number between 0.9 and 1.1

                if (eventActiveON) //si les events sont activés
                {
                    foreach (var evTemp in activeEvents) //go around each active events
                    {
                        if (evTemp.Key.targetPlant) //if it target plant
                        {
                            foreach (EnumTypePlant plantTypeTested in evTemp.Key.targetsPlant)
                            {
                                if (plantTypeTested == plant) //if this type of plant is targeted
                                {
                                    thisPlantPrice = plantByEvent(evTemp.Key, evTemp.Value, thisPlantPrice);
                                    break; //to be a bit more powerfull : if the plant is targeted, no need to check for the other plant Type
                                }
                            }
                        }
                    }
                }

                history[plant].Add(thisPlantPrice); //add the new plant price
            }
            return;
        }


        private int plantByEvent(EventInfo eventTemp, int dureeMom, int value)
        {
            double mid = (eventTemp.length + 1.0) / 2;
            double multBase = eventTemp.mutliplierBase;
            double multProg = eventTemp.mutliplierProg;
            int newValue = (int)ezRound((value + (value * ((multProg - 1) * (mid - normalise(dureeMom - mid)) / mid))) * multBase);

            return newValue;
        }

        private int plantBasic(Plant plant, int month, int days)
        {
            int monthPrice = plant.getPrice(month); //the last month
            int nextMonthPrice = plant.getPrice((month + 1) % 12); //the next month
            int daysAfterActualMonth = days - month * 5; //the number of days after the last month
            int newValue = ezRound(monthPrice + (daysAfterActualMonth / 5.0) * (nextMonthPrice - monthPrice)); //the basic price of the plant
            return newValue;
        }

        private int ezRound(double value)
        {
            return (int)Math.Round(value);
        }

        public double normalise(double val)
        {
            return Math.Sqrt(val * val);
        }


        public EventInfo nextDay(int days, bool eventON)
        {
            actualDays = days;
            int month = (days / 5) % 12;
            nextActiveEvent();
            nextImpossibleEvents();
            generateNewHistoryDay(days, eventON);

            System.Random rand = new System.Random();

            if (rand.Next(0, 2) == 0 || !eventON)
            {
                return null;
            }
            else
            {
                EventInfo newEvent = createNewEvent(month);
                activeEvents.Add(newEvent, newEvent.length);
                impossibleEvents.Add(newEvent, newEvent.cooldown);
                return newEvent;
            }
        }

        public Dictionary<EnumTypePlant, List<int>> getHistory()
        {
            return history;
        }

        //give the price of the plant last day
        public int getLastPricePlant(EnumTypePlant plant)
        {
            if (history.ContainsKey(plant)) //si la plante est bien dans l'historique des prix
            {
                if (history[plant].Count > 0) //si son historique a plus de 0 valeurs
                {
                    return history[plant][history[plant].Count - 1]; //retourne le prix du dernier jours de la plante
                }

            }
            return -1;
        }

        //calculate the actual seed price
        public int getLastPriceSeed(EnumTypePlant plant)
        {
            Seed seed = CreateAllSeedPlant.dicoPlant.createSeed(EnumTypePlant.ELB);
            int seedPrice = seed.getPrice();
            foreach (var evTemp in activeEvents) //go around each active events
            {
                if (evTemp.Key.targetSeed) //if it target seeds
                {
                    foreach (EnumTypePlant plantTypeTested in evTemp.Key.targetsPlant)
                    {
                        if (plantTypeTested == plant) //if this type of seed is targeted
                        {
                            seedPrice = Convert.ToInt32(seedPrice * evTemp.Key.mutliplierBase);
                            break; //to be a bit more powerfull : if the seed is targeted, no need to check for the other plant Type
                        }
                    }
                }
            }
            return 0;
        }

        private EventInfo createNewEvent(int month)
        {
            AllEvents allEvents = new AllEvents();
            EventInfo newEvent = allEvents.getRandomEvent(month, impossibleEvents);
            return newEvent;
        }

        public List<int> last60Days(EnumTypePlant pl)
        {
            if (history.ContainsKey(pl)) //si la plante est bien dans l'hsitorique des prix
            {
                if (history[pl].Count >= 60) //si son historique a plus de 0 valeurs
                {
                    int nbrDeb = history[pl].Count - 60;
                    return history[pl].GetRange(nbrDeb, 60);
                }

            }
            return null;
        }

        public int getDays()
        {
            return actualDays;
        }

        public void afficheEtatDebug()
        {
            Debug.Log("Jour : " + actualDays + " Nombre d'event actif : " + activeEvents.Count);
            foreach (var evt in activeEvents)
            {
                Debug.Log("Jour : "+ actualDays + " eventPos " + evt.Key.namee + " duree passe : " + evt.Value);
            }
            Debug.Log("Jour : " + actualDays + " Nombre d'event impossible : " + impossibleEvents.Count);
            foreach (var evt in impossibleEvents)
            {
                Debug.Log("Jour : " + actualDays + " eventImpos : " + evt.Key.namee + " duree passe : " + evt.Value);
            }
        }

    }

}
