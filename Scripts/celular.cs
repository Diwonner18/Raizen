using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class celular : MonoBehaviour
{
    public GameObject texto;
    public GameObject cel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (texto.active)
        {
            cel.SetActive(true);
           
        }
        else
        {
            cel.SetActive(false);
        }
    }
}
