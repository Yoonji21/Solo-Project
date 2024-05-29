using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSkill : MonoBehaviour
{
    [SerializeField] private float speed = 20;
    private Enemy enemy;

    void Update()
    {
        transform.position += transform.right * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            enemy = collision.GetComponent<Enemy>();
            enemy.EnemyDamage(13);
            gameObject.SetActive(gameObject);
        }
    }
}
