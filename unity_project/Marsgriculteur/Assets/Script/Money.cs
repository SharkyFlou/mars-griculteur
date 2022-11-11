using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Money : MonoBehaviour
{
    public int money;
    public TextMeshProUGUI moneyText;

    public void AddMoney(int price)
    {
        money += price;
        moneyText.SetText(money.ToString());
    }

    public void SubsMoney(int price)
    {
        money -= price;
        moneyText.SetText(money.ToString());
    }
}
