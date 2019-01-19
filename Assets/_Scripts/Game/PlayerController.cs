using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public bool GodMode = false;
    public bool CanWin = false;
    public bool IsDead = false;

    public GameObject MainCamera;
    public GameUIController GameUI;

    //0 win, 1, 2 hurt, 3 jump
    public AudioClip[] SfxClips;

    [SerializeField]
    private int HP;
    [SerializeField]
    private int MaxHP;
    [SerializeField]
    private SpriteRenderer playerSprite;

    private bool canRecieveDamage = true;

    private Animator playerAnim;
    private AudioSource playerAudio;

    public void PlaySound(AudioClip _sfx)
    {
        playerAudio.clip = _sfx;
        playerAudio.Play();
    }

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
        if (!canRecieveDamage || GodMode)
            return;

        PlaySound(SfxClips[Random.Range(1, 2)]);

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
        if (IsDead)
            return;
        PlaySound(SfxClips[Random.Range(1, 2)]);
        GameUI.GameOverPanel.SetActive(true);
        playerAnim.SetTrigger("Dead");
        IsDead = true;
        GameManager.Instance.isGameRunning = false;
    }

    IEnumerator WaitForDamage()
    {
        playerSprite.material.color = Color.red;
        yield return new WaitForSeconds(0.6f);
        playerSprite.material.color = Color.white;

        canRecieveDamage = true;
    }

    public void MakePlayerInvincible()
    {
        playerSprite.material.color = Color.yellow;
        GodMode = true;
    }

    #region UNITY FUNCTIONS
    void Start ()
    {
        GameUI = FindObjectOfType<GameUIController>();
        MainCamera = Camera.main.gameObject;
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
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
            GameManager.Instance.PlayerWins();
            PlaySound(SfxClips[0]);
        }

        if (other.CompareTag("Hazard"))
            DamagePlayer(1);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Goal"))
        {
            print("PLEASE GET BACK");
            CanWin = false;
            other.GetComponent<GoalBehaviour>().canWin = false;
        }
    }
    #endregion
}
