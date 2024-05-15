using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{ 
    Player player;
    BoxCollider2D box;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        box = GetComponent<BoxCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && player.isKey2)
        {
            Destroy(box);
        }
    } 
}
