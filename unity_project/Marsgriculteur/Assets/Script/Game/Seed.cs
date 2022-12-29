using UnityEngine;


namespace game
{
    /// <summary>
    /// La classe <c>Seed</c> h�rite de BasicPlant. Elle s'occupe des graines, elle les cr�e.
    /// Elle poss�de qu'un attribut : le temps de pousse.
    /// </summary>
    public class Seed : BasicPlant
    {
        private int timeGrowth;
        /// <summary>
        /// Ce constructeur est juste l� pour la compilation.
        /// </summary>
        public Seed() 
        {

        }

        /// <summary>
        /// Le constructeur permet de cr�er une graine
        /// </summary>
        /// <param name="paraTypePlant">le type de la plante que la graine va repr�senter</param>
        /// <param name="paraId">l'id de la graine</param>
        /// <param name="paraName">le nom de la graine</param>
        /// <param name="paraDescription">la description de la graine</param>
        /// <param name="paraImagelink">l'image de la graine</param>
        /// <param name="paraTimeGrowth">le temps de pousse de la graine</param>
        /// <param name="paraWeight">le poids de la graine</param>
        /// <param name="paraPrice">le prix de la graine</param>
        public Seed(EnumTypePlant paraTypePlant, int paraId, string paraName, string paraDescription, Sprite paraImagelink, int paraTimeGrowth, int paraWeight, int paraPrice)
        {
            typePlante = paraTypePlant;
            id = paraId;
            itemName = paraName;
            description = paraDescription;
            imageLink = paraImagelink;
            timeGrowth = paraTimeGrowth;
            weight = paraWeight;
            price = paraPrice;
        }
        /*
        // Possible constructeur pour simplifier la syntaxe � la cr�ation d'une graine
        // MARCHE SEULEMENT APRES INSTANCIATION DU ALLSEEDPLANT DICO
        public Seed(EnumTypePlant seed)
        {
            CreateAllSeedPlant.dicoPlant.createSeed(seed);
        }*/


        /// <summary>
        /// La m�thode <c>getTimeGrowth</c> permet de conna�tre le temps de pousse de la graine.
        /// </summary>
        /// <returns>Elle retourne le temps de pousse</returns>
        public int getTimeGrowth()
        {
            return timeGrowth;
        }

    }

}
