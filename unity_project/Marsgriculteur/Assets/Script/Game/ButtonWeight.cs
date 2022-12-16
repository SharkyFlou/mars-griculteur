using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using game;
using TMPro;

/// <summary>
/// La classe <c>ButtonWeight</c> permet de donner plus de place � l'inventaire du joueur.
/// Elle poss�de un attribut moneyStack.
/// </summary>
public class ButtonWeight : MonoBehaviour
{
    public Game moneyStack;

    /// <summary>
    /// La m�thode <c>Start</c> est utilis�e pour le d�marrage. Etant donn� que Start n'est appel�e qu'une seule fois, elle permet d'initialiser les �l�ments
    /// qui doivent persister tout au long de la vie du script, mais ne doivent �tre configur�s qu'imm�diatement avant utilisation.
    /// Pour notre cas elle permet d'enlever de l'argent au joueur et de lui ajouter de la capacit� dans son inventaire.
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
