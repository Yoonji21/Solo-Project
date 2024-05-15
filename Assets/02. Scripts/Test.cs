using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{

    private void FixedUpdate()
    {
        Debug.DrawRay(transform.position, new Vector3(10, 0 ,0 ), new Color(0, 1, 0), LayerMask.GetMask("Ray"));

        RaycastHit2D ray = Physics2D.Raycast(transform.position, new Vector3(10, 0, 0), LayerMask.NameToLayer("Ray"));

        if (ray.collider != null)
        {    
            Debug.Log(ray.collider.name);
        }
    }
}
