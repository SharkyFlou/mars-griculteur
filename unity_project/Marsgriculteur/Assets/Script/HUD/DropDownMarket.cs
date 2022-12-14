using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using game;
using TMPro;

namespace game
{
    /// <summary>
    /// La classe <c>DropDownMarket</c> permet d'afficher le graphe et les plantes.
    /// Elle possède 4 attributs : dropdown, market, ggraphMarket, plTypeList.
    /// </summary>
    public class DropDownMarket : MonoBehaviour
    {
        public TMP_Dropdown dropdown;

        public Market market;

        public GraphMarket ggraphMarket;

        private List<EnumTypePlant> plTypeList;

        /// <summary>
        /// La méthode <c>Start</c> est utilisée pour le démarrage. Étant donné que Start n'est appelée qu'une seule fois, elle permet d'initialiser les éléments
        /// qui doivent persister tout au long de la vie du script, mais ne doivent être configurés qu'immédiatement avant utilisation.
        /// Pour notre cas elle .............
        /// </summary>
        void Start()
        {
            plTypeList = CreateAllSeedPlant.dicoPlant.getAllPlantType();
            List<Plant> plList = new List<Plant>();
            foreach (EnumTypePlant plType in plTypeList)
            {
                plList.Add(CreateAllSeedPlant.dicoPlant.createPlant(plType));
            }


            dropdown.ClearOptions();


            List<TMP_Dropdown.OptionData> plantItems = new List<TMP_Dropdown.OptionData>();

            foreach (Plant pl in plList)
            {
                TMP_Dropdown.OptionData plantItem = new TMP_Dropdown.OptionData(pl.getName(), pl.getSprite());
                plantItems.Add(plantItem);
            }

            dropdown.AddOptions(plantItems);
        }

        /// <summary>
        /// La méthode <c>updateGraph</c> permet de mettre à jour le graph
        /// </summary>
        /// <param name="newIndex">le nouveau point du graph</param>
        public void updateGraph(int newIndex)
        {
            ggraphMarket.changePlant(plTypeList[newIndex]);
        }
    }
}
