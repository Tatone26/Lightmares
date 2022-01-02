using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<InventorySlot> listSlots = new List<InventorySlot>(18);
    public Sprite sprite;

    void addItem(Item item, InventorySlot slot)
    {
        if (slot.addItem(item))
        {
            Debug.Log("Item rajouté à l'inventaire");
        }
        else
        {
            Debug.Log("Item n'a pas réussi à être rajouté. T nul.");
        }
    }

    void removeItem(Item item)
    {
    }
    // Start is called before the first frame update
    // Setup all inventory slots.
    void Start()
    {
        listSlots.Add(new InventorySlot("sword", 1));
        listSlots.Add(new InventorySlot("armor", 1));
        listSlots.Add(new InventorySlot("bow", 1));
        listSlots.Add(new InventorySlot("wand", 1));
        for (int i = 0; i < 3; i++)
        {
            listSlots.Add(new InventorySlot("arrow", 1));
        }
        for (int i = 0; i < 3; i++)
        {
            listSlots.Add(new InventorySlot("scroll", 1));
        }
        for (int i = 0; i < 4; i++)
        {
            listSlots.Add(new InventorySlot("potion", 1));
        }
        for (int i = 0; i < 4; i++)
        {
            listSlots.Add(new InventorySlot("food", 1));
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}