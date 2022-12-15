using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChangeTextError : MonoBehaviour
{
    public TextMeshProUGUI textDesc;
    public TextMeshProUGUI textTitle;

    public void changeText(string title, string desc)
    {
        textTitle.text = title;
        textDesc.text = desc;
    }
}
