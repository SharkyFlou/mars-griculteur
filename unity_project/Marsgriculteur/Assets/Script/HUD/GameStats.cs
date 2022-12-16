using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStats : MonoBehaviour
{

    public static string qttMoney;

    public static string nbDay;

    public TextMeshProUGUI objective;

    public TextMeshProUGUI moneyGained;

    public TextMeshProUGUI nbDays;
    // Start is called before the first frame update
    void Start()
    {
        objective.SetText("Votre objectif etait de rassembler 300000$");
        moneyGained.SetText("Vous avez gagner au total 1108231$ durant votre partie.");
        nbDays.SetText("Vous avez remplie l'objectif en 67 jours.");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
