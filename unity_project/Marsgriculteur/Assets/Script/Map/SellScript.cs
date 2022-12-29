using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using game;

/// <summary>
/// La classe <c>SellScript</c> s'occupe de la vente d'une plante. Elle gère le curseur (<c>slider</c>) qui a une valeur de début et une valeur de fin (<c>endValue</c>).
/// La valeur du curseur correspond à l'attribut <c>resValue</c>. Losqu'on vend, on peut choisir une plante (<c>plantChoosed</c>).
/// Les deux derniers attributs sont : market et transformRef. 
/// </summary>
public class SellScript : MonoBehaviour 
{
    public PopUp classePopup;
    public TextMeshProUGUI endValue;
    public TextMeshProUGUI resValue;
    public Slider slider;
    private EnumTypePlant plantChoosed;
    public Market market;
    public Transform transformRef;

    /// <summary>
    /// La méthode <c>Start</c> est utilisée pour le démarrage. Étant donné que Start n'est appelée qu'une seule fois, elle permet d'initialiser les éléments
    /// qui doivent persister tout au long de la vie du script, mais ne doivent être configurés qu'immédiatement avant utilisation.
    /// Pour notre cas elle choisie d'avoir la plante ELB déjà sélectionnée.
    /// </summary>
    void Start()
    {
        plantChoosed = EnumTypePlant.ELB;
    }

    /// <summary>
    /// La méthode <c>changePlant</c> permet de changer la plante sélectionnée.
    /// </summary>
    /// <param name="newPlant">la nouvelle plante</param>
    public void changePlant(EnumTypePlant newPlant)
    {
        plantChoosed = newPlant;
        slider.value = 0;
    }

    /// <summary>
    /// La méthode <c>changeMaxValue</c> permet de changer la valeur maximum du curseur.
    /// </summary>
    /// <param name="maxValue">la nouvelle valeur</param>
    public void changeMaxValue(int maxValue)
    {
        endValue.text = maxValue.ToString();
        slider.maxValue = maxValue;
        slider.value = slider.maxValue;
    }

    /// <summary>
    /// La méthode <c>valueChanged</c> permet de changer la valeur du curseur.
    /// </summary>
    public void valueChanged()
    {

        resValue.text = Math.Round(slider.value) + " : " + (totalPrice());
    }

    /// <summary>
    /// La méthode <c>totalPrice</c> permet d'indiquer la valeur de la somme que va gagner le joueur.
    /// </summary>
    /// <returns>La somme gagné par le joueur s'il vend cette quantité.</returns>
    public int totalPrice()
    {
        int currentValue = (int)Math.Round(slider.value);
        int price = market.getLastPricePlant(plantChoosed);
        return price * currentValue;
    }

    /// <summary>
    /// La méthode <c>sell</c> permet de vendre la quantité de plante souhaitée par le joueur.
    /// </summary>
    public void sell()
    {
        if ((int)Math.Round(slider.value) > 0)
        {
            classePopup.message("VENDU!");
            //StartCoroutine(classePopup.message("VENDU!"));

            BasicPlant plante = CreateAllSeedPlant.dicoPlant.createPlant(plantChoosed);
            CreateAllSeedPlant.mainInventory.SubstractFromInventory(plante, (int)Math.Round(slider.value));
            transformRef.GetComponent<Game>().AddMoney(totalPrice());
            changeMaxValue(0);
        }
    }

}