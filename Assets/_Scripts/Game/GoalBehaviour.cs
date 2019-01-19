using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalBehaviour : MonoBehaviour {

    public bool canWin = false;
    public float speed = 0.50f;
    private SpriteRenderer goalRenderer;

    private void Start()
    {
        goalRenderer = GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void Update ()
    {
        if (canWin)
        {
            goalRenderer.material.color = Color.Lerp(Color.white, Color.yellow, Mathf.PingPong(Time.deltaTime * speed, 1.0f));
            Debug.Log("I am here");
            Debug.Log(goalRenderer.material.color);
        }
        else
            goalRenderer.material.color = Color.white;

    }
}
