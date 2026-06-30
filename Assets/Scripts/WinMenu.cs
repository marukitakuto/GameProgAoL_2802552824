using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class WinMenu : MonoBehaviour
{

    public TMP_Text scoreText;

    public void ShowWin()
    {
        Debug.Log("ShowWin called");
        scoreText.text = "Final Score: " + ScoreManager.score;
    }
    public void RestartButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
        Time.timeScale = 1;
    }

    public void MainMenuButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Main Menu");
    }
}
