using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// La classe <c>GoBackTest</c> permet de load le menu.
/// </summary>
public class GoBackTest : MonoBehaviour
{
    /// <summary>
    /// La m�thode <c>goMainMenu</c> permet de load le menu
    /// </summary>
    public static void goMainMenu()
    {
        //va sur la scene Main Menu,
        //il faut rajouter les save peut �tre avant ?
        SceneManager.LoadScene("MainMenu");
    }
}
