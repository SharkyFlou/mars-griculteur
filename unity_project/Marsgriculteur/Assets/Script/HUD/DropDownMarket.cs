using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using game;
using TMPro;

namespace game
{
    public class DropDownMarket : MonoBehaviour
    {
        public TMP_Dropdown dropdown;

        public Market market;

        public GraphMarket ggraphMarket;

        private List<EnumTypePlant> plTypeList;
        // Start is called before the first frame update
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

        public void updateGraph(int newIndex)
        {
            ggraphMarket.changePlant(plTypeList[newIndex]);
        }
    }
}
