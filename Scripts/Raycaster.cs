using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Raycaster : MonoBehaviour
{
    public TextMesh textDebug;
    public GameObject crosshair;
    float counter=2;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // se o raio q sai da camera bate em alguma coisa
        if (Physics.Raycast(transform.position, transform.TransformDirection(new Vector3(0,-0.1f,1)), out RaycastHit hit, 6))
        {

            Debug.DrawRay(transform.position, transform.TransformDirection(new Vector3(0, -0.1f, 1)) * hit.distance, Color.yellow);
            //coloca o nome do objeto na frente do raio na saida de debug
            if(textDebug)
            textDebug.text = hit.transform.name;
            //posiciona o crosshair no ponto de impacto do raio
            if (crosshair)
            {
                crosshair.transform.position = hit.point;
                //crosshair.transform.forward = hit.normal;

                //faz o crosshair sempre se alinhar com a camera
                crosshair.transform.forward = -transform.forward;
            }
            //se o objeto tiver tag player (iteragivel)
            if (hit.transform.gameObject.CompareTag("Interact"))
            {
                if (crosshair)
                {
                    //troca cor do crosshair
                    crosshair.GetComponent<MeshRenderer>().material.color = (Color.green);
                }
                //decrementa o contador 
                counter -= Time.deltaTime;
                //se o contador for < 0 chama a funça no objeto ButtonAction()
                if (counter < 0)
                {
                    hit.transform.gameObject.SendMessageUpwards("ButtonAction");
                    counter = 3;//reseta o contador
                }
            } // senao verifica se o objeto é com o tag andavel

            else if (hit.transform.gameObject.CompareTag("Botao"))
            {
                if (crosshair)
                {
                    //troca cor do crosshair
                    crosshair.GetComponent<MeshRenderer>().material.color = (Color.green);
                }
                //decrementa o contador 
                counter -= Time.deltaTime;
                //se o contador for < 0 chama a funça no objeto ButtonAction()
                if (counter < 0)
                {
                    hit.transform.gameObject.SendMessageUpwards("ButtonAction");
                    counter = 3;//reseta o contador
                }
            }

           else if (hit.transform.gameObject.CompareTag("Sim"))
            {
                if (crosshair)
                {
                    //troca cor do crosshair
                    crosshair.GetComponent<MeshRenderer>().material.color = (Color.green);
                    SceneManager.LoadScene("posto");
                }
                //decrementa o contador 
                
            }

            else if (hit.transform.gameObject.CompareTag("Não"))
            {
                if (crosshair)
                {
                    //troca cor do crosshair
                    crosshair.GetComponent<MeshRenderer>().material.color = (Color.green);
                    SceneManager.LoadScene("Intro");
                }
                //decrementa o contador 
                
            }
            else
            {
                //se nao for nada disso reseta o contador
                counter = 3;
                //pinta o crossrair de vermelho
                crosshair.GetComponent<MeshRenderer>().material.color = (Color.red);
            }
        }
        else
        {
            //se nao da raycast o crosshair some
            crosshair.GetComponent<MeshRenderer>().material.color=(Color.black);
        }

       
    }
}
