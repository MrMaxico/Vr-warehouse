using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject levelMenu;
    public GameObject settingsMenu;
    public GameObject mainMenu;
    public void Play() {
        mainMenu.SetActive(false);
        levelMenu.SetActive(true);
    }
    public void Settings() {
        mainMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }
    public void Quit() {
        Application.Quit();
    }
}
