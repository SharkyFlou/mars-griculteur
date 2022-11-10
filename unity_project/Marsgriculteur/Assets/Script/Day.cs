using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Day : MonoBehaviour
{
    public int day;
    public TextMeshProUGUI dayText;

    public void AddDay()
    {
        day += 1;
        dayText.SetText(day.ToString());
    }
}
