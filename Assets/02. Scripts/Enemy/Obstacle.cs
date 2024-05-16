using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private Vector3 move;
    private Transform player;
    public GameObject enemyPrefab;
    public bool isEnemy = false;
    public bool isCooltime;
    public float speed = 5;
    private GameObject emergency;
    GameObject gameObject2;

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
        if (collision.gameObject.CompareTag("Player") && isEnemy != true && !isCooltime)
        {
            isEnemy = true;
            for (int i = 0; i < 5; i++)
            {
                emergency.SetActive(true);
                StartCoroutine(emergencyCool());
                StartCoroutine(enemyCool(gameObject2));
            }
        }                
    }

    IEnumerator enemyCool(GameObject gameObject)
    {
        isCooltime = true;
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);
        isCooltime = false;
    }
    IEnumerator emergencyCool()
    {
        isCooltime = true;
        yield return new WaitForSeconds(3f);
        GameObject gameObject2 = Instantiate(enemyPrefab, move, player.rotation);
        isCooltime = false;
    }

}
