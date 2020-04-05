using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashController : MonoBehaviour
{
    private float flashTime = 1.0f;
    private Color color;
    private float time = 0;

    // Start is called before the first frame update
    void Start()
    {
        color = Color.green;
    }

    // Update is called once per frame
    void Update()
    {
        if (time > 0)
            time -= Time.deltaTime;

        if (time < 0)
            time = 0;

        gameObject.GetComponent<Image>().color = color * time;
    }

    public void SetPositive()
    {
        color = Color.green;
        time = flashTime;
    }

    public void SetNegative()
    {
        color = Color.red;
        time = flashTime;
    }
}
