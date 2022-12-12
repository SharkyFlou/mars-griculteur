using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace game
{
    /// <summary>
    /// La classe AllEvents permet de lister tous les événements qui peuvent arriver pendant une partie.
    /// Elle utilise son constructeur pour créer tous les événements, et elle contient 2 méthodes : <c>getRandomEvent</c> et <c>substractDico</c>.
    /// 
    /// </summary>
    public class AllEvents
    {

        //name in first, and YES it already exist in the info of eventInfo, but i dont car 
        public Dictionary<string, EventInfo> allEventDico = new Dictionary<string, EventInfo>();

        /// <summary>
        /// Le constructeur <c>AllEvents</c> permet de créer les événements. Il y a 2 types d'événements : les événements dit cools et les événements dit pas cool.
        /// Les événments sont composés d'un code unique (leur nom), d'une description, d'une durée (combien de temps ils vont durer après leur apparition), de 2 multiplieurs (le premier pour rajouter
        /// un simple multiplier au prix, par exemple *0.9 ou 1.1, multiplier fixe qui reste actif tant que l'évent l'est
        /// et le deuxième est un multiplier qui atteint son pic de multiplication au milieu de sa durée, ex : il vaut 2, et l'évent dure 5, alors il oscilera un peu près comme ça : 1.33, 1.66, 2, 1.66, 1.33),
        /// ensuite il y a 3 booléens (le premier pour savoir si l'événement atteint les plantes, le deuxième si il atteint les graines et le troisième si il atteint les outils.
        /// Ensuite il y a la liste des plantes (ou des graines, ça dépend ce que ça atteint) et la liste des outils, pour les outils atteint.
        /// Les derniers paramètres sont : la probabilité d'apparition de l'événement, un événements ne peut qu'arriver à partir du xième jour,
        /// l'image de l'événement et le dernier paramètres correspond au temps à partir duquel l'événement peut réapparaître après que celui-ci est commencé (ex : un event à une durée de 5, un cooldown de 10,
        /// et un unlockAfter de 0, il peut arriver dès le 1er jour, et 10 jour après qu'il soit arrivé il peut re arriver).
        /// </summary>
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
                "Une radiation donne un goût plus salé et très appréciés aux animaux ",
                10,
                1.2,
                1.5,
                true,
                false,
                false,
                listAnim,
                new List<string>(),
                6,
                0,
                Game.getDefaultSprite(),
                40));




            //ELB, EGRO, AJOS, AZLOC
            //ECHAV, ONTOUM, ELUOP, NIPAL

            List<EnumTypePlant> listPl = new List<EnumTypePlant>();
            listPl.Add(EnumTypePlant.ELB);
            listPl.Add(EnumTypePlant.EGRO);
            listPl.Add(EnumTypePlant.AJOS);
            listPl.Add(EnumTypePlant.AZLOC);

            allEventDico.Add("solarStorm", new EventInfo("solarStorm",
                "Une tempête solaire font griller vos plantes, les gens en rafolent",
                10,
                1.2,
                1.5,
                true,
                false,
                false,
                listPl,
                new List<string>(),
                6,
                0,
                Game.getDefaultSprite(),
                40));

            allEventDico.Add("sucreRef", new EventInfo("sucreRef",
                "Le marché du sucre s'écroule mystérieusement, les gens se retourne vers votre EGRO au gout sucré",
                5,
                1.1,
                2,
                true,
                false,
                false,
                listAnim,
                new List<string>(),
                6,
                2,
                Game.getDefaultSprite(),
                50));



            //********************************************************************
            //************************ EVENTS NOT COOL ***************************
            //********************************************************************

            List<EnumTypePlant> listElbEgr = new List<EnumTypePlant>();
            listElbEgr.Add(EnumTypePlant.ELB);
            listElbEgr.Add(EnumTypePlant.EGRO);

            allEventDico.Add("wartElbEgr", new EventInfo("wartElbEgr",
                "Des verrus martiennes touchent les recoltes d'EBL et d'EGRO, ça n'a pas bon goût",
                15,
                0.8,
                0.8,
                true,
                false,
                false,
                listElbEgr,
                new List<string>(),
                12,
                0,
                Game.getDefaultSprite(),
                30));


            allEventDico.Add("vegeTrend", new EventInfo("vegeTrend",
                "Une trend végétarienne se développe",
                25,
                0.8,
                0.7,
                true,
                false,
                false,
                listAnim,
                new List<string>(),
                6,
                2,
                Game.getDefaultSprite(),
                50));

            List<EnumTypePlant> listBsTemp = new List<EnumTypePlant>();
            listBsTemp.Add(EnumTypePlant.ELB);
            listBsTemp.Add(EnumTypePlant.EGRO);
            allEventDico.Add("bsTemp", new EventInfo("bsTemp",
                "bsTemp",
                2,
                0.8,
                0.7,
                true,
                false,
                false,
                listBsTemp,
                new List<string>(),
                6,
                2,
                Game.getDefaultSprite(),
                0));

            List<EnumTypePlant> listBsTemp2 = new List<EnumTypePlant>();
            listBsTemp2.Add(EnumTypePlant.ELB);
            listBsTemp2.Add(EnumTypePlant.EGRO);
            allEventDico.Add("bsTemp2", new EventInfo("bsTemp2",
                "bsTemp2",
                2,
                0.8,
                0.7,
                true,
                false,
                false,
                listBsTemp2,
                new List<string>(),
                6,
                2,
                Game.getDefaultSprite(),
                0));


        }

        //get a new event depending on the month, and the impossible event
        /// <summary>
        /// La méthode <c>getRandomEvent</c> permet de générer un nouvel événement en fonction du jour et de l'événement impossible.
        /// </summary>
        /// <param name="day"></param>
        /// <param name="impossibleEvents"></param>
        /// <returns>Elle renvoie un événements.</returns>
        public EventInfo getRandomEvent(int day, Dictionary<EventInfo, int> impossibleEvents)
        {

            Dictionary<string, EventInfo> possibleEvents = substractDico(allEventDico, impossibleEvents);


            if(possibleEvents.Count == 0) //if true, then something is messed up
            {
                return new EventInfo(); //Shit
            }


            int totalProbablity = 0;
            foreach(EventInfo currentEvent in possibleEvents.Values) //calculate the sum of all event probabilites
            {
                if(currentEvent.unlockableAfter > day) //verify if the event is possible
                {
                    totalProbablity += currentEvent.probability; //add the probabilty of the event
                }
            }

            System.Random rnd = new System.Random();
            int randProba = rnd.Next(1, totalProbablity+1); //get a random number between 0 and the sum of all possible events
            EventInfo newEvent = new EventInfo();

            foreach (EventInfo currentEvent in possibleEvents.Values)
            {
                if (currentEvent.unlockableAfter > day) //verify if the event is possible
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
        /// <summary>
        /// La méthode <c>substractDico</c> est utilisée pour avoir les événements possibles en fonction de tous les événements et ceux qui sont impossibles.
        /// </summary>
        /// <param name="dicoOrigin"></param>
        /// <param name="dicoSubstract"></param>
        /// <returns>Elle retourne un dictionnaire(clé : String, valeur : EventInfo) d'événements possibles</returns>
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