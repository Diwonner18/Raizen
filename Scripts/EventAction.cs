using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventAction : MonoBehaviour
{

    public float counter;
    bool onpoint = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (onpoint)
        {
            counter += Time.deltaTime;
        }
    }

    public void OnPointerEnter()
    {
        onpoint = true;
    }

    public void OnPointerExit()
    {
        onpoint = false;
    }
}