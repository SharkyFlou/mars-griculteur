using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace game
{
    public class InventorySlot : MonoBehaviour
    {
        public static GameObject createSlot()
        {
            return Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/ButtonInvSlot"));
        }
    }
}
