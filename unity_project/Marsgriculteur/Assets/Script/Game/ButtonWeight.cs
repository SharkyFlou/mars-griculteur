using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using game;
using TMPro;
using static UnityEditor.Progress;


public class ButtonWeight : MonoBehaviour
{
    public void Start()
    {
        CreateAllSeedPlant.mainInventory.boughtMoreSpace();
        TextMeshProUGUI[] texts = this.transform.root.GetComponentsInChildren<TextMeshProUGUI>();
        foreach (TextMeshProUGUI text in texts)
        {
            if (text.name == "TextWeight")
            {
                this.transform.root.GetComponentInChildren<InventoryPanel>().updateWeight(text.transform);
            }
        }

    }

}
