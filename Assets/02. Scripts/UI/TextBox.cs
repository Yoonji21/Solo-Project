using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextBox : MonoBehaviour
{
    private GameObject item;
    private GameObject baboo;
    private GameObject gunPopup;
    private GameObject gun;
    public GameObject gunPrefab;
    private Transform player;

    private void Awake()
    {
        item = GameObject.Find("Item");
        baboo = GameObject.Find("baboo");
        gunPopup = GameObject.Find("gunPopup");
        gun = GameObject.Find("GunObject");
        player = GameObject.Find("Player").GetComponent<Transform>();

    }

    private void Start()
    {
        baboo.SetActive(false);
        gunPopup.SetActive(false);
    }

    private void Update()
    {
        if (GameObject.Find("Player").GetComponent<Player>().isTrigger == true)
        {
            baboo.SetActive(true);
            StartCoroutine(Cool());
            GameObject.Find("Player").GetComponent<Player>().isTrigger = false;
        }

        if (GameObject.Find("Player").GetComponent<Player>().isTrigger2 == true)
        {
            Debug.Log("됐당");
            gunPopup.SetActive(true);
            GameObject.Find("Player").GetComponent<Player>().isTrigger2 = false;
        }
    }

    public void YesOnClick()
    {
        Debug.Log("예스");
        gunPopup.SetActive(false);
        Destroy(GameObject.Find("Gun"));
        Gun gun1 = gun.AddComponent<Gun>();
    }

    public void NoOnClick()
    {
        Debug.Log("노");
        gunPopup.SetActive(false);
    }

    IEnumerator Cool()
    {
        yield return new WaitForSeconds(3f);
        Debug.Log("비활성화");
        baboo.SetActive(false);
    }
}
