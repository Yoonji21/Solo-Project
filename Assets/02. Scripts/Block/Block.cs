using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    Vector3 move;
    Rigidbody2D rigid;

    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
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
            transform.position = new Vector3(transform.position.x, -1.3f, 0);
            rigid.constraints = RigidbodyConstraints2D.FreezeAll;
            Destroy(gameObject.GetComponent<Block>());
            this.enabled = false;
        }
        
    }
}
