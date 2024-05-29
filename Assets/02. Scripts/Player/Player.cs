using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject Item;
    [SerializeField] private GameObject spawner;
    public bool isKey2 = false;

    private void Awake()
    {
        spawner.SetActive(false);
    }
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        {
            UIManager.instance.isGetKey = true;
            isKey2 = true;
        }

        if (collision.gameObject.CompareTag("Gun") && UIManager.instance.isTrigger2 == false)
        {
            UIManager.instance.gunPopup.SetActive(true);
            Time.timeScale = 0;
        }

        if (collision.gameObject.CompareTag("Button"))
        {
            spawner.SetActive(true);
        }
    }
}

    

