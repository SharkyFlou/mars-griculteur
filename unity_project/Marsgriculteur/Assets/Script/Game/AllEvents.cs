using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace game
{
    /// <summary>
    /// La classe AllEvents permet de lister tous les �v�nements qui peuvent arriver pendant une partie.
    /// Elle utilise son constructeur pour cr�er tous les �v�nements, et elle contient 2 m�thodes : <c>getRandomEvent</c> et <c>substractDico</c>.
    /// Elle contient un dictionnaire qui contient les �v�nements.
    /// </summary>
    public class AllEvents
    {

        //name in first, and YES it already exist in the info of eventInfo, but i dont car 
        public Dictionary<string, EventInfo> allEventDico = new Dictionary<string, EventInfo>();

        /// <summary>
        /// Le constructeur <c>AllEvents</c> permet de cr�er les �v�nements. Il y a 2 types d'�v�nements : les �v�nements dit cools et les �v�nements dit pas cool.
        /// Les �v�nments sont compos�s d'un code unique (leur nom), d'une description, d'une dur�e (combien de temps ils vont durer apr�s leur apparition), de 2 multiplieurs (le premier pour rajouter
        /// un simple multiplier au prix, par exemple *0.9 ou 1.1, multiplier fixe qui reste actif tant que l'�vent l'est
        /// et le deuxi�me est un multiplier qui atteint son pic de multiplication au milieu de sa dur�e, ex : il vaut 2, et l'�vent dure 5, alors il oscilera un peu pr�s comme �a : 1.33, 1.66, 2, 1.66, 1.33),
        /// ensuite il y a 3 bool�ens (le premier pour savoir si l'�v�nement atteint les plantes, le deuxi�me si il atteint les graines et le troisi�me si il atteint les outils.
        /// Ensuite il y a la liste des plantes (ou des graines, �a d�pend ce que �a atteint) et la liste des outils, pour les outils atteint.
        /// Les derniers param�tres sont : la probabilit� d'apparition de l'�v�nement, un �v�nements ne peut qu'arriver � partir du xi�me jour,
        /// l'image de l'�v�nement et le dernier param�tres correspond au temps � partir duquel l'�v�nement peut r�appara�tre apr�s que celui-ci est commenc� (ex : un event � une dur�e de 5, un cooldown de 10,
        /// et un unlockAfter de 0, il peut arriver d�s le 1er jour, et 10 jour apr�s qu'il soit arriv� il peut re arriver).
        /// </summary>
        public AllEvents()
        {
            //********************************************************************
            //************************* PLANT COOL *******************************
            //********************************************************************

            List<EnumTypePlant> listAnim = new List<EnumTypePlant>() { EnumTypePlant.EHCAV, EnumTypePlant.OUNTOUM, EnumTypePlant.ELUOP, EnumTypePlant.NIPAL };
            allEventDico.Add("QualiMeat", new EventInfo("QualiMeat",
                "Une onde de radiation donne aux animaux un goût plus salé et très apprécié",
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
            //EHCAV, ONTOUM, ELUOP, NIPAL

            List<EnumTypePlant> listPl = new List<EnumTypePlant>() { EnumTypePlant.ELB, EnumTypePlant.EGRO, EnumTypePlant.AJOS, EnumTypePlant.AZLOC };

            allEventDico.Add("SolarStorm", new EventInfo("SolarStorm",
                "Une tempête solaire fait griller vos plantes ! Tous deviennent fous, et achètent n'importe quoi...",
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
            allEventDico.Add("EffondrementDuSucre", new EventInfo("EffondrementDuSucre",
                "Le marché du sucre s'écroule mystérieusement, les gens se retournent vers votre EGRO au goût sucré",
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


            List<EnumTypePlant> listRand = new List<EnumTypePlant>() { EnumTypePlant.EGRO, EnumTypePlant.ELB, EnumTypePlant.AZLOC, EnumTypePlant.EHCAV };
            allEventDico.Add("Covid", new EventInfo("Covid",
                "Le Covid-23 arrive ! Les gens achètent n'importe quoi...",
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


            allEventDico.Add("FêteOportune", new EventInfo("FêteOportune",
               "Le Maire s'est levé du bon pied : il déclare une fête nationale aujourd'hui ! Le plat favori lors des jours de fête : NIPAL farci au AZLOC",
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
            allEventDico.Add("VerrueMartienne", new EventInfo("VerrueMartienne",
                "Des verrues martiennes touchent les recoltes d'EBL et d'EGRO ! Leur goût n'est pas bon",
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


            allEventDico.Add("VegeTrend", new EventInfo("VegeTrend",
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

            List<EnumTypePlant> listAll = new List<EnumTypePlant>() { EnumTypePlant.EHCAV, EnumTypePlant.OUNTOUM, EnumTypePlant.ELUOP, EnumTypePlant.NIPAL, EnumTypePlant.ELB, EnumTypePlant.EGRO, EnumTypePlant.AJOS, EnumTypePlant.AZLOC };
            allEventDico.Add("Guerre", new EventInfo("Guerre",
                "C'est la guerre ! Les gens n'ont plus trop les moyens...",
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


            allEventDico.Add("Scandale", new EventInfo("Scandale",
               "Un scandale éclate : quelqu'un vous aurait vu irradier vos plantes pour les faire pousser plus vite... Votre réputation est salie!",
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

            allEventDico.Add("NouveauFournisseur", new EventInfo("NouveauFournisseur",
              "Un nouveau fournisseur de graines de plantes vient d'arriver; pour se faire connaître, il instaure temporairement des prix assez bas",
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
            //*************************** GRAINES PAS COOL************************
            //********************************************************************

            allEventDico.Add("FournisseurCourageux", new EventInfo("FournisseurCourageux",
              "Vous avez menacé les familles de vos fournisseurs pour leur demander de vous baisser les prix pendant quelque jours. Cependant, vos fournissers sont en train de se rebeller, faites vos réserves!",
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


            allEventDico.Add("HiverRude", new EventInfo("HiverRude",
              "L'hiver a été rude, vos producteurs sont en pénurie!",
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


            List<EnumTypePlant> listRand2 = new List<EnumTypePlant>() { EnumTypePlant.EHCAV, EnumTypePlant.ELUOP, EnumTypePlant.ELB, EnumTypePlant.AJOS };
            allEventDico.Add("TerreStérile", new EventInfo("TerreStérile",
              "Une comète radioactive a rendu stérile la terre de plusieurs de vos vendeurs de graines",
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

            allEventDico.Add("GiletsJaunes", new EventInfo("GiletsJaunes",
              "Des gilets jaunes manifestent devant plusieurs de vos fournisseurs de graines.",
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

            allEventDico.Add("ProtestantsVéganes", new EventInfo("ProtestantsVéganes",
              "Des protestants véganes bloquent vous fournisseurs de graines de viande",
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
        /// La m�thode <c>getRandomEvent</c> permet de g�n�rer un nouvel �v�nement en fonction du jour et de l'�v�nement impossible.
        /// </summary>
        /// <param name="day">le jour actuel</param>
        /// <param name="impossibleEvents">le dictionnaire qui correspond aux �v�nements impossibles</param>
        /// <returns>Elle renvoie un �v�nements.</returns>
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
        /// La m�thode <c>substractDico</c> est utilis�e pour avoir les �v�nements possibles en fonction de tous les �v�nements et ceux qui sont impossibles.
        /// </summary>
        /// <param name="dicoOrigin">dictionnaire qui contient tous les �v�nements</param>
        /// <param name="dicoSubstract">dictionnaire qui contient les �v�nements impossibles</param>
        /// <returns>Elle retourne un dictionnaire(cl� : String, valeur : EventInfo) d'�v�nements possibles</returns>
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