using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using game;

/// <summary>
/// La classe <c>MainMenu</c> permet de d�marrer le jeu et de l'arr�ter.
/// </summary>
public class MainMenu : MonoBehaviour
{
    /// <summary>
    /// La m�thode <c>PlayGame</c> permet de d�marrer le jeu.
    /// </summary>
    public void PlayGame(int gameLength)
    {
        //permet de charger les scenes qui se trouvent dans buildSettings->Scenes
        //on les trie par nom ou par poisiton sur cette liste
        NextDay.gameLength = gameLength;
        SceneManager.LoadScene("Map");
    }

    /// <summary>
    /// La m�thode <c>QuitGame</c> permet de quitter le jeu
    /// </summary>
    public void QuitGame()
    {
        Debug.Log("HAS QUIT !");
        Application.Quit();
    }

   
}
