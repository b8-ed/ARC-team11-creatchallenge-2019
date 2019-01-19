using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public bool isGameRunning;

    #region Singleton
    private static GameManager _golstatsManager;

    public static GameManager Instance
    {
        get { return _golstatsManager; }
        set { _golstatsManager = value; }
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion

    public void PlayerWins()
    {
        isGameRunning = false;
        Debug.Log("I WIN");
    }

    // Use this for initialization
    void Start ()
    {
        isGameRunning = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
