using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace game
{
    /// <summary>
    /// La classe <c>InventorySlot</c> permet de créer un slot pour l'inventaire.
    /// </summary>
    public class InventorySlot : MonoBehaviour
    {
        /// <summary>
        /// La méthode <c>createSlot</c> permet de créer un slot pour un inventaire.
        /// </summary>
        /// <returns>Elle retourne un slot de type GameObject.</returns>
        public static GameObject createSlot()
        {
            return Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/ButtonInvSlot"));
        }
    }
}
