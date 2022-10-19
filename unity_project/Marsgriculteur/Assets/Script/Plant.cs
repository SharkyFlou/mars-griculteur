using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace game
{
    public class Plant : BasicPlant
    {
        private EnumTypePlant typePlant;

        public Plant(EnumTypePlant typePlante){
            this.typePlant = typePlante;
        }
    }

}

