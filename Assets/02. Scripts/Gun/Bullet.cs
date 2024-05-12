using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed = 15;
    void Update()
    {
        transform.position += transform.right * speed * Time.deltaTime;
    }
}
