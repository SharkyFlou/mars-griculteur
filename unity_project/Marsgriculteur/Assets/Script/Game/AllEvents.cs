using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace game
{
    /// <summary>
    /// La classe AllEvents permet de lister tous les événements qui peuvent arriver pendant une partie.
    /// Elle utilise son constructeur pour créer tous les événements, et elle contient 2 méthodes : <c>getRandomEvent</c> et <c>substractDico</c>.
    /// Elle contient un dictionnaire qui contient les événements.
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
            //************************* PLANT COOL *******************************
            //********************************************************************

            List<EnumTypePlant> listAnim = new List<EnumTypePlant>() { EnumTypePlant.ECHAV, EnumTypePlant.ONTOUM, EnumTypePlant.ELUOP, EnumTypePlant.NIPAL };
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

            List<EnumTypePlant> listPl = new List<EnumTypePlant>() { EnumTypePlant.ELB , EnumTypePlant.EGRO, EnumTypePlant.AJOS, EnumTypePlant.AZLOC };

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

            List<EnumTypePlant> listEgro = new List<EnumTypePlant>() { EnumTypePlant.EGRO };
            allEventDico.Add("sucreEfondrement", new EventInfo("sucreEfondrement",
                "Le marché du sucre s'écroule mystérieusement, les gens se retourne vers votre EGRO au gout sucré",
                5,
                1.1,
                2,
                true,
                false,
                false,
                listEgro,
                new List<string>(),
                6,
                2,
                Game.getDefaultSprite(),
                50));


            List<EnumTypePlant> listRand = new List<EnumTypePlant>() { EnumTypePlant.EGRO, EnumTypePlant.ELB, EnumTypePlant.AZLOC, EnumTypePlant.ECHAV };
            allEventDico.Add("covid", new EventInfo("covid",
                "Le covid arrive, les gens achètent n'importe quoi...",
                10,
                1.1,
                1.2,
                true,
                false,
                false,
                listRand,
                new List<string>(),
                6,
                0,
                Game.getDefaultSprite(),
                30));


            allEventDico.Add("feteOportune", new EventInfo("feteOportune",
               "Le Maire s'est levé du bon pied, il déclare une fête national aujourd'hui ! Le plat favori lors des jours de fête : NIPAL farci aux AZLOC",
               5,
               1.1,
               2,
               true,
               false,
               false,
               listAnim,
               new List<string>(),
               4,
               10,
               Game.getDefaultSprite(),
               30));



            //********************************************************************
            //************************* PLANT NOT COOL ***************************
            //********************************************************************

            List<EnumTypePlant> listElbEgr = new List<EnumTypePlant>() { EnumTypePlant.ELB, EnumTypePlant.EGRO };
            allEventDico.Add("verrueELBEGRO", new EventInfo("verrueELBEGRO",
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

            List<EnumTypePlant> listAll = new List<EnumTypePlant>() { EnumTypePlant.ECHAV, EnumTypePlant.ONTOUM, EnumTypePlant.ELUOP, EnumTypePlant.NIPAL, EnumTypePlant.ELB, EnumTypePlant.EGRO, EnumTypePlant.AJOS, EnumTypePlant.AZLOC };
            allEventDico.Add("guerre", new EventInfo("guerre",
                "C'est la guerre, les gens n'ont plus trop les moyens...",
                40,
                0.9,
                0.6,
                true,
                false,
                false,
                listAnim,
                new List<string>(),
                6,
                30,
                Game.getDefaultSprite(),
                70));


            allEventDico.Add("scandale", new EventInfo("scandale",
               "Un scandale éclate, quelqu'un vous aurait vu irradier vos plantes pour les faire pousser plus vite, bonne chance...",
               40,
               0.7,
               0.8,
               true,
               false,
               false,
               listAnim,
               new List<string>(),
               10,
               40,
               Game.getDefaultSprite(),
               70));

            //********************************************************************
            //*************************** GRAINES * ******************************
            //********************************************************************

            allEventDico.Add("nouveauFournisseur", new EventInfo("nouveauFournisseur",
              "Un nouveau fournisseur de graines de plantes vient d'arriver, pour se faire connaitre il instaure temporairement des prix assez bas",
              20,
              0.8,
              0.9,
              false,
              true,
              false,
              listPl,
              new List<string>(),
              6,
              0,
              Game.getDefaultSprite(),
              40));

            allEventDico.Add("fournisseurVictime", new EventInfo("fournisseurVictime",
              "Vous avez menacé les familles de vos fournisseurs pour leur demander de vous baisser les prix pendant quelque jours, vos fournisseurs ont peur de vous... ça ne va pas durer",
              5,
              0.7,
              0.9,
              false,
              true,
              false,
              listAll,
              new List<string>(),
              2,
              0,
              Game.getDefaultSprite(),
              40));



            //********************************************************************
            //*************************** GRAINES PAS COOL************************
            //********************************************************************

            allEventDico.Add("fournisseurCourageu", new EventInfo("fournisseurCourageu",
              "Vous avez menacé les familles de vos fournisseurs pour leur demander de vous baisser les prix pendant quelque jours, vos fournissers sont en train de se rebeller, faîtes vos reserves...",
              20,
              1.1,
              3,
              false,
              true,
              false,
              listAll,
              new List<string>(),
              3,
              0,
              Game.getDefaultSprite(),
              40));


            allEventDico.Add("hiverRude", new EventInfo("hiverRude",
              "L'hiver a été rude, vos producteurs de graines l'ont sentit passer",
              20,
              1.3,
              1.2,
              false,
              true,
              false,
              listAll,
              new List<string>(),
              6,
              10,
              Game.getDefaultSprite(),
              40));


            List<EnumTypePlant> listRand2 = new List<EnumTypePlant>() { EnumTypePlant.ECHAV, EnumTypePlant.ELUOP, EnumTypePlant.ELB, EnumTypePlant.AJOS};
            allEventDico.Add("terreSteril", new EventInfo("terreSteril",
              "Une comète radioactive a rendu stéril la terre de plusieurs de vos vendeurs de graines",
              30,
              1.5,
              1.8,
              false,
              true,
              false,
              listRand2,
              new List<string>(),
              6,
              10,
              Game.getDefaultSprite(),
              40));

            allEventDico.Add("giletsJaunes", new EventInfo("giletsJaunes",
              "Des gilets jaunes manifestent devant plusieurs de vos fournisseurs de graines, les graines vont se faire rare",
              15,
              3,
              4,
              false,
              true,
              false,
              listRand,
              new List<string>(),
              6,
              0,
              Game.getDefaultSprite(),
              30));

            allEventDico.Add("protestantsVegans", new EventInfo("protestantsVegans",
              "Des protestants vegan bloquent vous fournisseurs de graines de viande",
              15,
              3,
              4,
              false,
              true,
              false,
              listAnim,
              new List<string>(),
              6,
              0,
              Game.getDefaultSprite(),
              30));

        }

        /// <summary>
        /// La méthode <c>getRandomEvent</c> permet de générer un nouvel événement en fonction du jour et de l'événement impossible.
        /// </summary>
        /// <param name="day">le jour actuel</param>
        /// <param name="impossibleEvents">le dictionnaire qui correspond aux événements impossibles</param>
        /// <returns>Elle renvoie un événements.</returns>
        public EventInfo getRandomEvent(int day, Dictionary<EventInfo, int> impossibleEvents)
        {
            Dictionary<string, EventInfo> possibleEvents = substractDico(allEventDico, impossibleEvents);


            Debug.Log("Truc subtract : " + day + " Nombre d'event possible : " + possibleEvents.Count);
            foreach (var evt in possibleEvents)
            {
                Debug.Log("Jour : " + day + " event possible " + evt.Value.namee);
            }

            Debug.Log("Tout les events : " + allEventDico.Count);
            foreach (var evt in allEventDico)
            {
                Debug.Log(" event existant " + evt.Value);
            }



            if (possibleEvents.Count == 0) //if true, then something is messed up
            {
                Debug.Log("Pas d'event possible :O");
                return null; //Shit
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

        /// <summary>
        /// La méthode <c>substractDico</c> est utilisée pour avoir les événements possibles en fonction de tous les événements et ceux qui sont impossibles.
        /// </summary>
        /// <param name="dicoOrigin">dictionnaire qui contient tous les événements</param>
        /// <param name="dicoSubstract">dictionnaire qui contient les événements impossibles</param>
        /// <returns>Elle retourne un dictionnaire(clé : String, valeur : EventInfo) d'événements possibles</returns>
        private Dictionary<string, EventInfo> substractDico(Dictionary<string, EventInfo> dicoOrigin, Dictionary<EventInfo, int> dicoSubstract)
        {
            Dictionary<string, EventInfo> newDico = new Dictionary<string, EventInfo>();
            EventInfo currentEvent;
            foreach (string name in dicoOrigin.Keys)
            {
                currentEvent = dicoOrigin[name];
                if (!dicoSubstract.ContainsKey(currentEvent))
                {
                    newDico.Add(name, currentEvent);
                }
            }
            return newDico;
        }
    }
}