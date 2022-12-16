using UnityEngine;
using game;

/// <summary>
/// La classe <c>MarketBase</c> permet d'instancier le market
/// </summary>
public class marketBase : MonoBehaviour
{
    Market market;

    /// <summary>
    /// La m�thode <c>Start</c> est utilis�e pour le d�marrage. Etant donn� que Start n'est appel�e qu'une seule fois, elle permet d'initialiser les �l�ments
    /// qui doivent persister tout au long de la vie du script, mais ne doivent �tre configur�s qu'imm�diatement avant utilisation.
    /// Pour notre cas elle permet d'initialiser le march�.
    /// Une m�thode de singleton est utilis�e afin de n'avoir qu'un seul march�, m�thode non-obligatoire.
    /// </summary>
    void Start()
    {
        market = Market.instance;
    }
}
