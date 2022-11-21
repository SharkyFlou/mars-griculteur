using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace game
{
    public class AllTools
    {
        Dictionary<String, Tool> dicoTools = new Dictionary<String,Tool>();

        //instantiate all the diferents tools
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

        //return all the tools names
        public List<String> getAllTools()
        {
            List<String> names = new List<String>();
            foreach(String str in dicoTools.Keys)
            {
                names.Add(str);
            }
            return names;

        }
    }

}
