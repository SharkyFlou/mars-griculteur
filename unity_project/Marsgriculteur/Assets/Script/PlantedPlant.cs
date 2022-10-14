using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace game
{
    public class PlantedPlant : BasicPlant
    {
        private List<string> spriteLinks = new List<string>();
        private int growthTime;

        public List<string> getSpriteLinks()
        {
            return spriteLinks;
        }

        public int getGrowthTime()
        {
            return growthTime;
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}
