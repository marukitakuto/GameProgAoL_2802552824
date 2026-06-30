using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public Transform player;
    public Player playerScript;

    void Start()
    {
        if (PlayerPrefs.GetInt("LoadGame", 0) == 1)
        {
            LoadGame();
            PlayerPrefs.SetInt("LoadGame", 0);
        }
    }
    public void SaveGame()
    {
        PlayerPrefs.SetFloat("PlayerX", player.position.x);
        PlayerPrefs.SetFloat("PlayerY", player.position.y);
        PlayerPrefs.SetInt("Health", playerScript.health);

        PlayerPrefs.Save();
    }

    public void LoadGame()
    {
        float x = PlayerPrefs.GetFloat("PlayerX", player.position.x);
        float y = PlayerPrefs.GetFloat("PlayerY", player.position.y);

        player.position = new Vector2(x, y);

        playerScript.health = PlayerPrefs.GetInt("Health", 3);
    }
}
