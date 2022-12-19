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
    /// <summary>
    /// La méthode <c>Start</c> est utilisée pour le démarrage. Étant donné que Start n'est appelée qu'une seule fois, elle permet d'initialiser les éléments
    /// qui doivent persister tout au long de la vie du script, mais ne doivent être configurés qu'immédiatement avant utilisation.
    /// Ici elle permet d'afficher le score final du joueur :  le nombre de nombre et le chiffre d'affaire
    /// </summary>
    void Start()
    {
        objective.SetText("Votre objectif etait de rassembler " + game.Game.moneyObjective.ToString() + "$");
        moneyGained.SetText("Vous avez gagne au total " + qttMoney + "$ durant votre partie.");
        nbDays.SetText("Vous avez rempli l'objectif en " + nbDay + " jours.");
    }
}
