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
    private Vector3 gunVet;
    private Vector3 gunPrefabVet;

    private void Awake()
    {
        bulletPrefab = GameObject.Find("Bullet");
        gun = GameObject.Find("Gun");
        gunPrefab = GameObject.Find("GunObject");
        player = GameObject.Find("Player");
    }

    private void Start()
    {
        gunVet = new Vector3(-4.6f, gun.transform.position.y, gun.transform.position.z);
        gunPrefabVet = new Vector3(-4.6f, gunPrefab.transform.position.y, gun.transform.position.z);
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
            Instantiate(bulletPrefab, gunVet , gun.transform.rotation);
        }

        else if (isTrue == false && Input.GetKeyDown(KeyCode.F))
        {
            Instantiate(bulletPrefab, gunPrefabVet , gunPrefab.transform.rotation);
        }
    }   
}
