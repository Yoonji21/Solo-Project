using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Slot : MonoBehaviour
{
    public bool isEmpty;
    public GameObject slotObj;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
