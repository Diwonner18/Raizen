using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowAndSpawn : MonoBehaviour
{
    public GameObject show;
    public GameObject toEnable;
    float counter;
    // Start is called before the first frame update
    void Start()
    {
        counter = 2.5f;
        show.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        counter -= Time.deltaTime;
        if (counter <= 0)
        {
            show.SetActive(false);
            if (toEnable)
            {
                toEnable.SetActive(true);
            }
        }
    }
}
