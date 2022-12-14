using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace game
{
    /// <summary>
    /// La classe <c>BasicPlant</c> h�rite de la classe parent <c>BasicItem</c>, elle repr�sente la classe m�re des graines et des plantes.
    /// Elle poss�de un attribut typePlante.
    /// </summary>
    public abstract class BasicPlant : BasicItem
    {
        protected EnumTypePlant typePlante;

        /// <summary>
        /// Le constructeur <c>BasicPlant</c> permet de cr�er une plante (ou une graine), de base c'est une plante (ou graine) de bl�
        /// </summary>
        public BasicPlant(){
            typePlante = EnumTypePlant.ELB;
        }

        /// <summary>
        /// Le construceteur <c>BasicPlant</c> (avec un param�tre) permet de cr�er une plante (ou une graine) � partir d'un type de plante (ou de graine)
        /// </summary>
        /// <param name="paraTypePlant"></param>
        public BasicPlant(EnumTypePlant paraTypePlant){
            this.typePlante = paraTypePlant;
        }

        /// <summary>
        /// La m�thode <c>getTypePlante</c> permet d'obtenir le type de la plante (ou de la graine)
        /// </summary>
        /// <returns>Elle retourne le type.</returns>
        public EnumTypePlant getTypePlante()
        {
            return typePlante;
        }
    }
}

