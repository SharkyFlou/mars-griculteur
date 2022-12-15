using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// La classe <c>MainMenu</c> permet de démarrer le jeu et de l'arrêter.
/// </summary>
public class MainMenu : MonoBehaviour
{
    /// <summary>
    /// La méthode <c>PlayGame</c> permet de démarrer le jeu.
    /// </summary>
    public void PlayGame(int objec)
    {
        //permet de charger les scenes qui se trouvent dans buildSettings->Scenes
        //on les trie par nom ou par poisiton sur cette liste

        game.Game.moneyObjective = objec;
        SceneManager.LoadScene("Map");
        //GameObject.Find("Money").GetComponent<Game>().moneyObjective = objec;
    }

    /// <summary>
    /// La méthode <c>QuitGame</c> permet de quitter le jeu
    /// </summary>
    public void QuitGame()
    {
        Debug.Log("HAS QUIT !");
        Application.Quit();
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

   
}
