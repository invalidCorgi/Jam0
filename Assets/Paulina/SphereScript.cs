using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereScript : MonoBehaviour
{
    // Start is called before the first frame update

    public float moveSpeed = 200f;
    private float test = -1f;
    private float movingX;
    private float movingZ;
    private float movingY;
    private float time;
    public GameObject Piecyk;

    private Rigidbody rbody;

    void Start()
    {
        rbody = GetComponent<Rigidbody>();
        //test = Random.Range(-1f, 1f);
        //Debug.Log(test);
        movingX = Random.Range(-1f, 1f);
        movingZ = Random.Range(-1f, 1f);
        movingY = Random.Range(10f, 100f);
        time = 1.0f;

    }

    // Update is called once per frame
    void Update()
    {
        //float inputX = Input.GetAxis("Horizontal");
        //float inputZ = Input.GetAxis("Vertical");

        //float moveX = inputX * moveSpeed * Time.deltaTime;
        //float moveZ = inputZ * moveSpeed * Time.deltaTime;

        // transform.Translate(moveX, 0f, moveZ);
        //time -= Time.deltaTime;
        //if(time <0)
        //{
        //  time = 5f;
        //rbody.AddForce(movingX * moveSpeed * Time.deltaTime, 10, movingZ * moveSpeed * Time.deltaTime);
        //rbody.AddForce(movingX * moveSpeed * Time.deltaTime, 0f, movingZ * moveSpeed * Time.deltaTime);
        //}
        //else
        //{
        if(time < 0)
        {
            rbody.AddForce(movingX * moveSpeed * Time.deltaTime, 1f, movingZ * moveSpeed * Time.deltaTime);
        }
        else
        {
            time -= Time.deltaTime;
        }
        //Debug.Log("X: " + rbody.velocity.x + " Y: " + rbody.velocity.y + " Z: " + rbody.velocity.z);
        //rbody.velocity.x;
        //rbody.velocity = new Vector3(movingX * moveSpeed * Time.deltaTime, 0, movingZ * moveSpeed * Time.deltaTime);
        //}
        Debug.Log("X: " + transform.position.x + "Y: " + transform.position.y + "Z: " + transform.position.z);

    }

    private void OnEnable()
    {
        movingX = Random.Range(-1f, 1f);
        movingZ = Random.Range(-1f, 1f);
        movingY = Random.Range(10f, 100f);
        time = 1.0f;
        rbody = GetComponent<Rigidbody>();
        transform.position = new Vector3(Piecyk.transform.position.x, Piecyk.transform.position.y, Piecyk.transform.position.z + 1f);
        rbody.velocity = new Vector3(0f, 0f, 10f);
        time = 1.0f;

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "Floor" && time < 0)
        {
            if(gameObject.transform.position.y < 0.60)
            {
                rbody.AddForce(movingX * moveSpeed * Time.deltaTime, 50, movingZ * moveSpeed * Time.deltaTime);
                if(rbody.velocity.y>5)
                {
                    rbody.velocity = new Vector3(rbody.velocity.x, 3, rbody.velocity.z);
                }
                if(rbody.velocity.x>6)
                {
                    rbody.velocity = new Vector3(3, rbody.velocity.y, rbody.velocity.z);
                }
                if (rbody.velocity.z > 6)
                {
                    rbody.velocity = new Vector3(rbody.velocity.x, rbody.velocity.y, 3);
                }
                if(rbody.velocity.y < 0.5)
                {
                    rbody.velocity = new Vector3(rbody.velocity.x, 3, rbody.velocity.z);
                }
                //rbody.velocity += new Vector3(movingX * moveSpeed * Time.deltaTime, 0f, movingZ * moveSpeed * Time.deltaTime);


            }
            //rbody.AddForce(movingX * moveSpeed * Time.deltaTime, 1, movingZ * moveSpeed * Time.deltaTime);
        }
        if( collision.collider.name == "Player")
        {
            //Destroy(gameObject);
            transform.position = new Vector3(Piecyk.transform.position.x, Piecyk.transform.position.y, Piecyk.transform.position.z+1f);
            rbody.velocity = new Vector3(0f, 0f, 10f);
            time = 1.0f;

        }

        movingX = Random.Range(-1f, 1f);
        movingZ = Random.Range(-1f, 1f);
        movingY = Random.Range(-1f, 1f);
        //print(collision.collider.name);  
    }
}
