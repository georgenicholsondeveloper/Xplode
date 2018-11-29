using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour {
    private GameObject menu;
    private GameObject levelSelect;

    void Start()
    {
        menu = GameObject.Find("Menu");
        levelSelect = GameObject.Find("LevelSelector");
        levelSelect.SetActive(false);
                
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LevelSelect()
    {
        menu.SetActive(false);
        levelSelect.SetActive(true);
    }

    public void Return()
    {
        menu.SetActive(true);
        levelSelect.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void Level1()
    {
        SceneManager.LoadScene(1);
    }

    public void Level2()
    {
        SceneManager.LoadScene(2);
    }

    public void Level3()
    {
        SceneManager.LoadScene(3);
    }

  
}
