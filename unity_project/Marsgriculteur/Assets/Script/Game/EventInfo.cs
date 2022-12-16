using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace game
{
    /// <summary>
    /// La classe <c>EventInfo</c> permet de créer un événement avec toutes ses informations nécessaires.
    /// Les événments sont composés d'un code unique (leur nom), d'une description, d'une durée (combien de temps ils vont durer après leur apparition), de 2 multiplieurs (le premier pour rajouter
    /// un simple multiplieur au prix, par exemple *0.9 ou 1.1, multiplieur fixe qui reste actif tant que l'évent l'est
    /// et le deuxième est un multiplieur qui atteint son pic de multiplication au milieu de sa durée, ex : il vaut 2, et l'événement dure 5, alors il oscilera un peu près comme ça : 1.33, 1.66, 2, 1.66, 1.33),
    /// ensuite il y a 3 booléens (le premier pour savoir si l'événement atteint les plantes, le deuxième si il atteint les graines et le troisième si il atteint les outils.
    /// Ensuite il y a la liste des plantes (ou des graines, ça dépend ce que ça atteint) et la liste des outils, pour les outils atteint.
    /// Les derniers paramètres sont : la probabilité d'apparition de l'événement, un événement ne peut qu'arriver à partir du xième jour,
    /// l'image de l'événement et le dernier paramètre correspond au temps à partir duquel l'événement peut réapparaître après que celui-ci est commencé (ex : un event à une durée de 5, un cooldown de 10,
    /// et un unlockAfter de 0, il peut arriver dès le 1er jour, et 10 jours après qu'il soit arrivé, il peut réapparaître).
    /// Elle contient 2 constructeurs, un pour créer les événements et un en cas d'erreur.
    /// De plus, elle contient 5 méthodes, pour obtenir son nom, sa durée, sa description et ce que l'événement affecte.
    /// </summary>
    public class EventInfo
    {
        public string namee;
        public string description;
        public int length;
        public double mutliplierBase;
        public double mutliplierProg;
        public bool targetPlant;
        public bool targetSeed;
        public bool targetTool;
        public List<EnumTypePlant> targetsPlant = new List<EnumTypePlant>();
        public List<string> targetsTool = new List<string>();
        public int probability;
        public int unlockableAfter;
        public Sprite imageLink;
        public int cooldown;

        /// <summary>
        /// Ce premier constructeur permet de créer un événement.
        /// </summary>
        /// <param name="namee">le nom de l'événement</param>
        /// <param name="description">la description de l'événement</param>
        /// <param name="lenght">la durée de l'événement</param>
        /// <param name="mutliplier">simple multiplieur au prix, multiplieur fixe qui reste actif tant que l'événement l'est</param>
        /// <param name="mutliplierProg">multiplieur qui atteint son pic de multiplication au milieu de sa durée</param>
        /// <param name="targetPlant">savoir si l'événement atteint les plantes</param>
        /// <param name="targetSeed">savoir si l'événement atteint les graines</param>
        /// <param name="targetTool">savoir si l'événement atteint les outils</param>
        /// <param name="targetsPlant">liste des plantes (ou des graines) atteintes</param>
        /// <param name="targetsTool">liste des outils atteints</param>
        /// <param name="probability">probabilité d'apparition de l'événement</param>
        /// <param name="unlockableAfter">un événements ne peut qu'arriver à partir du xième jour</param>
        /// <param name="imageLink">le lien de l'image de l'événement</param>
        /// <param name="cooldown">temps à partir duquel l'événement peut réapparaître après que celui-ci ai commencé</param>
        public EventInfo(string namee,
            string description,
            int lenght,
            double mutliplier,
            double mutliplierProg,
            bool targetPlant,
            bool targetSeed,
            bool targetTool,
            List<EnumTypePlant> targetsPlant,
            List<string> targetsTool,
            int probability,
            int unlockableAfter,
            Sprite imageLink,
            int cooldown)
        {
            this.namee = namee;
            this.description = description;
            this.length = lenght;
            this.mutliplierBase = mutliplier;
            this.mutliplierProg = mutliplierProg;
            this.targetPlant = targetPlant;
            this.targetSeed = targetSeed;
            this.targetTool = targetTool;
            this.targetsPlant = targetsPlant;
            this.targetsTool = targetsTool;
            this.probability = probability;
            this.unlockableAfter = unlockableAfter;
            this.imageLink = imageLink;
            this.cooldown = cooldown;
        }

        /// <summary>
        /// Ce deuxième constructeur permet de créer un événement "Error" en cas d'erreur.
        /// </summary>
        public EventInfo()
        {
            this.namee = "Error";
            this.description = "Error, using an empty constructor";
            this.length = -1;
            this.mutliplierBase = -1;
            this.mutliplierProg = 0;
            this.targetPlant = false;
            this.targetSeed = false;
            this.targetTool = false;
            this.targetsPlant = new List<EnumTypePlant>();
            this.targetsTool = new List<string>();
            this.probability = -1;
            this.unlockableAfter = -1;
            this.imageLink = Game.getDefaultSprite();
            this.cooldown = -1;
        }

        /// <summary>
        /// La méthode <c>getName</c> permet d'obtenir le nom de l'événement.
        /// </summary>
        /// <returns>Elle retourne son nom</returns>
        public string getName()
        {
            return this.namee;
        }

        /// <summary>
        /// La méthode <c>getLength</c> permet d'obtenir la durée de l'événement.
        /// </summary>
        /// <returns>Elle retourne sa durée</returns>
        public int getLength()
        {
            return this.length;
        }

        /// <summary>
        /// La méthode <c>getDescription</c> permet d'obtenir la description de l'événement.
        /// </summary>
        /// <returns>Elle retourne sa description</returns>
        public string getDescription()
        {
            return this.description;
        }

        /// <summary>
        /// La méthode <c>getTarget</c> permet d'obtenir la liste des plantes ou des graines que l'événement affecte.
        /// </summary>
        /// <returns>Elle retourne la chaîne de caractères des plantes ou des graines, séparées par des virgules</returns>
        public string getTarget()
        {
            string rtr = string.Empty;
            for (int i = 0; i < targetsPlant.Count; i++)
            {
                rtr += targetsPlant[i] + ", ";
            }
            if(rtr.Length <= 0)
            {
                return rtr;
            }
            rtr = rtr.Substring(0, rtr.Length - 2);
            return rtr;
        }

        /// <summary>
        /// La méthode <c>ifTarget</c> permet de savoir ce que l'événement atteint.
        /// </summary>
        /// <returns>Une chaine de caractères qui dit ce que ça atteint</returns>
        public string ifTarget()
        {
            if (this.targetSeed == true)
            {
                return "Les graines de : ";
            }
            else if (this.targetPlant == true)
            {
                return "Les plantes de : ";
            }
            else
            {
                return "Les outils : ";
            }
        }
    }
}