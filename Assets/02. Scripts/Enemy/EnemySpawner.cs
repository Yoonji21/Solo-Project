using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner instance = null;
    public Stack<GameObject> EnemyPool = new Stack<GameObject>();
    [SerializeField] private GameObject enemyPrefab;
    public GameObject enemyObj;
    private Vector3 moveDir;
    private Transform player;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;

        CreatEnemy();
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Update()
    {
        moveDir = new Vector3(player.position.x, transform.position.y, transform.position.z);
    }

    public void SpawnEnemy()
    {
        if (EnemyPool.Count > 0)
        {
            for (int i = 0; i < 5; i++)
            {
                enemyObj = EnemyPool.Pop();
                enemyObj.transform.position = new Vector3(player.position.x - 4, player.position.y, 0);
                enemyObj.SetActive(true);
            }
        }
        else
        {
            enemyObj = Instantiate(enemyPrefab);
        }
    }

    private void CreatEnemy()
    {
        for (int i = 0; i < 5; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab);
            EnemyPool.Push(enemy);
            enemy.SetActive(false);
        }
    }

    IEnumerator DeleteCool()
    {
        yield return new WaitForSeconds(3f);
        for (int i = 0; i < 5; i++)
        {
            EnemySpawner.instance.enemyObj.SetActive(false);

        }
        //isCoolTime = false;
    }
}
