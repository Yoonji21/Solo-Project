using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    GameObject restartButton;
    Transform player;
    private Vector3 moveDir;
    private bool isPause = false;
    private bool isEnemy;
   

    private void Awake()
    {
        restartButton = GameObject.Find("Restart");
        player = GameObject.Find("Player").transform;
        //isEnemy = GameObject.Find("Obstacle").GetComponent<Obstacle>().isEnemy;
        gameObject.SetActive(false);
        restartButton.SetActive(false);
    }

    private void Start()
    {
        moveDir = player.position - transform.position;
        moveDir.Normalize();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") /*&& isEnemy == true*/)
        {
            gameObject.SetActive(true);
            restartButton.SetActive(true);
        }
    }

    public void RestartOnClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        if (isPause == false)
        {
            Time.timeScale = 1;
            isPause = true;
        }
    }
}
