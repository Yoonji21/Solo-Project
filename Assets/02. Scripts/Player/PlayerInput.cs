using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerInput : MonoBehaviour
{
    public Action JumpPress;
    public Action SlowPress;
    public Action MovePress;
    private bool isGround = false;
    private Vector3 moveDir;
    [SerializeField] private float speed = 4f;
    [SerializeField] private LayerMask whatIsGround;
    private Rigidbody2D rigid;
    private bool getLay = false;
    private bool isJump;
    private float jumpForce = 5f;
    private float Ray = 1.5f;

    private void OnDrawGizmos()
    {
        gizmos();
    }

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        CheackGround();
        MovePress?.Invoke();
        JumpPress?.Invoke();
        SlowPress?.Invoke();

    }

    private void OnEnable()
    {
        MovePress += Move;
        JumpPress += Jump;
        SlowPress += Slow;
    }

    private void OnDisable()
    {
        MovePress -= Move;
        JumpPress -= Jump;
        SlowPress -= Slow;
    }

    private void Move()
    {
        moveDir = new Vector2(Input.GetAxisRaw("Horizontal") * speed, rigid.velocity.y);
        rigid.velocity = moveDir;
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround && getLay == false)
        {
            rigid.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
            isGround = false;
        }
    }

    private void Slow()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            getLay = true;
            speed = 2;
            transform.rotation = Quaternion.Euler(0, 0, 90);
            Move();
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            getLay = false;
            speed = 5;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    private void CheackGround()
    {
        isGround = Physics2D.Raycast(transform.position, Vector3.down, Ray, whatIsGround);
    }

     void gizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * Ray);
    }

}
