using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] blockPrefab;
    private Transform spawner;
    public int count = 0;
    private Transform player;
    private int countBlock = 10;

    private void NewBlock()
    {
        if (Input.GetKeyDown(KeyCode.R) )//&& blockPrefab[Random.Range(0, blockPrefab.Length)].transform.position.y == -1.3f*/)
        {
            Instantiate(blockPrefab[Random.Range(0, blockPrefab.Length)], spawner.position, spawner.rotation);
        }
    }
    private void StartNewBlock()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Instantiate(blockPrefab[Random.Range(0, blockPrefab.Length)], spawner.position, spawner.rotation);
            count++;
        }
    }
    

    void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
        spawner = GameObject.Find("Spawner").GetComponent<Transform>();
    }

    private void Start()
    {
        
    }

    void Update()
    {
        transform.position = new Vector3(player.position.x, 4.5f, 0);

        if (count == 0)
        {
            StartNewBlock();
        }
        else
        {
            NewBlock();

        }
        //for (int i = 10; i < countBlock; i--)
        //{
        //    if (count > 0)
        //    {
        //        NewBlock();
        //        count++;
        //    }
        //}

    }
}
