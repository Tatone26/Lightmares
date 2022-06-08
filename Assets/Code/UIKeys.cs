using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIKeys : MonoBehaviour
{
    public GameObject buttonE;
    public GameObject prefabLeukos;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            buttonE.SetActive(!buttonE.activeSelf);
        }

        if (Input.GetKeyDown("l"))
        {
            Instantiate(prefabLeukos, new Vector3(1, 0, 0), Quaternion.identity);
        }
    }
}