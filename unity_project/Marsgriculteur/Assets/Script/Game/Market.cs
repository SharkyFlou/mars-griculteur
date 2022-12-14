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

        //vers init du market
        void Start()
        {
            createMarket();
            actualDays = 0;
        }

        //initialisation du maché
        public void createMarket()
        {
            //récupération de tout les type de plante existant
            List<EnumTypePlant> listeType = CreateAllSeedPlant.dicoPlant.getAllPlantType();

            //initialisation de l'historique
            foreach (EnumTypePlant plant in listeType)
            {
                history.Add(plant, new List<int>());
            }

            //créer l'historique de l'année 0, SANS events
            for (int i = 0; i < 60; i++)
            {
                nextDay(i, false);
            }
        }

        private void nextActiveEvent()
        {
            foreach (EventInfo currentEvent in activeEvents.Keys.ToList())
            {
                activeEvents[currentEvent] -= 1;//longueur de l'event diminué de 1
                if (activeEvents[currentEvent] <= 0) //si tombe à 0, est supprimé
                {
                    
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
                impossibleEvents[currentEvent] -= 1;//longueur de l'event diminué de 1
                if (impossibleEvents[currentEvent] <= 0) //si tombe à 0, est supprimé
                {
                    impossibleEvents.Remove(currentEvent);
                }
            }
        }

        private void generateNewHistoryDay(int days, bool eventActiveON)
        {
            int month = (days / 5) % 12; //le mois actuel
            //parcours chaque plante
            foreach (EnumTypePlant plant in history.Keys)
            {
                Plant pl = CreateAllSeedPlant.dicoPlant.createPlant(plant);
                int thisPlantPrice;
                System.Random rnd = new System.Random();

                thisPlantPrice = ezRound(plantBasic(pl, month, days) * ((rnd.NextDouble() * (1.05 - 0.95)) + 0.95)); //mutliplie par un nombre au hasrd entre 0.95 et 1.05

                if (eventActiveON) //si les events sont activés (ils sont désactivé pour l'historique de l'année 0)
                {
                    foreach (var evTemp in activeEvents) //parcours chaque event
                    {
                        if (evTemp.Key.targetPlant) //si les plantes sont ciblés
                        {
                            foreach (EnumTypePlant plantTypeTested in evTemp.Key.targetsPlant)
                            {
                                if (plantTypeTested == plant) //si cette plante est ciblée
                                {
                                    thisPlantPrice = plantByEvent(evTemp.Key, evTemp.Value, thisPlantPrice);
                                    break; //si ça cible, pas besoin de parcourir la fin de la liste
                                }
                            }
                        }
                    }
                }

                history[plant].Add(thisPlantPrice); //ajoute le nv prix de la plante à l'historique
            }
            return;
        }

        //gros calcul qui fait peur, calcul a partir de plusieurs variable le nouveau prix d'un element
        private int plantByEvent(EventInfo eventTemp, int dureeMom, int value)
        {
            double mid = (eventTemp.length + 1.0) / 2;
            double multBase = eventTemp.mutliplierBase;
            double multProg = eventTemp.mutliplierProg;
            int newValue = (int)ezRound((value + (value * ((multProg - 1) * (mid - normalise(dureeMom - mid)) / mid))) * multBase);

            return newValue;
        }

        //cherche la valeur de la plante sur ce jour, les valeurs des plants sont renseigné une fois par mois
        //on cherche la valeur du mois précédente, celle de mois prochain, et calcul donc celle du jour par rapport aux deux et à l'espace entre les deux
        //de manière linéaire
        private int plantBasic(Plant plant, int month, int days)
        {
            int monthPrice = plant.getPrice(month); //dernier mois
            int nextMonthPrice = plant.getPrice((month + 1) % 12); //prochain mois
            int daysAfterActualMonth = days - month * 5; //nombre de jour après le dernier mois
            int newValue = ezRound(monthPrice + (daysAfterActualMonth / 5.0) * (nextMonthPrice - monthPrice)); //nouveau prix de la plante, event pas encore appliqué
            return newValue;
        }

        //permet de faire des arrondi et un cast
        private int ezRound(double value)
        {
            return (int)Math.Round(value);
        }

        //normalise un double
        public double normalise(double val)
        {
            return Math.Sqrt(val * val);
        }

        //est appelé chaque nouveau jour, renvoie un nouveau event si il y en a un
        //actualise le prix de chaque plante avec un jour de plus
        //supprime les events finit, et un créer potentielement un autre
        public EventInfo nextDay(int days, bool eventON)
        {
            actualDays = days;
            int month = (days / 5) % 12;
            nextActiveEvent();
            nextImpossibleEvents();
            generateNewHistoryDay(days, eventON);

            System.Random rand = new System.Random();

            //un event en moyenne un jour sur 3
            if (rand.Next(0, 3) == 0 || !eventON)
            {
                return null;
            }
            else
            {
                EventInfo newEvent = createNewEvent(days);
                activeEvents.Add(newEvent, newEvent.length);
                impossibleEvents.Add(newEvent, newEvent.cooldown);
                return newEvent;
            }
        }

        //renvoie l'historique
        public Dictionary<EnumTypePlant, List<int>> getHistory()
        {
            return history;
        }

        //renvoie le prix de la plante demandé
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

        //calcul le prix réel de la graine
        public int getLastPriceSeed(EnumTypePlant plant)
        {
            Seed seed = CreateAllSeedPlant.dicoPlant.createSeed(EnumTypePlant.ELB);
            int seedPrice = seed.getPrice();
            foreach (var evTemp in activeEvents) //parcours chaque event
            {
                if (evTemp.Key.targetSeed) //si les plantes sont ciblés
                {
                    foreach (EnumTypePlant plantTypeTested in evTemp.Key.targetsPlant)
                    {
                        if (plantTypeTested == plant) //si l'event cible la graine
                        {
                            seedPrice = plantByEvent(evTemp.Key, evTemp.Value, seedPrice);
                            break; //si ça cible, pas besoin de parcourir la fin de la liste
                        }
                    }
                }
            }
            return 0;
        }

        //créer un nouvel event
        private EventInfo createNewEvent(int days)
        {
            AllEvents allEvents = new AllEvents();
            EventInfo newEvent = allEvents.getRandomEvent(days, impossibleEvents);
            return newEvent;
        }

        //renvoie l'historique des prix des 60 dernier jours de la plante
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

        //renvoie les jours
        public int getDays()
        {
            return actualDays;
        }

        //pour le debug
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
