using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionWithPlayer : MonoBehaviour
{
    private GameObject player;
    public float interactionDistance;
    public bool isInteractionPossible;
   
    // Start is called before the first frame update
    void Start()
    {
        isInteractionPossible = false;
        interactionDistance = 3.0f;
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (getDistanceFromPlayer() <= interactionDistance) { isInteractionPossible = true; }
        else isInteractionPossible = false;

        if(isInteractionPossible) gameObject.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 0f, 1.0f);
        else gameObject.GetComponent<Renderer>().material.color = new Color(1.0f, 0.0f, 0f, 1.0f);
    }

    private float getDistanceFromPlayer()
    {
        float positionX = gameObject.transform.position.x;
        float positionY = gameObject.transform.position.y;
        float positionZ = gameObject.transform.position.z;

        return Mathf.Sqrt(Mathf.Pow((player.transform.position.x) - positionX, 2)
                + Mathf.Pow((player.transform.position.y) - positionY, 2) 
                + Mathf.Pow((player.transform.position.z) - positionZ, 2));
    }
}
