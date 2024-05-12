using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rigid;
    private float jumpForce = 5;
    private float speed = 5;
    private Vector3 moveDir;
    private bool isJump;
    [SerializeField] private GameObject Item;
    private bool getLay = false;
    private GameObject spawner;
    public bool isTrigger { get; set; } = false;
    public bool isTrigger2 { get; set; } = false;


    private void Awake()
    {
        spawner = GameObject.Find("Spawner");
        spawner.SetActive(false);
    }

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        isJump = false;
    }

    void Update()
    {
        
        Move();
        Slow();
        Jump();

    }

    private void Move()
    {
        moveDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0);
        transform.position += moveDir * speed * Time.deltaTime;
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isJump && getLay == false)
        {
            isJump = true;
            rigid.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJump = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Item"))
        isTrigger = true;
        if (collision.gameObject.CompareTag("Gun"))
            isTrigger2 = true;

        if (collision.gameObject.CompareTag("Button"))
        {
            spawner.SetActive(true);
        }
    }
}

    
