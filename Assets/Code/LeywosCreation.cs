using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leywoscreation : MonoBehaviour
{
    public GameObject PrefabLeukos;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("l"))
        {
            Instantiate(PrefabLeukos, new Vector3(1, 0, 0), Quaternion.identity);
        }
    }
}
