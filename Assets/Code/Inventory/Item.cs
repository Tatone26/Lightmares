using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Item", order = 1)]
public class Item : ScriptableObject
{
    public int id;
    public string title;
    public string description;
    public Sprite icon;
    public string type;

    public Item(int nid, string ntitle, string ndescription, Sprite nicon, string ntype)
    {
        id = nid;
        title = ntitle;
        description = ndescription;
        icon = nicon;
        type = ntype;
    }
}