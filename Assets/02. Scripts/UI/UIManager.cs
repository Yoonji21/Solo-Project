using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance = null;
    [SerializeField] private GameObject baboo;
    [SerializeField] public GameObject gunPopup;
    [SerializeField] private GameObject walkingStick;
    [SerializeField] private GameObject basicsGun;
    public GameObject gunPrefab;
    public bool isGetKey = false;
    public bool isTrigger2 = false;
    public bool isActivation = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        baboo.SetActive(false);
        gunPopup.SetActive(false);
    }

    private void Update()
    {
        if (isGetKey == true)
        {
            baboo.SetActive(true);
            StartCoroutine(Cool());
            isGetKey = false;
        }
    }

    public void YesOnClick()
    {
        gunPopup.SetActive(false);
        Destroy(basicsGun);
        isTrigger2 = true;
        isActivation = true;
    }

    public void NoOnClick()
    {
        gunPopup.SetActive(false);
        isTrigger2 = false;
    }

    IEnumerator Cool()
    {
        yield return new WaitForSeconds(3f);
        baboo.SetActive(false);
    }
}