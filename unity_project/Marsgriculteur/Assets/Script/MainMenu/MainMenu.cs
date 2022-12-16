using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// La classe <c>MainMenu</c> permet de d�marrer le jeu et de l'arr�ter.
/// </summary>
public class MainMenu : MonoBehaviour
{
    /// <summary>
    /// La m�thode <c>PlayGame</c> permet de d�marrer le jeu.
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
    /// La m�thode <c>QuitGame</c> permet de quitter le jeu
    /// </summary>
    public void QuitGame()
    {
        Debug.Log("HAS QUIT !");
        Application.Quit();
    }

    /// <summary>
    /// La m�thode <c>mainMenu</c> lance le menu principale (Main Menu).
    /// </summary>
    public void mainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
