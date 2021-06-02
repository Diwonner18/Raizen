using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableObject : MonoBehaviour
{
    public GameObject trig;
    public GameObject toDisable;
    bool locked = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (trig.active)
        {
            locked = true;
        }
        else if (!trig.active && locked)
        {
            toDisable.SetActive(false);
        }
    }
}
