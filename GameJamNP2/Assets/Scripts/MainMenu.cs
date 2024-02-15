using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject levelMenu;
    
    public void PlayGame()
    {
        mainMenu.SetActive(false);
        levelMenu.SetActive(true);
    }
    public void BackToMain()
    {
        levelMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
    public void PlayLevelOne()
    {
        SceneManager.LoadScene("Level_1");
    }
    public void PlayLevelTwo()
    {
        SceneManager.LoadScene("Level_2");
    }
    public void PlayLevelThree()
    {
        SceneManager.LoadScene("Level_3");
    }
    public void PlayLevelFour()
    {
        SceneManager.LoadScene("Level_4");
    }
    public void QuitGame()
    {
        Environment.Exit(0);
    }
}
