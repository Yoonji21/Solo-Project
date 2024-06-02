using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    private float BSpeed = 3f;
    private float scrollRange = 9.9f;

    public Transform target;


    private void Update()
    {
        transform.position = new Vector3(target.position.x, target.position.y + 3,target.position.z);
    }
}
