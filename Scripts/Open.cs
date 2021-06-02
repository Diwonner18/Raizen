using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open : MonoBehaviour
{
    public GameObject tampaF;
    public GameObject trava;
    public GameObject trig;
    public float log = 2;
    bool locked = false;
    public float rotTrv;
    public float rotTmp;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (trig.active)
        {
            if (trava.transform.rotation.eulerAngles.z < rotTrv && !locked)
            {
                trava.transform.Rotate(0, 0, (trava.transform.rotation.z + 1f));

            }
            else
            {
                locked = true;
            }
                
            if (tampaF.transform.rotation.eulerAngles.z <= rotTmp && locked)
            {
                tampaF.transform.Rotate(tampaF.transform.rotation.x, tampaF.transform.rotation.y, (tampaF.transform.rotation.z + 0.1f));

            }
        }
    }
}
