using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// La classe <c>GoBackTest</c> permet de revenur au menu.
/// </summary>
public class GoBackTest : MonoBehaviour
{
    /// <summary>
    /// La m�thode <c>goMainMenu</c> permet de charger au menu.
    /// </summary>
    public static void goMainMenu()
    {
        //va sur la scene Main Menu,
        //il faut rajouter les save peut �tre avant ? non
        SceneManager.LoadScene("MainMenu");
    }
}
