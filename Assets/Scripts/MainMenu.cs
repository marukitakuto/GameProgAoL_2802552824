using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void LoadGame()
    {
        PlayerPrefs.SetInt("LoadGame", 1);
        SceneManager.LoadScene("Game");
    }

    // Update is called once per frame
    public void QuitGame()
    {
        Application.Quit();
    }
}
