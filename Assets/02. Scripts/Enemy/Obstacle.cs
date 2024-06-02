using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private Vector3 move;
    private Transform player;
    [SerializeField] private GameObject enemyPrefab;
    private GameObject enemyObj;
    public bool isEnemy = false;
    private bool isCooltime;
    [SerializeField] private GameObject emergency;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        emergency.SetActive(false);
    }

    private void Update()
    {
        move = new Vector3(player.position.x - 4, player.position.y, player.position.z);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && isEnemy != true && !isCooltime)
        {
            isEnemy = true;
            
            emergency.SetActive(true); 
            StartCoroutine(Cool());
        }
    }

    
    IEnumerator Cool()
    {
        isCooltime = true;
        yield return new WaitForSeconds(3f);
        //Instantiate(enemyPrefab, move, player.rotation);
        EnemySpawner.instance.SpawnEnemy();
    }
}
