using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace game
{
    abstract public class BasicPlant : BasicItem
    {
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

