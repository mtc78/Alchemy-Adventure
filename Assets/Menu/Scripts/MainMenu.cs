using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame(){
        //Load next scene in the scene order. Can manually change which scene is loaded depending on parameter value.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
    }

    public void QuitGame(){
        Application.Quit();
    }

    public void Menu()
    {
        //Loads main menu
        SceneManager.LoadScene(0);
    }

    public void Restart()
    {
        //Loads level 1.
        SceneManager.LoadScene(1);
    }

}
