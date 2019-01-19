using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuUIController : MonoBehaviour
{
    public GameObject TitleScreen;
    public GameObject LevelScreen;

    public void Start()
    {
        TitleScreen.SetActive(true);
        LevelScreen.SetActive(false);
    }

    public void OnStartClicked()
    {
        TitleScreen.SetActive(false);
        LevelScreen.SetActive(true);
    }

    public void OnLoadLevelClicked(string _levelName)
    {
        SceneManager.LoadScene(_levelName);
    }

    public void OnExitClicked()
    {
        Application.Quit();
    }
}
