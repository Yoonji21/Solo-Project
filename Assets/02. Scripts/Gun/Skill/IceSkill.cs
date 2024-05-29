using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceSkill : MonoBehaviour
{
    [SerializeField] private float speed = 25;
    private HPManager hpManager;

    void Update()
    {
        transform.position += transform.right * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            hpManager.EnemyHp -= 11;
            Destroy(gameObject);
            print($"얼음공격 {hpManager.EnemyHp}");
        }
    }
}
