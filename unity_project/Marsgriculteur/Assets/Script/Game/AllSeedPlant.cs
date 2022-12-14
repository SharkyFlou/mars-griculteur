using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;


namespace game
{
    /// <summary>
    /// La classe <c>AllSeedPlant</c> s'occupe de toutes les graines et les plantes. (les créer, les parcourir, afficher leur détail en une chaîne de caractères)
    /// Elle possède un dictionnaire qui contient les plantes (et les graines).
    /// </summary>
    [System.Serializable]
    public class AllSeedPlant
    {
        // Objet de r�f�rence instancier au lancement qui permet d'avoir toutes les infos en rapport avec les plantes
        // permet aussi d'instancier/cr�er celle-ci

        private Dictionary<EnumTypePlant, PlantInfo> allPlantDico = new Dictionary<EnumTypePlant, PlantInfo>();

        /// <summary>
        /// Le constructeur <c>AllSeedPlant</c> est utilisé pour instancier avec un Json
        /// </summary>
        /// <param name="allPlantDico"></param>
        [JsonConstructor]
        public AllSeedPlant(Dictionary<EnumTypePlant, PlantInfo> allPlantDico)
        {
            this.allPlantDico = allPlantDico;
        }

        /// <summary>
        /// La méthode <c>createPlant</c> permet de créer les plantes (Plant) celles qui sont recoltées, et qui sont être vendu elles ont un seul sprite (image).
        /// </summary>
        /// <param name="typePlant"></param>
        /// <returns>Elle retourne la plante créée</returns>
        public Plant createPlant(EnumTypePlant typePlant)
        {
            //Debug.Log("on rentre dans le constructor Plant");
            //EnumTypePlant typePlante;
            if (allPlantDico.ContainsKey(typePlant))
            {
                Plant pl = new Plant(typePlant,
                    allPlantDico[typePlant].getId() + 100,
                    typePlant.ToString(),
                    allPlantDico[typePlant].getDesc(),
                    allPlantDico[typePlant].getPlantSprite(),
                    allPlantDico[typePlant].getPlantPrice(),
                    allPlantDico[typePlant].getPlantWeight());
                return pl;
            }
            else
            {
                return new Plant();
            }
        }

        /// <summary>
        /// La méthode <c>createSeed</c> permet de créer une graine.
        /// </summary>
        /// <param name="typePlant"></param>
        /// <returns>Elle retourne la graine créée</returns>
        public Seed createSeed(EnumTypePlant typePlant)
        {
            if (allPlantDico.ContainsKey(typePlant))
            {
                Seed pl = new Seed(typePlant,
                    allPlantDico[typePlant].getId(),
                    typePlant.ToString(),
                    allPlantDico[typePlant].getDesc(),
                    allPlantDico[typePlant].getSeedSprite(),
                    allPlantDico[typePlant].getGrowth(),
                    allPlantDico[typePlant].getSeedWeight(),
                    allPlantDico[typePlant].getSeedPrice());
                return pl;
            }
            else
            {
                return new Seed();
            }
        }

        /// <summary>
        /// La méthode <c>createPlantedPlant</c> permet de créer les plantes qui sont mises dans un plot (champs), elles contienenet un temps de pousse, deux sprites, un quand elles ont pas poussé, un quand elles ont poussé.
        /// </summary>
        /// <param name="typePlant">le type de plante</param>
        /// <returns>Elle retourne la plante (PlantedPlant) créée</returns>
        public PlantedPlant createPlantedPlant(EnumTypePlant typePlant)
        {
            if (allPlantDico.ContainsKey(typePlant))
            {
                PlantedPlant pl = new PlantedPlant(typePlant,
                    allPlantDico[typePlant].getId() + 200,
                    typePlant.ToString(),
                    allPlantDico[typePlant].getDesc(),
                    allPlantDico[typePlant].getPlantSprite(),
                    allPlantDico[typePlant].getPlantedPlantSprites(),
                    allPlantDico[typePlant].getGrowth());
                return pl;
            }
            else
            {
                return new PlantedPlant();
            }
        }

        /// <summary>
        /// La méthode <c>getAllPlantType</c> permet d'avoir la liste des types de plante (ou de graine)
        /// </summary>
        /// <returns>Elle retourne la liste des types de plantes</returns>
        public List<EnumTypePlant> getAllPlantType()
        {
            List<EnumTypePlant> listPl = new();
            foreach (EnumTypePlant typePl in allPlantDico.Keys)
            {
                listPl.Add(typePl);
            }

            return listPl;
        }

        /// <summary>
        /// La méthode <c>ToString</c> permet d'écrire les informations des plantes et des graines.
        /// </summary>
        /// <returns>Elle retourne une chaîne de caractères des informations suivantes pour chaque plante (ou graine) : nom, ID, type, description, durée de pousse, lien de l'image, liste des images, poids, prix</returns>
        public override string ToString()
        {
            string rtrn = string.Empty;
            foreach (KeyValuePair<EnumTypePlant, PlantInfo> kvp in allPlantDico)
            {
                rtrn += kvp.Key + " : \n{";
                rtrn += "\t" + kvp.Value.getId().ToString() + "\n";
                rtrn += "\t" + kvp.Value.getEnum() + "\n";
                rtrn += "\t" + kvp.Value.getDesc() + "\n";
                rtrn += "\t" + kvp.Value.getGrowth().ToString() + "\n";
                rtrn += "\t" + kvp.Value.getSeedSprite().ToString() + "\n";
                rtrn += "\t" + kvp.Value.getPlantSprite().ToString() + "\n";
                rtrn += "\tListe de sprites :\n\t{\n";
                foreach (Sprite sprt in kvp.Value.getPlantedPlantSprites())
                {
                    rtrn += "\t\t" + sprt.ToString() + "\n";
                }
                rtrn += "\t}\n";
                //rtrn += "\t" + kvp.Value.getPlantedPlantSprites().ToString() + "\n";
                rtrn += "\t" + kvp.Value.getSeedWeight().ToString() + "\n";
                rtrn += "\t" + kvp.Value.getPlantWeight().ToString() + "\n";
                rtrn += "\t" + kvp.Value.getSeedPrice().ToString() + "\n";
                rtrn += "\t" + kvp.Value.getPlantPrice() + "\n";
                rtrn += "}";
            }
            return rtrn;
        }

    }

}
