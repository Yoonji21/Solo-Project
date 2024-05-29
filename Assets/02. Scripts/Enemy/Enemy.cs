using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using System;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rigid;
    private Vector3 moveDir;
    private Transform target;
    [SerializeField] private GameObject bulletPrefab;
    private GameObject player;
    private bool isCoolTime;
    private bool isEnemy;
    private bool isGround;
    private bool isObstacle;
    [SerializeField] private float Ray = 1;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private LayerMask whatIsObstacle;
    [SerializeField]
    [Range(0, 20)]
    private float jumpPower;
    public float enemyHp = 100;
    [SerializeField] private float speed = 3;
    

    private void Awake()
    {
        player = GameObject.Find("Player");
        isEnemy = GameObject.Find("Obstacle").GetComponent<Obstacle>().isEnemy ;
        target = player.transform;
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        CheackGround();
        moveDir = player.transform.position - transform.position;
        rigid.velocity = new Vector2( moveDir.x , rigid.velocity.y);

        if (enemyHp < 1)
        {
            gameObject.SetActive(false);
        }

        Idle();
        Attack();
        Run();
    }

    private void Attack()
    {
        speed = 0;
        if (Vector3.Distance(target.transform.position, transform.position) > 2 && Vector3.Distance(target.transform.position, transform.position) < 7)
        {
            speed = 3;
            moveDir = player.transform.position - transform.position;

        }
    }

    public void Run()
    {
        if (Vector3.Distance(target.position, transform.position) <= 6 && !isCoolTime)
        {
            Instantiate(bulletPrefab, transform.position, transform.rotation);
            StartCoroutine(FireCoroutine(2f));
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

    public void EnemyDamage()
    {
        enemyHp -= 30;
        print("½ÇÇà");
    }

    private void CheackGround()
    {
        isObstacle = Physics2D.Raycast(transform.position + Vector3.down, Vector3.right, Ray, whatIsObstacle);
        isGround = Physics2D.Raycast(transform.position, Vector3.down, Ray, whatIsGround);
        if (isObstacle && isGround)
        {
            rigid.velocity = new Vector2(rigid.velocity.x, jumpPower);
        }
    }

    IEnumerator FireCoroutine(float cooltime)
    {
        isCoolTime = true;
        yield return new WaitForSeconds(cooltime);
        isCoolTime = false;
    }
}
