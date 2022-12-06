using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace game
{
    public class Seed : BasicPlant
    {
        private int timeGrowth;
        
        public Seed() 
        {

        }
        public Seed(EnumTypePlant paraTypePlant, int paraId, string paraName, string paraDescription, Sprite paraImagelink, int paraTimeGroth, int paraWeight, int paraPrice)
        {
            typePlante = paraTypePlant;
            id = paraId;
            itemName = paraName;
            description = paraDescription;
            imageLink = paraImagelink;
            timeGrowth = paraTimeGroth;
            weight = paraWeight;
            price = paraPrice;
        }
        /*
        // Possible constructeur pour simplifier la syntaxe à la création d'une graine
        // MARCHE SEULEMENT APRES INSTANCIATION DU ALLSEEDPLANT DICO
        public Seed(EnumTypePlant seed)
        {
            CreateAllSeedPlant.dicoPlant.createSeed(seed);
        }*/

        

        public int getTimeGrowth()
        {
            return timeGrowth;
        }

    }

}
