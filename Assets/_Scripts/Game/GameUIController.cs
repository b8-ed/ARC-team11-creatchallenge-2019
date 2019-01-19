using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIController : MonoBehaviour {

    public Image[] HP;

    public PlayerController Player; 

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
        RenderPlayerHP();
	}
	
	void Update ()
    {

        //TESTING DELETE WHEN DONE
		//if(Input.GetKeyDown(KeyCode.Space))
  //      {
  //          Player.DamagePlayer(1);
  //          RenderPlayerHP();
  //      }
	}
}
