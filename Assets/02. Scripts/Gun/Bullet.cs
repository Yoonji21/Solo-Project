using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Bullet : MonoBehaviour
{
    private float speed = 15;
    PlayerHP HP;
 
    private void Awake()
    {
        HP = GameObject.Find("Player").GetComponent<PlayerHP>();
    }

    void Update()
    {
        transform.position += transform.right * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            HP.playerHp -= 5;
            Destroy(gameObject);
        }
    }
}