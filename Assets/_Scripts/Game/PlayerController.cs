using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public bool canWin = false;
    public GameObject MainCamera;
    public GameUIController GameUI;

    [SerializeField]
    private int HP;
    [SerializeField]
    private int MaxHP;

    private bool canRecieveDamage = true;

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
        if (!canRecieveDamage)
            return;

        HP -= _damage;

        canRecieveDamage = false;
        StartCoroutine(WaitForDamage());

        MainCamera.GetComponent<CameraShake>().TriggerShake();
        GameUI.RenderPlayerHP();

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
        //GetComponent<UnityStandardAssets._2D.Platformer2DUserControl>().enabled = false;
        //GetComponent<UnityStandardAssets._2D.PlatformerCharacter2D>().enabled = false;
        GameManager.Instance.isGameRunning = false;
    }

    IEnumerator WaitForDamage()
    {
        yield return new WaitForSeconds(0.4f);
        canRecieveDamage = true;
    }
    #region UNITY FUNCTIONS
    void Start ()
    {
        playerAnim = GetComponent<Animator>();
	}

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && canWin)
        {
            GameManager.Instance.PlayerWins();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Water"))
        {
            print("I AM DEAD");
            InstaDead();

        }

        if (other.CompareTag("Goal"))
        {
            print("PLEASE PRESS E");
            canWin = true;
        }

        if (other.CompareTag("Hazard"))
            DamagePlayer(1);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Goal"))
        {
            print("PLEASE GET BACK");
            canWin = false;
        }
    }
    #endregion
}
