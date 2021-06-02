using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public GameObject player;
    public GameObject trig;
    public GameObject back;
    public GameObject destiny;
    bool unlock = false;
    float counter;
    Vector3 initPos;
    // Start is called before the first frame update
    void Start()
    {
        initPos = player.transform.position;
        counter = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        if (back.active)
        {
            unlock = true;
        }
        if (trig.active)
        {
            player.transform.position = destiny.transform.position;
        }
        else if (!back.active && unlock)
        {
            counter -= Time.deltaTime;
            if (counter < 0)
            {
                player.transform.position = initPos;
                unlock = false;
            }
        }
    }
}
