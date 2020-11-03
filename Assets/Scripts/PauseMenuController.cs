﻿using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{

    // Keep track if the game is paused or not
    public static bool gameIsPaused = false;

    // Reference the UI to control it
    public GameObject pauseMenuUI;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    // Function to resume the game
    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        // Freeze time (timeScale = speed at which speed is passing)
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    // Function to reset the game
    public void ResetButtonClicked()
    {
        BallController bc = GameObject.Find("Ball").GetComponent<BallController>();
        bc.ResetGame();
    }


    // Function to pause the game
    private void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        // Freeze time (timeScale = speed at which speed is passing)
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    // Function to exit back to the start menu
    public void ExitButtonClick()
    {
        // Reset everything so it starts a new game with normal timeScale and 0 points for each side
        Time.timeScale = 1f;
        gameIsPaused = false;
        BallController bc = GameObject.Find("Ball").GetComponent<BallController>();
        bc.ResetGame();
        SceneManager.LoadSceneAsync("StartMenuScene");
    }
}
