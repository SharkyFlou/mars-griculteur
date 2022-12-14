using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using game;
using Unity.VisualScripting;
using System;

/// <summary>
/// La classe <c>SellScript</c> s'occupe de la vente d'une plante. Elle gère le curseur (<c>slider</c>) qui a une valeur de début et une valeur de fin (<c>endValue</c>).
/// La valeur du curseur correspond à l'attribut <c>resValue</c>. Losqu'on vend, on peut choisir une plante (<c>plantChoosed</c>).
/// Les deux derniers attributs sont : market et transformRef.
/// </summary>
public class SellScript : MonoBehaviour
{
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
    }

    /// <summary>
    /// La méthode <c>changeMaxValue</c>
    /// </summary>
    /// <param name="maxValue"></param>
    public void changeMaxValue(int maxValue)
    {
        endValue.text = maxValue.ToString();
        slider.value = 0;
        slider.maxValue = maxValue;
    }

    public void valueChanged()
    {
        
        resValue.text = Math.Round(slider.value) + " : " + (totalPrice());
    }

    public int totalPrice()
    {
        int currentValue = (int)Math.Round(slider.value);
        int price = market.getLastPricePlant(plantChoosed);
        return price * currentValue;
    }
    
    public void sell()
    {
        BasicPlant plante = CreateAllSeedPlant.dicoPlant.createPlant(plantChoosed);
        CreateAllSeedPlant.mainInventory.SubstractFromInventory(plante, (int)Math.Round(slider.value));
        transformRef.GetComponent<Game>().AddMoney(totalPrice());
        changeMaxValue(0);
    }

}
