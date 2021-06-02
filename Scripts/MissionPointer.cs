using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionPointer : MonoBehaviour
{
    public SpriteRenderer larrow,rarrow;
    public static Transform actualmission;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (actualmission && actualmission.gameObject.activeInHierarchy)
        {
            Vector3 dirtomission = actualmission.position - transform.position;
            float angletomission = Vector3.SignedAngle(transform.forward, dirtomission, Vector3.up);
            rarrow.enabled = false;
            larrow.enabled = false;
            if (angletomission > 40)
            {
                rarrow.enabled = true;
                larrow.enabled = false;
            }
            if (angletomission < -40)
            {
                larrow.enabled = true;
                rarrow.enabled = false;
            }
        }
        else
        {
            rarrow.enabled = false;
            larrow.enabled = false;
        }
    }
}
