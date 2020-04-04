using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitMannequinController : MonoBehaviour
{
    float speed = 1;
    float rotSpeed = 0.0000000001f;
    float gravity = 8;
    float rot = 0f;
    string state = "begin";
    float time = 63f;
    bool canGo = false;
    float debugTime;

    Vector3 moveDir = Vector3.zero;

    CharacterController controller;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponentInChildren<CharacterController>();
        anim = GetComponentInChildren<Animator>();
        debugTime = 90f;
    }

    // Update is called once per frame
    void Update()
    {
        if (debugTime > 0)
        {
            debugTime -= Time.deltaTime;
            if (debugTime <= 0)
            {
                state = "lookAtEngine";
            }
        }
        if (debugTime <= 0 && debugTime >= -2 )
        {
            debugTime -= Time.deltaTime;
            if (debugTime < -2)
            {
                state = "rotate";
            }
        }
        if (time >0)
        {
            time -= Time.deltaTime;
            if(time <= 0)
            {
                canGo = true;
            }
        }

        if(canGo == true)
        {
            canGo = false;
            state = "goToFactory";
        }
        if(state == "rotate")
        {
            debugTime -= Time.deltaTime;
            if(debugTime <= -3f)
            {
                state = "lookAtEngine";
            }
        }
        
        Movement();
    }

    void Movement()
    {

        if(state == "begin")
        {
            anim.SetInteger("condition", 1);
            moveDir = Vector3.forward;
            moveDir *= speed;
            moveDir = transform.TransformDirection(moveDir);
            if(transform.position.z <= 47)
            {
                state = "lookAtEngine";
            }
        }
        else if(state == "lookAtEngine")
        {
            anim.SetInteger("condition", 0);
            moveDir = new Vector3(0, 0, 0);
        }
        else if(state == "goToFactory")
        {
            anim.SetInteger("condition", 1);
            moveDir = Vector3.forward;
            moveDir *= speed;
            moveDir = transform.TransformDirection(moveDir);
        }
        else if(state == "rotate")
        {
            transform.Rotate(0, 1, 0);
        }

        moveDir.y -= gravity * Time.deltaTime;
        controller.Move(moveDir * Time.deltaTime);
    }
}
