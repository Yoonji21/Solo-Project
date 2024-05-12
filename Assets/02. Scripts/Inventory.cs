using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Slot> slots = new List<Slot>();
    private int slotMax = 1;
    [SerializeField] private GameObject slotPrefab;
    public Sprite ItemImage;

    private void Start()
    {
        GameObject slotPanel = GameObject.Find("InventoryUI");

        for (int i = 0; i < slotMax; i++)
        {
            GameObject go = Instantiate(slotPrefab, slotPanel.transform, false); ;
            go.name = "Slot" + i;
            Slot slot = new Slot();
            slot.isEmpty = true;
            slot.slotObj = go;
            slots.Add(slot);
        }
    }
}
