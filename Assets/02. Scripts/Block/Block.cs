using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    Vector3 move;
    Rigidbody2D rigid;
    bool isGround;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        move = Vector3.down;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += new Vector3(0.5f, 0, 0);
        }

        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-0.5f, 0, 0);
        }

        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Down();
            //Down();
            //transform.position = new Vector3(transform.position.x, -1.3f, 0);
            //rigid.constraints = RigidbodyConstraints2D.FreezeAll;
            //Destroy(gameObject.GetComponent<Block>());
            //this.enabled = false;
        }
    }

    private void Down()
    {
        if(!isGround)
            transform.position += move * 10 * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Block"))
        {
            isGround = true;
            rigid.constraints = RigidbodyConstraints2D.FreezeAll;
            Destroy(gameObject.GetComponent<Block>());
        }
    }
}
