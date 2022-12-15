using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using game;

/// <summary>
/// La classe <c>MainMenu</c> permet de démarrer le jeu et de l'arrêter.
/// </summary>
public class MainMenu : MonoBehaviour
{
    /// <summary>
    /// La méthode <c>PlayGame</c> permet de démarrer le jeu.
    /// </summary>
    public void PlayGame(int gameLength)
    {
        //permet de charger les scenes qui se trouvent dans buildSettings->Scenes
        //on les trie par nom ou par poisiton sur cette liste
        NextDay.gameLength = gameLength;
        SceneManager.LoadScene("Map");
    }

    /// <summary>
    /// La méthode <c>QuitGame</c> permet de quitter le jeu
    /// </summary>
    public void QuitGame()
    {
        Debug.Log("HAS QUIT !");
        Application.Quit();
    }

   
}
