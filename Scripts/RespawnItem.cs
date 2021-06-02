using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnItem : MonoBehaviour
{
    public GameObject item;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(item, transform.position, transform.rotation);
    }

}
