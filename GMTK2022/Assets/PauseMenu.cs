using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    //Denna variabel kan användas överallt för att se om game is paused
    public static bool GameIsPaused = false;

    public GameObject pauseMenuFade;
    public GameObject pauseMenuUI;
    public GameObject pauseOptionMenuUI;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(GameIsPaused){
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume() {
        pauseOptionMenuUI.SetActive(false);
        pauseMenuUI.SetActive(true);
        pauseMenuFade.SetActive(false);
        
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause(){
        pauseMenuFade.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu(){
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame() {
        Debug.Log("Quitting the game");
        Application.Quit();
    }
}
