using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace game
{
    public class AllEvents
    {

        //name in first, and YES it already exist in the info of eventInfo, but i dont car 
        private Dictionary<string, EventInfo> allEventDico = new Dictionary<string, EventInfo>();

        public AllEvents()
        {
            allEventDico.Clear();
            List<EnumTypePlant> plants = new List<EnumTypePlant>();
            plants.Add(EnumTypePlant.ELB);

            allEventDico.Add("maladieElb", new EventInfo("maladieEbl",
                "Une maladie touche les recoltes de ble qui fait tomber malade les gens le mangeant",
                3,
                0.4,
                true,
                false,
                false,
                plants,
                new List<string>(),
                12,
                0,
                "Assets/Sprites/EventSprites/e_maladieElb",
                4));


            allEventDico.Add("echavBonQuali", new EventInfo("echavBonQuali",
                "Une mutation génétique phénoménal fait que les vaches sont plus appétissantes",
                3,
                0.4,
                true,
                false,
                false,
                plants,
                new List<string>(),
                12,
                0,
                "Assets/Sprites/EventSprites/e_maladieElb",
                4));
        }

        //get a new event depending on the fact
        public EventInfo getRandomEvent(int month, Dictionary<EventInfo, int> impossibleEvents)
        {

            Dictionary<string, EventInfo> possibleEvents = substractDico(allEventDico, impossibleEvents);


            if(possibleEvents.Count == 0) //if true, then something is messed up
            {
                return new EventInfo(); //Shit
            }


            int totalProbablity = 0;
            foreach(EventInfo currentEvent in possibleEvents.Values) //calculate the sum of all event probabilites
            {
                if(currentEvent.unlockableAfter > month) //verify if the event is possible
                {
                    totalProbablity += currentEvent.probability; //add the probabilty of the event
                }
            }

            System.Random rnd = new System.Random();
            int randProba = rnd.Next(1, totalProbablity+1); //get a random number between 0 and the sum of all possible events
            EventInfo newEvent = new EventInfo();

            foreach (EventInfo currentEvent in possibleEvents.Values)
            {
                if (currentEvent.unlockableAfter > month) //verify if the event is possible
                {
                    if ((randProba -= currentEvent.probability) <= 0) //decrease until it hits 0
                    {
                        newEvent = currentEvent; //we find a new event !
                        break;
                    }
                }
                    
            }

            return newEvent;
        }


        //is utilize to get the possible Events, from all the events and the impossible ones
        private Dictionary<string, EventInfo> substractDico(Dictionary<string, EventInfo> dicoOrigin, Dictionary<EventInfo, int> dicoSubstract)
        {
            Dictionary<string, EventInfo> newDico = new Dictionary<string, EventInfo>();
            EventInfo currentEvent;
            foreach (string names in dicoOrigin.Keys)
            {
                currentEvent=dicoOrigin[names];
                if (!dicoSubstract.ContainsKey(currentEvent))
                {
                    newDico.Add(names, currentEvent);
                }
            }
            return newDico;
        }
    }
}