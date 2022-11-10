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
            //********************************************************************
            //************************ EVENTS COOL *******************************
            //********************************************************************

            List<EnumTypePlant> listAnim = new List<EnumTypePlant>();
            listAnim.Add(EnumTypePlant.ECHAV);
            listAnim.Add(EnumTypePlant.ONTOUM);
            listAnim.Add(EnumTypePlant.ELUOP);
            listAnim.Add(EnumTypePlant.NIPAL);
            allEventDico.Add("qualiMeat", new EventInfo("qualiMeat",
                "Une radiation donne un go�t plus sal� et tr�s appr�ci�s aux animaux ",
                2,
                1.3,
                true,
                false,
                false,
                listAnim,
                new List<string>(),
                6,
                0,
                Game.getDefaultSprite(),
                7));




            //ELB, EGRO, AJOS, AZLOC
            //ECHAV, ONTOUM, ELUOP, NIPAL

            List<EnumTypePlant> listPl = new List<EnumTypePlant>();
            listPl.Add(EnumTypePlant.ELB);
            listPl.Add(EnumTypePlant.EGRO);
            listPl.Add(EnumTypePlant.AJOS);
            listPl.Add(EnumTypePlant.AZLOC);

            allEventDico.Add("solarStorm", new EventInfo("solarStorm",
                "Une temp�te solaire font griller vos plantes, les gens en rafolent",
                2,
                1.3,
                true,
                false,
                false,
                listPl,
                new List<string>(),
                6,
                0,
                Game.getDefaultSprite(),
                7));



            //********************************************************************
            //************************ EVENTS NOT COOL ***************************
            //********************************************************************

            allEventDico.Clear();
            List<EnumTypePlant> listElbEgr = new List<EnumTypePlant>();
            listElbEgr.Add(EnumTypePlant.ELB);
            listElbEgr.Add(EnumTypePlant.EGRO);

            allEventDico.Add("wartElbEgr", new EventInfo("wartElbEgr",
                "Des verrus martiennes touchent les recoltes d'EBL et d'EGRO, �a n'a pas bon go�t",
                3,
                0.4,
                true,
                false,
                false,
                listElbEgr,
                new List<string>(),
                12,
                0,
                Game.getDefaultSprite(),
                4));


            allEventDico.Add("vegeTrend", new EventInfo("vegeTrend",
                "Une trend v�g�tarienne se d�veloppe",
                4,
                0.6,
                true,
                false,
                false,
                listAnim,
                new List<string>(),
                6,
                2,
                Game.getDefaultSprite(),
                0));

        }

        //get a new event depending on the month, and the impossible event
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