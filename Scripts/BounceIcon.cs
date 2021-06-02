using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceIcon : MonoBehaviour
{
    public GameObject player;
    Vector3 pos;
    Vector3 playerPos;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        transform.LookAt(player.transform);
        pos = transform.position;
        playerPos = player.transform.position;
    }
    // Update is called once per frame
    void LateUpdate()
    {
        if(playerPos != player.transform.position)
        {
            transform.LookAt(player.transform);
            playerPos = player.transform.position;
        }
        transform.position = pos + new Vector3(0, Mathf.PingPong(Time.time*0.1f, 0.1f), 0);
    }

    public IEnumerator Vanish()
    {
        float count = 3;
        while (count > 0)
        {
            yield return new WaitForEndOfFrame();
            transform.Rotate(0, 10, 0);
            count -= Time.deltaTime*2;
            transform.localScale = Vector3.ClampMagnitude(new Vector3(count, count, count), transform.localScale.magnitude);
        }

    }

}
