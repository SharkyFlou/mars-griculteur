using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace game
{
    public interface InventoryInterface
    {

        public void afficheInventory(Dictionary<BasicItem, int> dico);
    }
}
