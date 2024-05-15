using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private Vector3 move;
    private Vector3 moveDir;
    private Transform player;
    public GameObject enemyPrefab;
    public bool isEnemy = false;
    public float speed = 5;
    Enemy enemy;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        enemy = GetComponent<Enemy>();
    }

    private void Start()
    {
        move = new Vector3(player.position.x - 4, player.position.y, player.position.z);
       
    }

    private void Update()
    {
        Debug.Log("√‚µø !");
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && isEnemy == false)
        {
            isEnemy = true;
            for (int i = 0; i < 5; i++)
            {
                Instantiate(enemyPrefab, move, player.rotation);
            }
        }

        
    }
}
