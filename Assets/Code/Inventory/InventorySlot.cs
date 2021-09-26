using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlot
{
    private string typeOfSlot;
    private Item item;

    public InventorySlot(string type)
    {
        typeOfSlot = type;
    }

    public bool addItem(Item it)
    {
        if (it.type == typeOfSlot)
        {
            item = it;
            return true;
        }
        else
        {
            return false;
        }
    }

    Item getItem()
    {
        return item;
    }
}