using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject gunPrefab;
     private GameObject player;
    public bool isGetGun = false;
    private Vector3 gunVector;
    private Vector3 gunPrefabVector;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        //gunPrefabVector = new Vector3(-4.6f, gunPrefab.transform.position.y, gun.transform.position.z);

        if (gameObject == true)
        {
            isGetGun = true;
        }

        transform.position = new Vector3(player.transform.position.x + 0.5f, player.transform.position.y, player.transform.position.z);

        if (isGetGun && Input.GetKeyDown(KeyCode.F))
        {
            Instantiate(bulletPrefab, gameObject.transform.position, Quaternion.identity);
        }
    }   
}
