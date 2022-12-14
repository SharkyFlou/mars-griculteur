using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Newtonsoft.Json;

namespace game
{
    /// <summary>
    /// La classe <c>AllTools</c> s'occuper des outils (les créer, les lister et afficher leur détail en une chaîne de caractère.
    /// Elle possède un dictionnaire qui regroupe tous les outils.
    /// </summary>
    [System.Serializable]
    public class AllTools
    {
        // Objet de référence instancier au lancement qui permet d'avoir toutes les infos en rapport avec les outils
        // permet aussi d'instancier/créer celle-ci

        Dictionary<string, Tool> dicoTools = new Dictionary<string, Tool>();

        /// <summary>
        /// Le constructeur <c>AllTools</c> est utilisé pour instancier les différents outils avec un Json
        /// </summary>
        /// <param name="tools">dictionnaire instancié par le JSON</param>
        [JsonConstructor]
        public AllTools(Dictionary<string, Tool> tools)
        {
            dicoTools = tools;
        }
        
        /// <summary>
        /// Ce constructeur est l'ancienne façon d'instancier les outils.
        /// </summary>
        public AllTools()
        {
            dicoTools.Add("CHEBE", new Tool(500,
                "CHEBE",
                301,
                "Une super Chebe pour cherber vos parcelles.",
                Game.getDefaultSprite()));

            dicoTools.Add("LLEPE", new Tool(600,
                "LLEPE",
                302,
                "Une super llepe pour lleper vos parcelles.",
                Game.getDefaultSprite()));

            dicoTools.Add("CHEPIO", new Tool(1000,
                "CHEPIO",
                303,
                "Une super chepio pour chipiocher vos parcelles.",
                Game.getDefaultSprite()));

            dicoTools.Add("CHEFOUR", new Tool(1200,
                "CHEFOUR",
                304,
                "Une super chefour pour chefourer vos parcelles.",
                Game.getDefaultSprite()));

            dicoTools.Add("TEAURA", new Tool(1800,
                "TEAURA",
                305,
                "Une super teaura pour teauraer vos parcelles.",
                Game.getDefaultSprite()));

            dicoTools.Add("CHEHA", new Tool(3000,
                "CHEHA",
                306,
                "Une super cheha pour chehaer vos parcelles.",
                Game.getDefaultSprite()));

            dicoTools.Add("SONNEUSEMOIS", new Tool(10000,
               "SONNEUSEMOIS",
               307,
               "Une super soneusemois pour soneusemoiser vos parcelles.",
               Game.getDefaultSprite()));
        }

        /// <summary>
        /// La méthode <c>getAllTools</c> donne tous les noms des outils.
        /// </summary>
        /// <returns>Elle retourne une liste des noms des outils.</returns>
        public List<string> getAllTools()
        {
            List<string> names = new List<string>();
            foreach(string str in dicoTools.Keys)
            {
                names.Add(str);
            }
            return names;

        }


        /// <summary>
        ///  La méthode <c>ToString</c> permet d'écrire les informations des outils.
        /// </summary>
        /// <returns>Elle retourne une chaîne de caractères des informations suivantes pour chaque outil : nom, ID, description, image et prix</returns>
        public override string ToString()
        {
            string rtrn = string.Empty;
            foreach (KeyValuePair<string, Tool> kvp in dicoTools)
            {
                rtrn += kvp.Key + " : \n{";
                rtrn += "\t" + kvp.Value.getName() + "\n";
                rtrn += "\t" + kvp.Value.getId() + "\n";
                rtrn += "\t" + kvp.Value.getDesc() + "\n";
                rtrn += "\t" + kvp.Value.getSprite().ToString() + "\n";
                rtrn += "\t" + kvp.Value.getPrice().ToString() + "\n}\n";
            }


            return rtrn;
        }

    }

}
