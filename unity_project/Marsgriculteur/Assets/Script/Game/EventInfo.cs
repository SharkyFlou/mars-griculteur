using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace game
{
    /// <summary>
    /// La classe <c>EventInfo</c> permet de cr�er un �v�nement avec toutes ses informations n�cessaires.
    /// Les �v�nments sont compos�s d'un code unique (leur nom), d'une description, d'une dur�e (combien de temps ils vont durer apr�s leur apparition), de 2 multiplieurs (le premier pour rajouter
    /// un simple multiplieur au prix, par exemple *0.9 ou 1.1, multiplieur fixe qui reste actif tant que l'�vent l'est
    /// et le deuxi�me est un multiplieur qui atteint son pic de multiplication au milieu de sa dur�e, ex : il vaut 2, et l'�v�nement dure 5, alors il oscilera un peu pr�s comme �a : 1.33, 1.66, 2, 1.66, 1.33),
    /// ensuite il y a 3 bool�ens (le premier pour savoir si l'�v�nement atteint les plantes, le deuxi�me si il atteint les graines et le troisi�me si il atteint les outils.
    /// Ensuite il y a la liste des plantes (ou des graines, �a d�pend ce que �a atteint) et la liste des outils, pour les outils atteint.
    /// Les derniers param�tres sont : la probabilit� d'apparition de l'�v�nement, un �v�nement ne peut qu'arriver � partir du xi�me jour,
    /// l'image de l'�v�nement et le dernier param�tre correspond au temps � partir duquel l'�v�nement peut r�appara�tre apr�s que celui-ci est commenc� (ex : un event � une dur�e de 5, un cooldown de 10,
    /// et un unlockAfter de 0, il peut arriver d�s le 1er jour, et 10 jours apr�s qu'il soit arriv�, il peut r�appara�tre).
    /// Elle contient 2 constructeurs, un pour cr�er les �v�nements et un en cas d'erreur.
    /// De plus, elle contient 5 m�thodes, pour obtenir son nom, sa dur�e, sa description et ce que l'�v�nement affecte.
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
        /// Ce premier constructeur permet de cr�er un �v�nement.
        /// </summary>
        /// <param name="namee">le nom de l'�v�nement</param>
        /// <param name="description">la description de l'�v�nement</param>
        /// <param name="lenght">la dur�e de l'�v�nement</param>
        /// <param name="mutliplier">simple multiplieur au prix, multiplieur fixe qui reste actif tant que l'�v�nement l'est</param>
        /// <param name="mutliplierProg">multiplieur qui atteint son pic de multiplication au milieu de sa dur�e</param>
        /// <param name="targetPlant">savoir si l'�v�nement atteint les plantes</param>
        /// <param name="targetSeed">savoir si l'�v�nement atteint les graines</param>
        /// <param name="targetTool">savoir si l'�v�nement atteint les outils</param>
        /// <param name="targetsPlant">liste des plantes (ou des graines) atteintes</param>
        /// <param name="targetsTool">liste des outils atteints</param>
        /// <param name="probability">probabilit� d'apparition de l'�v�nement</param>
        /// <param name="unlockableAfter">un �v�nements ne peut qu'arriver � partir du xi�me jour</param>
        /// <param name="imageLink">le lien de l'image de l'�v�nement</param>
        /// <param name="cooldown">temps � partir duquel l'�v�nement peut r�appara�tre apr�s que celui-ci ai commenc�</param>
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
        /// Ce deuxi�me constructeur permet de cr�er un �v�nement "Error" en cas d'erreur.
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
        /// La m�thode <c>getName</c> permet d'obtenir le nom de l'�v�nement.
        /// </summary>
        /// <returns>Elle retourne son nom</returns>
        public string getName()
        {
            return this.namee;
        }

        /// <summary>
        /// La m�thode <c>getLength</c> permet d'obtenir la dur�e de l'�v�nement.
        /// </summary>
        /// <returns>Elle retourne sa dur�e</returns>
        public int getLength()
        {
            return this.length;
        }

        /// <summary>
        /// La m�thode <c>getDescription</c> permet d'obtenir la description de l'�v�nement.
        /// </summary>
        /// <returns>Elle retourne sa description</returns>
        public string getDescription()
        {
            return this.description;
        }

        /// <summary>
        /// La m�thode <c>getTarget</c> permet d'obtenir la liste des plantes ou des graines que l'�v�nement affecte.
        /// </summary>
        /// <returns>Elle retourne la cha�ne de caract�res des plantes ou des graines, s�par�es par des virgules</returns>
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
        /// La m�thode <c>ifTarget</c> permet de savoir ce que l'�v�nement atteint.
        /// </summary>
        /// <returns>Une chaine de caract�res qui dit ce que �a atteint</returns>
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