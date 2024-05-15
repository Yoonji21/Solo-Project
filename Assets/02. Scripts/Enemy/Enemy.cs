using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using System;

public class Enemy : MonoBehaviour
{
    private Transform target;
    private float speed = 0;
    private Vector3 moveDir;
    private GameObject bulletPrefab;
    private bool isCoolTime;
    private bool isEnemy;
    GameObject player;

    private void Awake()
    {
        bulletPrefab = GameObject.Find("Bullet");
        player = GameObject.Find("Player");
        isEnemy = GameObject.Find("Obstacle").GetComponent<Obstacle>().isEnemy ;
        target = player.transform;
    }

    private void Update()
    {
        transform.position += moveDir * speed * Time.deltaTime;
        Idle();
        Attack();
        Run();
        
        if (isEnemy == true)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;

        }
    }

    private void Attack()
    {
        speed = 0;
        if (Vector3.Distance(target.transform.position, transform.position) > 2 && Vector3.Distance(target.transform.position, transform.position) < 7)
        {
            speed = 4;
            moveDir = player.transform.position - transform.position;
            moveDir.Normalize();
        }
    }

    public void Run()
    {
        
        speed = 4;
        if (Vector3.Distance(target.position, transform.position) <= 6 && !isCoolTime)
        {
                Instantiate(bulletPrefab, transform.position, transform.rotation);
                StartCoroutine(FireCoroutine(0.3f));
        }  
    }

    private void Idle()
    {
        if (Vector3.Distance(target.transform.position, transform.position) < 6)
        {
            speed = 0;
        }

        if (target != null)
        {
            Run();
        }
    }

    IEnumerator FireCoroutine(float cooltime)
    {
        isCoolTime = true;
        yield return new WaitForSeconds(cooltime);
        isCoolTime = false;
    }
}
