using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Eventcaller : MonoBehaviour
{
    [System.Serializable]
    public
        struct Myevent{
        public string coment;
        public float timedispatcher;
        public GameObject toactive;
        public bool pauseonthis;
        public bool cancelthis;
    }
    public Myevent[] myevent;

    public VideoPlayer vp;
    public AudioSource sour;
    public int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        index = 0;
        //sour = vp.GetTargetAudioSource(0);
        sour.Play();
        vp.Play();
        
    }

    public void UnPause()
    {
        //vp.playbackSpeed = 1;
        
        StartCoroutine("MyUnPause");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            vp.time -= 10;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            vp.time += 10;
            
            for (int i = 0; i < myevent.Length; i++)
            {
                if (myevent[i].timedispatcher <= vp.time)
                {
                    index = i;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (vp.playbackSpeed > 0)
            {
                vp.playbackSpeed = 0;
                sour.Pause();
            }
            else
            {
                vp.playbackSpeed = 1;
                sour.Play();
            }
        }

        print(vp.time);

        if (index >= myevent.Length)
        {
            index = myevent.Length - 1;
        }

        if (myevent[index].timedispatcher <= vp.time)
        {
            if (myevent[index].cancelthis)
            {
                index++;
                return;
            }
            if (myevent[index].toactive)
            myevent[index].toactive.SetActive(true);
            
           

            if (myevent[index].pauseonthis)
            {
                StartCoroutine("Pause");
                //vp.playbackSpeed = 0;
            }
            index++;
            
        }
    }

    IEnumerator Pause()
    {

        while (sour.volume > 0.01f)
        {
            yield return new WaitForEndOfFrame();
            sour.volume -= Time.deltaTime * 10;
        }
        vp.playbackSpeed = 0;
        sour.Pause();
    }

    IEnumerator MyUnPause()
    {
        vp.playbackSpeed = 1;
        sour.Play();
        while (sour.volume < 0.5f)
        {
            yield return new WaitForEndOfFrame();
            sour.volume += Time.deltaTime * 10;
        }
        
    }

}
