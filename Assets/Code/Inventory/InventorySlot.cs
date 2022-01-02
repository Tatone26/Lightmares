using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlot
{
    private string typeOfSlot;
    private Item[] item;
    private int size;

    public InventorySlot(string type, int si)
    {
        typeOfSlot = type;
        item = new Item[si];
        size = si;
    }

    public bool addItem(Item ite)
    {
        if (ite.type == typeOfSlot)
        {
            item[0] = ite;
            return true;
        }
        else
        {
            return false;
        }
    }

    Item getItem()
    {
        return item[0];
    }
}