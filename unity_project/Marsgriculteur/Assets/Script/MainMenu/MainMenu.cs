using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void PlayGame()
    {
        //permet de charger les scenes qui se trouvent dans buildSettings->Scenes
        //on les trie par nom ou par poisiton sur cette liste
        SceneManager.LoadScene("Map");
    }

    public void QuitGame()
    {
        Debug.Log("HAS QUIT !");
        Application.Quit();
    }

   
}
