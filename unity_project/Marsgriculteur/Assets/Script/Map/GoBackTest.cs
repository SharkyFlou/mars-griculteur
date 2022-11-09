using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoBackTest : MonoBehaviour
{
    public static void goMainMenu()
    {
        //va sur la scene Main Menu,
        //il faut rajouter les save peut être avant ?
        SceneManager.LoadScene("MainMenu");
    }
}
