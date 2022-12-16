using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using game;
using TMPro;

/// <summary>
/// La classe <c>ButtonWeight</c> permet de donner plus de place à l'inventaire du joueur.
/// Elle possède un attribut moneyStack.
/// </summary>
public class ButtonWeight : MonoBehaviour
{
    public Game moneyStack;

    /// <summary>
    /// La méthode <c>Start</c> est utilisée pour le démarrage. Etant donné que Start n'est appelée qu'une seule fois, elle permet d'initialiser les éléments
    /// qui doivent persister tout au long de la vie du script, mais ne doivent être configurés qu'immédiatement avant utilisation.
    /// Pour notre cas elle permet d'enlever de l'argent au joueur et de lui ajouter de la capacité dans son inventaire.
    /// </summary>
    public void Start()
    {
        if (moneyStack.money >= 3000)
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
            moneyStack.SubsMoney(3000);
        }


    }

}
