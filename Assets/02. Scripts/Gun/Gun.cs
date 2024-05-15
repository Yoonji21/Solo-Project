using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
     private GameObject bulletPrefab;
     private GameObject gun;
     private GameObject gunPrefab;
    private GameObject player;
    public bool isTrue = false;

    private void Awake()
    {
        bulletPrefab = GameObject.Find("Bullet");
        gun = GameObject.Find("Gun");
        gunPrefab = GameObject.Find("GunObject");
        player = GameObject.Find("Player");
    }

    void Update()
    {
        if(gun == true)
        {
            isTrue = true;
        }

        transform.position = new Vector3(player.transform.position.x + 0.5f, player.transform.position.y, player.transform.position.z);

        if (isTrue == true && Input.GetKeyDown(KeyCode.F))
        {
            Instantiate(bulletPrefab, gun.transform.position , gun.transform.rotation);
        }

        else if (isTrue == false && Input.GetKeyDown(KeyCode.F))
        {
            Instantiate(bulletPrefab, gunPrefab.transform.position , gunPrefab.transform.rotation);
        }
    }   
}
