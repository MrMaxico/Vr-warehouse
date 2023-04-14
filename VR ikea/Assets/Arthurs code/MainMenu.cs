using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject levelMenu;
    public GameObject settingsMenu;
    public GameObject mainMenu;
    int levelCounter;
    public void Play() {
        mainMenu.SetActive(false);
        levelMenu.SetActive(true);
    }
    public void Settings() {
        mainMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }
    public void GoBack() {
        settingsMenu.SetActive(false);
        levelMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
    public void LoadLevel(int num) {
            SceneManager.LoadScene("Game" + num);
    }
    public void Quit() {
        Application.Quit();
    }
}
