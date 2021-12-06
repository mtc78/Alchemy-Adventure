using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    public CanvasGroup canvas;

    public void PlayGame(){
        //Load next scene in the scene order. Can manually change which scene is loaded depending on parameter value.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
    }

    void Awake(){
        hideOptions();
    }

    public void hideOptions(){
        canvas.alpha = 0f;
        canvas.blocksRaycasts = false;
    }

    public void showOptions(){
        canvas.alpha = 1f;
        canvas.blocksRaycasts = true;
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
