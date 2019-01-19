using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField]
    private int HP;
    [SerializeField]
    private int MaxHP;

    private Animator playerAnim;

    public void SetHP(int _hp)
    {
        HP = _hp;
    }

    public int GetHP()
    {
        return HP;
    }

    //FUNCTION THAT SUBSTRACT THE PLAYERS HEALTH
    public void DamagePlayer(int _damage)
    {
        HP -= _damage;

        if (HP <= 0)
            Dead();
    }

    //INSTADEAD WHENEVER THE WATER TOUCHES THE PLAYER
    public void InstaDead()
    {
        HP -= MaxHP;
        Dead();
    }

    //STOPS GAME LOOP AND RENDERS GAME OVER SCREEN
    public void Dead()
    {
        playerAnim.SetTrigger("Dead");
        GameManager.Instance.isGameRunning = false;
    }

    #region UNITY FUNCTIONS
    void Start ()
    {
        playerAnim = GetComponent<Animator>();
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Water"))
        {
            print("I AM DEAD");
            InstaDead();

        }

        if(other.CompareTag("Goal"))
        {

        }
    }
    #endregion
}
