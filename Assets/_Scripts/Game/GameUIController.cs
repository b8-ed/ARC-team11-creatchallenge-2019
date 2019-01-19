using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIController : MonoBehaviour {

    public Image[] HP;

    public PlayerController Player;

    public GameObject GameOverPanel;
    public GameObject GameWinPanel;

    public void OnRetryClicked()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    public void OnBackClicked()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }

    //RENDERS THE HP SPRITES ACCORDING TO THE PLAYERS HEALTH
    public void RenderPlayerHP()
    {
        for (int i = 0; i < HP.Length; i++)
        {
            HP[i].enabled = false;
        }

        for (int i = 0; i < Player.GetHP(); i++)
        {
            HP[i].enabled = true;
        }
    }
	void Start ()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        GameOverPanel.SetActive(false);
        GameWinPanel.SetActive(false);
        RenderPlayerHP();
	}
}
