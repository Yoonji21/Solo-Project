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
    private GameObject emergency;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        emergency = GameObject.Find("Emergency");
    }

    private void Start()
    {
        move = new Vector3(player.position.x - 4, player.position.y, player.position.z);
        emergency.SetActive(false);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && isEnemy != true)
        {
            isEnemy = true;
            StartCoroutine(emergencyCool());

            for (int i = 0; i < 5; i++)
            {
                Instantiate(enemyPrefab, move, player.rotation);
            }
        }
    }

    IEnumerator emergencyCool()
    {            
        emergency.SetActive(true);
        yield return new WaitForSeconds(3); 
    }

}
