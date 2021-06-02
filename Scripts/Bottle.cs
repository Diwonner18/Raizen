using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottle : MonoBehaviour
{
    public GameObject texto;
    public GameObject bottle;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (texto.active)
        {
            bottle.SetActive(true);

        }
        else
        {
            bottle.SetActive(false);
        }
    }
}
