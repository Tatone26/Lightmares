using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryApparition : MonoBehaviour
{
    private Image inventoryImage;

    // Start is called before the first frame update
    void Start()
    {
        inventoryImage = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            inventoryImage.enabled = !inventoryImage.enabled;
        }
    }
}