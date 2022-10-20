using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace game
{
    public class Plant : BasicPlant
    {
        public Plant(EnumTypePlant paraTypePlant, int paraId, string paraName, string paraDescription, string paraImagelink){
            this.typePlante = paraTypePlant;
            this.id = paraId;
            this.name = paraName;
            this.description = paraDescription;
            this.imageLink = paraImagelink;
        }
    }

}
