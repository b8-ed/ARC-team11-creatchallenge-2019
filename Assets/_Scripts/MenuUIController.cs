using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuUIController : MonoBehaviour
{
    public void OnStartClicked()
    {
        SceneManager.LoadScene("Game");
    }
}
