using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventLook : MonoBehaviour
{
    public AudioSource sound;
    public GameObject toEnable;
    public GameObject disable;
    public Rigidbody rdb;
    public Vector3 force;
    public bool vanish = false;
    public Eventcaller caller;
    public GameObject texttoshow;

    public void Start()
    {
        if (texttoshow)
            texttoshow.SetActive(true);

        MissionPointer.actualmission = transform;
        //gameObject.SetActive(false);
    }

    //funcao que é chamada depois de um tempo olhando
    public void ButtonAction()
    {
        //toca o som escolhido
        if (sound)
        {
            sound.Play();
        }
        //habilita gameobjec selecionado
        if (toEnable)
        {
            toEnable.SetActive(true);
        }
        //desabilita gameobject
        if (disable)
        {
            disable.SetActive(false);
        }
        //adiciona uma força no objeto selecionado
        if (rdb)
        {
            rdb.AddForce(force,ForceMode.Impulse);
        }

        if (vanish)
        {
            BounceIcon bounce = GetComponentInChildren<BounceIcon>();
            bounce.StartCoroutine(bounce.Vanish());
            //Destroy(gameObject, 3);
            gameObject.GetComponent<Collider>().enabled = false;
            Invoke("Vanish", 3);
        }
        if (caller)
        {
            caller.UnPause();
        }
    }

    void Vanish()
    {
        gameObject.SetActive(false);
    }

    

}
