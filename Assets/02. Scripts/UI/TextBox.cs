using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextBox : MonoBehaviour
{
    private GameObject baboo;
    private GameObject gunPopup;
    private GameObject gun;
    private GameObject basicsGun;
    public GameObject gunPrefab;
    private bool isKey;
    private bool isTrigger2 = false;

    private void Awake()
    {
        baboo = GameObject.Find("baboo");
        gunPopup = GameObject.Find("gunPopup");
        gun = GameObject.Find("GunObject");
        isKey = GameObject.Find("Player").GetComponent<Player>().isKey;
        isTrigger2 = GameObject.Find("Player").GetComponent<Player>().isTrigger2;
        basicsGun = GameObject.Find("Gun");
    }

    private void Start()
    {
        baboo.SetActive(false);
        gunPopup.SetActive(false);
    }

    private void Update()
    {
        if (GameObject.Find("Player").GetComponent<Player>().isKey == true)
        {
            baboo.SetActive(true);
            StartCoroutine(Cool());
            GameObject.Find("Player").GetComponent<Player>().isKey = false;
        }

        if (GameObject.Find("Player").GetComponent<Player>().isTrigger2 == true)
        {
            Debug.Log("È°¼ºÈ­");
            gunPopup.SetActive(true);
            GameObject.Find("Player").GetComponent<Player>().isTrigger2 = false;
        }
    }

    public void YesOnClick()
    {
        gunPopup.SetActive(false);
        Destroy(basicsGun);
        Gun gun1 = gun.AddComponent<Gun>();
    }

    public void NoOnClick()
    {
        gunPopup.SetActive(false);
    }

    IEnumerator Cool()
    {
        yield return new WaitForSeconds(3f);
        baboo.SetActive(false);
    }
}
