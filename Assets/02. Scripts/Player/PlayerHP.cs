using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class PlayerHP : MonoBehaviour
{
    public float playerHp = 100f;
    public Text playerHpUI;
    [SerializeField] private GameObject deathUI;
    [SerializeField] private GameObject restart;

    public static PlayerHP instance = null;

    public UnityEvent onPlayerDead;

    private void Dead()
    {
        onPlayerDead.Invoke();
    }


    private void Awake()
    {
        
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        SetHp(100);
    }

    private void Update()
    {
        SetHp(playerHp);

        if (playerHp < 1)
        {
            Time.timeScale = 0;
            Dead();
            //deathUI.SetActive(true);
            //restart.SetActive(true);
        }

        else
        {
            Time.timeScale = 1;
        }
    }

    public void SetHp(float value)
    {
        playerHpUI.text = "HP : " + playerHp;
    }
}
