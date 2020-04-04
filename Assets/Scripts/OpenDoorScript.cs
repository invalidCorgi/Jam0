using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorScript : MonoBehaviour
{
    float time;
    bool open;
    float openTime;
    float closeTime;
    float secondTime;
    bool close;
    // Start is called before the first frame update
    void Start()
    {
        time = 52f;
        open = false;
        openTime = 25f;
        closeTime = 25f;
        secondTime = 90f;
        close = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (time >=0)
        {
            time -= Time.deltaTime;
            if(time <0)
            {
                open = true;
            }
        }
        if(open==true)
        {
            openTime -= Time.deltaTime;
            if(openTime <0)
            {
                open = false;
                transform.position = new Vector3(transform.position.x + 0.5f, transform.position.y, transform.position.z + 3.91f) ;

            }
            transform.position = new Vector3(transform.position.x, transform.position.y-Time.deltaTime, transform.position.z);
        }

        if(secondTime >= 0)
        {
            secondTime -= Time.deltaTime;
            if(secondTime < 0)
            {
                close = true;
            }
        }

        if(close == true)
        {
            closeTime -= Time.deltaTime;
            if(closeTime <0)
            {
                close = false;
            }
            transform.position = new Vector3(transform.position.x, transform.position.y + Time.deltaTime, transform.position.z);
        }


    }
}
