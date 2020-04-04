using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rabbitController : MonoBehaviour
{
    float speed = 10;
    float gravity = 12;
    float jumpSpeed = 5;

    Vector3 moveDir = Vector3.zero;

    CharacterController controller;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponentInChildren<CharacterController>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {

        if (Input.GetKey(KeyCode.A))
        {
            //rot += Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
            transform.Rotate(0, -150 * Time.deltaTime, 0);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            //rot += Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
            transform.Rotate(0, 150 * Time.deltaTime, 0);
        }
        else if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            transform.Rotate(0, 0, 0);
        }

        if (controller.isGrounded)
        {

            if (Input.GetKey(KeyCode.W))
            {
                anim.SetInteger("condition", 1);
                moveDir = Vector3.forward;
                moveDir *= speed;
                moveDir = transform.TransformDirection(moveDir);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                anim.SetInteger("condition", 1);
                moveDir = new Vector3(0, 0, -1);
                moveDir *= speed;
                moveDir = transform.TransformDirection(moveDir);
            }

            

            if (Input.GetKeyDown(KeyCode.Space))
            {
                moveDir.y = jumpSpeed;
            }

        }

        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
        {
            anim.SetInteger("condition", 0);
            moveDir = new Vector3(0, 0, 0);
        }

        //rot += Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
        //transform.eulerAngles = new Vector3(0, rot, 0);

        //}
        //transform.Translate(moveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime, 0f, moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime);

        moveDir.y -= gravity * Time.deltaTime;
        controller.Move(moveDir * Time.deltaTime);
    }
}
