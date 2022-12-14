using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

namespace game
{
    /// <summary>
    /// La classe <c>Market</c> repr�sente le march� du joueur, il va pouvoir �tudier les graphiques et choisir un prix pour lequel il va vendre une quantit� souhait�e.
    /// Il poss�de 3 dictionnaires : un pour garder l'historique des prix, un pour les �v�nements actifs et un pour les �v�nements impossibles.
    /// Ensuite il a 2 attributs : actualDays et instance (l'instance de la classe market (design pattern du singleton)
    /// La classe poss�de 19 m�thodes : Awake, Start, createMarket, nextActiveEvent, getActiveEvents, nextImpossibleEvents, generateNewHistoryDay,
    /// plantByEvent, plantBasic, ezRound, normalise, nextDay, getHistory, getLastPricePlant, getLastPriceSeed, createNewEvent, last60Days, getDays, afficheEtatDebug
    /// </summary>
    public class Market : MonoBehaviour
    {
        private Dictionary<EnumTypePlant, List<int>> history = new Dictionary<EnumTypePlant, List<int>>();
        //active events
        private Dictionary<EventInfo, int> activeEvents = new Dictionary<EventInfo, int>();
        //event in cooldown
        private Dictionary<EventInfo, int> impossibleEvents = new Dictionary<EventInfo, int>();
        private int actualDays;

        public static Market instance;

        /// <summary>
        /// La m�thode <c>Awake</c> est appel�e lorsque l'instance de script est en cours de chargement.
        /// Elle cr�e l'instance du march�.
        /// </summary>
        void Awake()
        {
            if (instance != null)
            {
                Debug.LogError("Plus d'une instance de Market");
                return;
            }
            instance = this;
        }

        /// <summary>
        /// La m�thode <c>Start</c> est utilis�e pour le d�marrage. �tant donn� que Start n'est appel�e qu'une seule fois, elle permet d'initialiser les �l�ments
        /// qui doivent persister tout au long de la vie du script, mais ne doivent �tre configur�s qu'imm�diatement avant utilisation.
        /// Pour notre cas elle appelle la m�thode pour initialiser le march�.
        /// </summary>
        void Start()
        {
            createMarket();
            actualDays = 0;
        }

        /// <summary>
        /// La m�thode <c>createMarket</c> permet de cr�er le march�. (l'initialiser)
        /// </summary>
        public void createMarket()
        {
            //r�cup�ration de tout les type de plante existant
            List<EnumTypePlant> listeType = CreateAllSeedPlant.dicoPlant.getAllPlantType();

            //initialisation de l'historique
            foreach (EnumTypePlant plant in listeType)
            {
                history.Add(plant, new List<int>());
            }

            //cr�er l'historique de l'ann�e 0, SANS events
            for (int i = 0; i < 60; i++)
            {
                nextDay(i, false);
            }
        }

        /// <summary>
        /// La m�thode <c>newtActiveEvent</c> s'occupe des �v�nements actifs. D�s qu'on passe au jour suivant, il d�cr�mente la dur�e de l'�v�nement.
        /// </summary>
        private void nextActiveEvent()
        {
            foreach (EventInfo currentEvent in activeEvents.Keys.ToList())
            {
                activeEvents[currentEvent] -= 1;//longueur de l'event diminu� de 1
                if (activeEvents[currentEvent] <= 0) //si tombe � 0, est supprim�
                {
                    activeEvents.Remove(currentEvent);
                }
            }
        }

        /// <summary>
        /// La m�thode <c>getActiveEvents</c> permet d'obtenir tous les �v�nements actifs
        /// </summary>
        /// <returns>Elle retourne un dictionnaire avec les �v�nements actifs et leur dur�e restante</returns>
        public Dictionary<EventInfo, int> getActiveEvents()
        {
            return activeEvents;
        }

        /// <summary>
        /// La m�thode <c>nextImpossibleEvents</c> s'occupe des �v�nements qui ne peuvent pas se produire (ils ont un cooldown). D�s qu'on passe au jour suivant, il d�cr�ment la dur�e de l'�v�nement.
        /// </summary>
        private void nextImpossibleEvents()
        {
            foreach (EventInfo currentEvent in impossibleEvents.Keys.ToList())
            {
                impossibleEvents[currentEvent] -= 1;//longueur de l'event diminu� de 1
                if (impossibleEvents[currentEvent] <= 0) //si tombe � 0, est supprim�
                {
                    impossibleEvents.Remove(currentEvent);
                }
            }
        }

        /// <summary>
        /// La m�thode <c>generateNewHistoryDay</c> permet de g�n�rer un historique des prix pour les plantes.
        /// </summary>
        /// <param name="days">le jour actuel</param>
        /// <param name="eventActiveON">bool�en pour savoir si les events sont activ�s (ils sont d�sactiv�s pour l'historique de l'ann�e 0)</param>
        private void generateNewHistoryDay(int days, bool eventActiveON)
        {
            int month = (days / 5) % 12; //le mois actuel
            //parcours chaque plante
            foreach (EnumTypePlant plant in history.Keys)
            {
                Plant pl = CreateAllSeedPlant.dicoPlant.createPlant(plant);
                int thisPlantPrice;
                System.Random rnd = new System.Random();

                thisPlantPrice = ezRound(plantBasic(pl, month, days) * ((rnd.NextDouble() * (1.05 - 0.95)) + 0.95)); //mutliplie par un nombre au hasard entre 0.95 et 1.05

                if (eventActiveON) //si les events sont activ�s (ils sont d�sactiv�s pour l'historique de l'ann�e 0)
                {
                    foreach (var evTemp in activeEvents) //parcours chaque event
                    {
                        if (evTemp.Key.targetPlant) //si les plantes sont cibl�s
                        {
                            foreach (EnumTypePlant plantTypeTested in evTemp.Key.targetsPlant)
                            {
                                if (plantTypeTested == plant) //si cette plante est cibl�e
                                {
                                    thisPlantPrice = plantByEvent(evTemp.Key, evTemp.Value, thisPlantPrice);
                                    break; //si �a cible, pas besoin de parcourir la fin de la liste
                                }
                            }
                        }
                    }
                }

                if (thisPlantPrice < 0)
                {
                    thisPlantPrice = 0;
                }

                history[plant].Add(thisPlantPrice); //ajoute le nv prix de la plante � l'historique
            }
            return;
        }

        /// <summary>
        /// La m�thode <c>plantByEvent</c> calcule � partir de plusieurs variables le nouveau prix d'un �l�ment
        /// </summary>
        /// <param name="eventTemp">l'�v�nement qui impacte le prix</param>
        /// <param name="dureeMom">nombre de jours pass�s depuis le dernier mois</param>
        /// <param name="value">le prix de la plante qui va changer</param>
        /// <returns>Elle retourne le nouveau prix de l'�l�ment</returns>
        private int plantByEvent(EventInfo eventTemp, int dureeMom, int value)
        {
            double mid = (eventTemp.length + 1.0) / 2;
            double multBase = eventTemp.mutliplierBase;
            double multProg = eventTemp.mutliplierProg;
            int newValue = (int)ezRound((value + (value * ((multProg - 1) * (mid - normalise(dureeMom - mid)) / mid))) * multBase);

            return newValue;
        }

        /// <summary>
        /// La m�thode <c>plantBasic</c> cherche la valeur de la plante sur ce jour, les valeurs des plantes sont renseign�es une fois par mois.
        /// On cherche la valeur du mois pr�c�dent, celle du mois prochain, et on calcule donc celle du jour par rapport aux deux et � l'espace entre les deux
        /// de mani�re lin�aire
        /// </summary>
        /// <param name="plant">la plante</param>
        /// <param name="month">valeur du mois</param>
        /// <param name="days">la valeur du jour</param>
        /// <returns>Elle retourne la valeur de la plante du jour</returns>
        private int plantBasic(Plant plant, int month, int days)
        {
            int monthPrice = plant.getPrice(month); //dernier mois
            int nextMonthPrice = plant.getPrice((month + 1) % 12); //prochain mois
            int daysAfterActualMonth = days - month * 5; //nombre de jour apr�s le dernier mois
            int newValue = ezRound(monthPrice + (daysAfterActualMonth / 5.0) * (nextMonthPrice - monthPrice)); //nouveau prix de la plante, event pas encore appliqu�
            return newValue;
        }

        /// <summary>
        /// La m�thode <c>ezRound</c> permet de faire des arrondis et un cast de double en int
        /// </summary>
        /// <param name="value">la valeur � arrondir</param>
        /// <returns>Elle retourne un arrondis de type int</returns>
        private int ezRound(double value)
        {
            return (int)Math.Round(value);
        }

        /// <summary>
        /// La m�thode <c>normalise</c> normalise un double
        /// </summary>
        /// <param name="val">la valeur � normaliser</param>
        /// <returns>Elle retourne la normalisation</returns>
        public double normalise(double val)
        {
            return Math.Sqrt(val * val);
        }

        /// <summary>
        /// La m�thode <c>newtDay</c> est appel�e chaque jour et renvoie un nouvel �v�nement si il y en a un
        /// Elle actualise le prix de chaque plante avec un jour de plus et supprime les �v�nements finis et en cr�e potentiellement un autre
        /// </summary>
        /// <param name="days">la valeur du jour</param>
        /// <param name="eventON">bool�en pour savoir si les events sont activ�s (ils sont d�sactiv�s pour l'historique de l'ann�e 0)</param>
        /// <returns>Elle retourne null si aucun �v�nement n'a �t� cr�e, sinon elle renvoie l'�v�nement cr��</returns>
        public EventInfo nextDay(int days, bool eventON)
        {
            actualDays = days;
            int month = (days / 5) % 12;
            nextActiveEvent();
            nextImpossibleEvents();
            generateNewHistoryDay(days, eventON);

            System.Random rand = new System.Random();


            //un event en moyenne un jour sur 3
            if (rand.Next(0, 3) > 0 || !eventON)
            {
                /*
                Debug.Log("Market nbr event : " + activeEvents.Count);
                Debug.Log("Market nbr event impossible : " + impossibleEvents.Count);
                */
                return null;
            }
            else
            {
                EventInfo newEvent = createNewEvent(days);
                if (newEvent == null)
                {
                    return null;
                }
                activeEvents.Add(newEvent, newEvent.length);
                impossibleEvents.Add(newEvent, newEvent.cooldown);
                /*
                Debug.Log("Market nbr event : " + activeEvents.Count);
                Debug.Log("Market nbr event impossible : " + impossibleEvents.Count);
                */
                return newEvent;
            }
        }

        /// <summary>
        /// La m�thode <c>getHistory</c> renvoie l'historique des prix
        /// </summary>
        /// <returns>Elle retourne l'historique des prix</returns>
        public Dictionary<EnumTypePlant, List<int>> getHistory()
        {
            return history;
        }

        /// <summary>
        /// La m�thode <c>getLastPricePlant</c> renvoie le prix de la plante demand�.
        /// </summary>
        /// <param name="plant">le type de plante</param>
        /// <returns>Elle renvoie le prix du dernier jour de la plante, ou -1 si la plante n'est pas dans l'historique des prix</returns>
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

        /// <summary>
        /// La m�thode <c>getLastPriceSeed</c> calcule le prix r�el de la graine.
        /// </summary>
        /// <param name="plant">le type de plante</param>
        /// <returns>Elle retourne le prix</returns>
        public int getLastPriceSeed(EnumTypePlant plant)
        {
            Seed seed = CreateAllSeedPlant.dicoPlant.createSeed(plant);
            int seedPrice = seed.getPrice();
            foreach (var evTemp in activeEvents) //parcours chaque event
            {
                if (evTemp.Key.targetSeed) //si les plantes sont cibl�s
                {
                    foreach (EnumTypePlant plantTypeTested in evTemp.Key.targetsPlant)
                    {
                        if (plantTypeTested == plant) //si l'event cible la graine
                        {
                            seedPrice = plantByEvent(evTemp.Key, evTemp.Value, seedPrice);
                            break; //si �a cible, pas besoin de parcourir la fin de la liste
                        }
                    }
                }
            }
            return seedPrice;
        }

        /// <summary>
        /// La m�thode <c>createNewEvent</c> permet de cr�er un nouvel �v�nement
        /// </summary>
        /// <param name="days">la valeur du jour</param>
        /// <returns>Elle retourne l'�v�nement cr��</returns>
        private EventInfo createNewEvent(int days)
        {
            AllEvents allEvents = new AllEvents();
            EventInfo newEvent = allEvents.getRandomEvent(days, impossibleEvents);
            return newEvent;
        }

        /// <summary>
        /// La m�thode <c>last60Days</c> renvoie l'historique des prix des 60 derniers jours de la plante
        /// </summary>
        /// <param name="pl">le type de plante</param>
        /// <returns>Elle retourne la liste des prix</returns>
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

        /// <summary>
        /// La m�thode <c>getDays</c> renvoie les jours
        /// </summary>
        /// <returns>Elle renvoie le jour</returns>
        public int getDays()
        {
            return actualDays;
        }

        /// <summary>
        /// La m�thode <c>afficheEtatDebug</c> est utilis� pour le debug
        /// </summary>
        public void afficheEtatDebug()
        {
            Debug.Log("Jour : " + actualDays + " Nombre d'event actif : " + activeEvents.Count);
            foreach (var evt in activeEvents)
            {
                Debug.Log("Jour : " + actualDays + " eventPos " + evt.Key.namee + " duree passe : " + evt.Value);
            }
            Debug.Log("Jour : " + actualDays + " Nombre d'event impossible : " + impossibleEvents.Count);
            foreach (var evt in impossibleEvents)
            {
                Debug.Log("Jour : " + actualDays + " eventImpos : " + evt.Key.namee + " duree passe : " + evt.Value);
            }
        }

    }

}
