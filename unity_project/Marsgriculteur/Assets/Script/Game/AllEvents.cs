using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Le namespace game
/// </summary>
namespace game
{
    /// <summary>
    /// La classe AllEvents permet de lister tous les événements qui peuvent arriver pendant une partie.
    /// Elle utilise son constructeur pour créer tous les événements, et elle contient les méthodes suivantes: <c>getRandomEvent</c>, <c>substractDico</c>, <c>stringInDicoKeys</c>.
    /// Elle contient un dictionnaire qui contient les événements.
    /// </summary>
    public class AllEvents
    {

        public Dictionary<string, EventInfo> allEventDico = new Dictionary<string, EventInfo>();

        /// <summary>
        /// Le constructeur <c>AllEvents</c> permet de créer les événements. Il y a 2 types d'événements : les événements dit "cool" et les événements dit "pas cool".
        /// Les événements sont composés d'un code unique (leur nom), d'une description, d'une durée (combien de temps ils vont durer après leur apparition), de 2 multiplieurs (le premier pour rajouter
        /// un simple multiplieur au prix, par exemple *0.9 ou 1.1, multiplieur fixe qui reste actif tant que l'événement l'est
        /// et le deuxième est un multiplier qui atteint son pic de multiplication au milieu de sa durée, ex : il vaut 2, et l'événemnt dure 5, alors il oscilera à peu près comme ça : 1.33, 1.66, 2, 1.66, 1.33),
        /// ensuite il y a 3 booléens (le premier pour savoir si l'événement atteint les plantes, le deuxième s'il atteint les graines et le troisième s'il atteint les outils.
        /// Ensuite il y a la liste des plantes (ou des graines, ça dépend ce que ça atteint) et la liste des outils, pour les outils atteint.
        /// Les derniers paramètres sont : la probabilité d'apparition de l'événement, un événement ne peut qu'arriver à partir du xième jour,
        /// l'image de l'événement et le dernier paramètres correspond au temps à partir duquel l'événement peut réapparaître après que celui-ci ai commencé (ex : un événement à une durée de 5, un cooldown de 10,
        /// et un unlockAfter de 0, il peut arriver dès le 1er jour, et 10 jours après qu'il soit arrivé il peut réapparaître).
        /// </summary>
        public AllEvents()
        {
            //********************************************************************
            //************************* PLANTES "COOL" ***************************
            //********************************************************************

            List<EnumTypePlant> listAnim = new List<EnumTypePlant>() { EnumTypePlant.EHCAV, EnumTypePlant.OUNTOUM, EnumTypePlant.ELUOP, EnumTypePlant.NIPAL };

            allEventDico.Add("QualiMeat", new EventInfo("QualiMeat",
                "Une onde de radiation donne aux animaux un goût plus salé et très apprécié",
                5,
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
            //EHCAV, ONTOUM, ELUOP, NIPAL

            List<EnumTypePlant> listPl = new List<EnumTypePlant>() { EnumTypePlant.ELB, EnumTypePlant.EGRO, EnumTypePlant.AJOS, EnumTypePlant.AZLOC };

            allEventDico.Add("SolarStorm", new EventInfo("SolarStorm",
                "Une tempête solaire fait griller vos plantes ! Tous deviennent fous, et achètent n'importe quoi...",
                7,
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
            allEventDico.Add("EffondrementDuSucre", new EventInfo("EffondrementDuSucre",
                "Le marché du sucre s'écroule mystérieusement, les gens se retournent vers votre EGRO au goût sucré",
                4,
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


            List<EnumTypePlant> listRand = new List<EnumTypePlant>() { EnumTypePlant.EGRO, EnumTypePlant.ELB, EnumTypePlant.AZLOC, EnumTypePlant.EHCAV };
            allEventDico.Add("Covid", new EventInfo("Covid",
                "Le Covid-23 arrive ! Les gens achètent n'importe quoi...",
                8,
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


            List<EnumTypePlant> listAzloNipal = new List<EnumTypePlant>() { EnumTypePlant.AZLOC, EnumTypePlant.NIPAL };
            allEventDico.Add("FêteOportune", new EventInfo("FêteOportune",
               "Le Maire s'est levé du bon pied : il déclare une fête nationale aujourd'hui ! Le plat favori lors des jours de fête : NIPAL farci au AZLOC",
               3,
               1.1,
               2,
               true,
               false,
               false,
               listAzloNipal,
               new List<string>(),
               4,
               10,
               Game.getDefaultSprite(),
               30));

            List<EnumTypePlant> listAll = new List<EnumTypePlant>() { EnumTypePlant.EHCAV, EnumTypePlant.OUNTOUM, EnumTypePlant.ELUOP, EnumTypePlant.NIPAL, EnumTypePlant.ELB, EnumTypePlant.EGRO, EnumTypePlant.AJOS, EnumTypePlant.AZLOC };
            allEventDico.Add("Elon Ma", new EventInfo("Elon Ma",
              "Elon Ma vient de mettre le pied sur Mars ! Il ramène plein de touristes avide de ramener des souvenirs",
              4,
              1.2,
              2,
              true,
              false,
              false,
              listAll,
              new List<string>(),
              10,
              30,
              Game.getDefaultSprite(),
              20));

            List<EnumTypePlant> listEluop = new List<EnumTypePlant>() { EnumTypePlant.ELUOP };
            allEventDico.Add("Combat d'eluop", new EventInfo("Combat d'eluop",
              "Des combats d'eluop clandestins se mutliplient dans la capitale",
              8,
              1.2,
              1.5,
              true,
              false,
              false,
              listEluop,
              new List<string>(),
              10,
              25,
              Game.getDefaultSprite(),
              35));


            allEventDico.Add("Un cirque arrive", new EventInfo("Un cirque arrive",
              "Un cirque arrive, ils ont perdu leurs animaux, ils vont devoir en racheter",
              3,
              1.3,
              1.1,
              true,
              false,
              false,
              listAnim,
              new List<string>(),
              10,
              25,
              Game.getDefaultSprite(),
              35));

            List<EnumTypePlant> listAzlocElb = new List<EnumTypePlant>() { EnumTypePlant.AZLOC, EnumTypePlant.ELB };
            allEventDico.Add("Roi venusien", new EventInfo("Roi venusien",
              "Un roi venusion arrive dans votre ville, les venusions rafolle d'azlol et d'elb",
              10,
              1.2,
              1.3,
              true,
              false,
              false,
              listAzlocElb,
              new List<string>(),
              10,
              30,
              Game.getDefaultSprite(),
              40));


            //********************************************************************
            //************************* PLANTES "PAS COOL" ***********************
            //********************************************************************

            List<EnumTypePlant> listElbEgr = new List<EnumTypePlant>() { EnumTypePlant.ELB, EnumTypePlant.EGRO };
            allEventDico.Add("VerrueMartienne", new EventInfo("VerrueMartienne",
                "Des verrues martiennes touchent les recoltes d'EBL et d'EGRO ! Leur goût n'est pas bon",
                5,
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


            allEventDico.Add("VegeTrend", new EventInfo("VegeTrend",
                "Une trend végétarienne se développe",
                12,
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


            allEventDico.Add("Guerre", new EventInfo("Guerre",
                "C'est la guerre ! Les gens n'ont plus trop les moyens...",
                10,
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


            allEventDico.Add("Scandale", new EventInfo("Scandale",
               "Un scandale éclate : quelqu'un vous aurait vu irradier vos plantes pour les faire pousser plus vite... Votre réputation est salie!",
               10,
               0.7,
               0.8,
               true,
               false,
               false,
               listAll,
               new List<string>(),
               10,
               40,
               Game.getDefaultSprite(),
               70));

            //********************************************************************
            //*************************** GRAINES "COOL" *************************
            //********************************************************************

            allEventDico.Add("NouveauFournisseur", new EventInfo("NouveauFournisseur",
              "Un nouveau fournisseur de graines de plantes vient d'arriver; pour se faire connaître, il instaure temporairement des prix assez bas",
              10,
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

            allEventDico.Add("FournisseurVictime", new EventInfo("FournisseurVictime",
              "Vous avez menacé les familles de vos fournisseurs pour leur demander de vous baisser les prix pendant quelques jours. Vos fournisseurs ont peur de vous... mais ça ne va pas durer",
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
            //*************************** GRAINES "PAS COOL" *********************
            //********************************************************************

            allEventDico.Add("FournisseurCourageux", new EventInfo("FournisseurCourageux",
              "Vous avez menacé les familles de vos fournisseurs pour leur demander de vous baisser les prix pendant quelque jours. Cependant, vos fournissers sont en train de se rebeller, faites vos réserves!",
              10,
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


            allEventDico.Add("HiverRude", new EventInfo("HiverRude",
              "L'hiver a été rude, vos producteurs sont en pénurie!",
              10,
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


            List<EnumTypePlant> listRand2 = new List<EnumTypePlant>() { EnumTypePlant.EHCAV, EnumTypePlant.ELUOP, EnumTypePlant.ELB, EnumTypePlant.AJOS };
            allEventDico.Add("TerreStérile", new EventInfo("TerreStérile",
              "Une comète radioactive a rendu stérile la terre de plusieurs de vos vendeurs de graines",
              10,
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

            allEventDico.Add("GiletsJaunes", new EventInfo("GiletsJaunes",
              "Des gilets jaunes manifestent devant plusieurs de vos fournisseurs de graines.",
              7,
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

            allEventDico.Add("ProtestantsVéganes", new EventInfo("ProtestantsVéganes",
              "Des protestants véganes bloquent vous fournisseurs de graines de viande",
              7,
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
        /// <returns>Elle renvoie un événement.</returns>
        public EventInfo getRandomEvent(int day, Dictionary<EventInfo, int> impossibleEvents)
        {
            Dictionary<string, EventInfo> possibleEvents = substractDico(allEventDico, impossibleEvents);


            if (possibleEvents.Count == 0) //if true, then something is messed up
            {
                Debug.Log("Pas d'event possible :O");
                return null; //Shit
            }


            int totalProbablity = 0;
            foreach (EventInfo currentEvent in possibleEvents.Values) //calculate the sum of all event probabilites
            {
                if (currentEvent.unlockableAfter < day) //verify if the event is possible
                {
                    totalProbablity += currentEvent.probability; //add the probabilty of the event
                }
            }

            if (totalProbablity <= 0)
            {
                return null;
            }

            System.Random rnd = new System.Random();
            int randProba = rnd.Next(1, totalProbablity + 1); //get a random number between 0 and the sum of all possible events
            EventInfo newEvent = new EventInfo();

            foreach (EventInfo currentEvent in possibleEvents.Values)
            {
                if (currentEvent.unlockableAfter < day) //verify if the event is possible
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
                if (!stringInDicoKeys(name, dicoSubstract))
                {
                    newDico.Add(name, currentEvent);
                }
            }
            return newDico;
        }

        /// <summary>
        /// La méthode <c>stringInDicoKeys</c> permet de vérifier si un événement est dans l'inventaire.
        /// </summary>
        /// <param name="toCheck">l'événement à trouver dans l'inventaire</param>
        /// <param name="dicoSubstract">L'inventaire</param>
        /// <returns><c>true</c> si l'événement est dans l'inventaire, <c>false</c> sinon</returns>
        private bool stringInDicoKeys(string toCheck, Dictionary<EventInfo, int> dicoSubstract)
        {
            foreach (EventInfo evt in dicoSubstract.Keys)
            {
                if (evt.namee == toCheck)
                {
                    return true;
                }
            }
            return false;
        }
    }
}