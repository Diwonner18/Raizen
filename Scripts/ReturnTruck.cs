using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnTruck : MonoBehaviour
{
    public Animator anima;
    public float frame = 0.0f;
    public GameObject trigger;
    bool run = false;
    public GameObject Caminhao;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (trigger.active)
        {
            run = true;
       
        }

        if (!trigger.active && run)
        {

            anima.SetFloat("tempo", -2);
            if ((anima.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime) < 0f)
            {
                Caminhao.SetActive(false);
            }
            
        }

    }
}
        
