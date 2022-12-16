using UnityEngine;
using game;

/// <summary>
/// La classe <c>MarketBase</c> permet d'instancier le market
/// </summary>
public class marketBase : MonoBehaviour
{
    Market market;

    /// <summary>
    /// La méthode <c>Start</c> est utilisée pour le démarrage. Etant donné que Start n'est appelée qu'une seule fois, elle permet d'initialiser les éléments
    /// qui doivent persister tout au long de la vie du script, mais ne doivent être configurés qu'immédiatement avant utilisation.
    /// Pour notre cas elle permet d'initialiser le marché.
    /// Une méthode de singleton est utilisée afin de n'avoir qu'un seul marché, méthode non-obligatoire.
    /// </summary>
    void Start()
    {
        market = Market.instance;
    }
}
