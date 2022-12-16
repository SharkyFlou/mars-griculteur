using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

namespace game
{
    /// <summary>
    /// La classe <c>Tool</c> hérite de la classe <c>BasicItem</c>, elle crée les outils
    /// </summary>
    [System.Serializable]
    public class Tool : BasicItem
    {

        /// <summary>
        /// Ce constructeur permet la compilation.
        /// </summary>
        public Tool(){
        }

        /// <summary>
        /// Le constructeur <c>Tool</c> permet de créer un outil
        /// </summary>
        /// <param name="paraPrice">le prix de l'outil</param>
        /// <param name="name">le nom de l'outil</param>
        /// <param name="id">l'id de l'outil</param>
        /// <param name="description">la description de l'outil</param>
        /// <param name="imageLink">l'image de l'outil</param>
        public Tool(int paraPrice, string name, int id, string description, Sprite imageLink){
            this.itemName = name;
            this.id = id;
            this.description = description;
            this.imageLink = imageLink;
            this.price = paraPrice;
        }

        /// <summary>
        /// Le constructeur permet de créer un outil grace au JSON
        /// </summary>
        /// <param name="paraPrice">le prix de l'outil</param>
        /// <param name="name">le nom de l'outil</param>
        /// <param name="id">l'id de l'outil</param>
        /// <param name="description">la description de l'outil</param>
        /// <param name="spriteLink">l'image de l'outil</param>
        [JsonConstructor]
        public Tool(int paraPrice, string name, int id, string description, string spriteLink)
        {
            this.itemName = name;
            this.id = id;
            this.description = description;
            this.imageLink = Resources.Load<Sprite>("Sprites/" + spriteLink);
            this.price = paraPrice;
        }
    }

}
