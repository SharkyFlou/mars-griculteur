using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace game
{
    public abstract class BasicPlant : BasicItem
    {
        // Classe mère des Seed et Plant car ils ont des 

        protected EnumTypePlant typePlante;

        public BasicPlant(){
            typePlante = EnumTypePlant.ELB;
        }

        public BasicPlant(EnumTypePlant paraTypePlant){
            this.typePlante = paraTypePlant;
        }

        public EnumTypePlant getTypePlante()
        {
            return typePlante;
        }
    }
}

