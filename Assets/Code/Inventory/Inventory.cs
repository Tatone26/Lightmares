using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<InventorySlot> listSlots = new List<InventorySlot>(18);
    public Sprite sprite;

    void addItem(Item item, InventorySlot slot)
    {
        slot.addItem(item);
    }

    void removeItem(Item item)
    {
    }
    // Start is called before the first frame update
    // Setup all inventory slots.
    void Start()
    {
        listSlots.Add(new InventorySlot("sword"));
        listSlots.Add(new InventorySlot("armor"));
        listSlots.Add(new InventorySlot("bow"));
        listSlots.Add(new InventorySlot("wand"));
        for (int i = 0; i < 3; i++)
        {
            listSlots.Add(new InventorySlot("arrow"));
        }
        for (int i = 0; i < 3; i++)
        {
            listSlots.Add(new InventorySlot("scroll"));
        }
        for (int i = 0; i < 4; i++)
        {
            listSlots.Add(new InventorySlot("potion"));
        }
        for (int i = 0; i < 4; i++)
        {
            listSlots.Add(new InventorySlot("food"));
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}