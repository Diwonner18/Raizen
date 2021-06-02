using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaynaAnimacao : MonoBehaviour
{
    public Animator anim;
    public float frame = 0.0f;
    public GameObject trig;
    public GameObject ccds;
    bool run = true;
    // Start is called before the first frame update
    void Start()
    {
        anim.SetFloat("tempo", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (run)
        {
            if (trig.active)
            {
                anim.SetFloat("tempo", 2);
                run = false;
            }
        }
        else if(!trig.active)
        {
            ccds.SetActive(false);
            anim.SetFloat("tempo", -2);
        }
        if ((anim.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime) > 1.0f)
        {
            ccds.SetActive(true);
        }
    }
}
