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
        double currentValue = Math.Round(slider.value);
        int price = market.getLastPricePlant(plantChoosed);
        resValue.text = currentValue + " : " + (price * currentValue);
    }

}
