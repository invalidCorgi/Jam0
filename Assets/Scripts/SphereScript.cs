using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereScript : MonoBehaviour
{
    // Start is called before the first frame update
    public CraftingConstants.Resource resource;
    public float moveSpeed = 200f;
    private float movingX;
    private float movingZ;
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
        if (time < 0)
        {
            rbody.AddForce(movingX * moveSpeed * Time.deltaTime, 1f, movingZ * moveSpeed * Time.deltaTime);
        }
        else
        {
            time -= Time.deltaTime;
        }

        if(Mathf.Abs(rbody.velocity.x) + Mathf.Abs(rbody.velocity.y) + Mathf.Abs(rbody.velocity.z) < 1)
        {
            rbody.velocity = new Vector3(rbody.velocity.x, 3, rbody.velocity.z);
        }

        if (gameObject.transform.position.y < -5)
        {
            gameObject.transform.position = new Vector3(Piecyk.transform.position.x, Piecyk.transform.position.y + 10, Piecyk.transform.position.z);
        }
        //Debug.Log("VELX: " + rbody.velocity.x + " Y: " + rbody.velocity.y + " Z: " + rbody.velocity.z);
        //rbody.velocity.x;
        //rbody.velocity = new Vector3(movingX * moveSpeed * Time.deltaTime, 0, movingZ * moveSpeed * Time.deltaTime);
        //}
        //Debug.Log("POSX: " + transform.position.x + "Y: " + transform.position.y + "Z: " + transform.position.z);

    }

    private void OnEnable()
    {
        Piecyk = GameObject.Find("Piecyk");
        movingX = Random.Range(-1f, 1f);
        movingZ = Random.Range(-1f, 1f);
        time = 1.0f;
        rbody = GetComponent<Rigidbody>();
        if (Piecyk != null)
            transform.position = new Vector3(Piecyk.transform.position.x, Piecyk.transform.position.y, Piecyk.transform.position.z + 1f);
        rbody.velocity = new Vector3(0f, 0f, 10f);
        time = 1.0f;

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "Player")
        {
            //Destroy(gameObject);

            var playerStatus = collision.collider.gameObject.GetComponent<PlayerStatus>();
            if (playerStatus.itemInHands == CraftingConstants.Resource.None)
            {
                //playerStatus.itemInHands = (CraftingConstants.Resource)((int)UnityEngine.Random.Range(0, System.Enum.GetValues(typeof(CraftingConstants.Resource)).Length));
                playerStatus.itemInHands = resource;
                GameObject.Find("InHandsBackground").GetComponent<FlashController>().SetPositive();
                transform.position = new Vector3(Piecyk.transform.position.x, Piecyk.transform.position.y, Piecyk.transform.position.z + 1f);
                rbody.velocity = new Vector3(0f, 0f, 10f);
                time = 1.0f;
            }
        }

        if (collision.collider.name == "Floor" && time < 0)
        {
            if (gameObject.transform.position.y < 0.60)
            {
                rbody.AddForce(movingX * moveSpeed * Time.deltaTime, 50, movingZ * moveSpeed * Time.deltaTime);
                if (rbody.velocity.y > 5)
                {
                    rbody.velocity = new Vector3(rbody.velocity.x, 3, rbody.velocity.z);
                }
                if (rbody.velocity.x > 6)
                {
                    rbody.velocity = new Vector3(3, rbody.velocity.y, rbody.velocity.z);
                }
                if (rbody.velocity.z > 6)
                {
                    rbody.velocity = new Vector3(rbody.velocity.x, rbody.velocity.y, 3);
                }
                if (rbody.velocity.y < 0.5)
                {
                    rbody.velocity = new Vector3(rbody.velocity.x, 3, rbody.velocity.z);
                }
                //rbody.velocity += new Vector3(movingX * moveSpeed * Time.deltaTime, 0f, movingZ * moveSpeed * Time.deltaTime);


            }
            //rbody.AddForce(movingX * moveSpeed * Time.deltaTime, 1, movingZ * moveSpeed * Time.deltaTime);
        }


        movingX = Random.Range(-1f, 1f);
        movingZ = Random.Range(-1f, 1f);
        //print(collision.collider.name);  
    }
}
