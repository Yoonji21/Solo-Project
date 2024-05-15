using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    public float playerHp = 100f;
    public Text playerHpUI;
    private GameObject deathUI;
    private GameObject restart;

    private static PlayerHP Instance = null;

    private void Awake()
    {
        deathUI = GameObject.Find("Death");
        restart = GameObject.Find("Restart");
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        SetHp(100);
    }

    private void Update()
    {
        SetHp(playerHp);

        if (playerHp == 0)
        {
            Time.timeScale = 0;
            deathUI.SetActive(true);
            restart.SetActive(true);
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
