using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCam : MonoBehaviour
{
    private float speed = 6f;
    [SerializeField] private Transform player;

    void FixedUpdate()
    {
        Vector3 move = new Vector3(player.position.x, player.position.y, this.transform.position.z) ;
        transform.position = Vector3.Lerp(transform.position, move, Time.deltaTime* speed);
    }
}
