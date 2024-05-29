using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private float speed = 15;

    void Update()
    {
        transform.position += transform.right * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHP.instance.playerHp -= 5;
            Destroy(gameObject);
        }
    }
}
