using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private Vector3 move;
    private Transform player;
    public GameObject enemyPrefab;
    public bool isEnemy = false;
    private bool isCooltime;
    private GameObject emergency;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        emergency = GameObject.Find("Emergency");
        emergency.SetActive(false);
    }

    private void Start()
    {
        move = new Vector3(player.position.x - 4, player.position.y, player.position.z);       
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && isEnemy != true && !isCooltime)
        {
            isEnemy = true;
            for (int i = 0; i < 5; i++)
            {
                emergency.SetActive(true);
                StartCoroutine(Cool());
            }
        }
    }

    //IEnumerator enemyCool(GameObject gameObject)
    //{
    //    isCooltime = true;
    //    yield return new WaitForSeconds(3f);
    //    //gameObject.SetActive(false);
    //    isCooltime = false;
    //}

    IEnumerator Cool()
    {
        isCooltime = true;
        yield return new WaitForSeconds(3f);
        Instantiate(enemyPrefab, move, player.rotation);
        isCooltime = false;
    }

}
