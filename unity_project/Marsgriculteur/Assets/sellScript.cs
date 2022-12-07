using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using game;
using Unity.VisualScripting;
using System;

public class sellScript : MonoBehaviour
{
    public TextMeshProUGUI endValue;
    public TextMeshProUGUI resValue;
    public Slider slider;
    private EnumTypePlant plantChoosed;
    public Market market;
    public Transform panelInfosVente;

    void Start()
    {
        plantChoosed = EnumTypePlant.ELB;
    }

    public void changePlant(EnumTypePlant newPlant)
    {
        plantChoosed = newPlant;
    }

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
        panelInfosVente.GetComponent<Game>().AddMoney(totalPrice());
        changeMaxValue(0);
    }

}
