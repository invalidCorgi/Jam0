using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private float timeForLevel = 120;
    [SerializeField]
    private GameObject gamePanel;
    [SerializeField]
    private GameObject gameOverPanel;
    [SerializeField]
    private GameObject winPanel;
    private float startingWidth;

    public float effectiveRemainingTime;
    // Start is called before the first frame update
    void Start()
    {
        startingWidth = gameObject.transform.GetComponent<RectTransform>().rect.width;
        effectiveRemainingTime = timeForLevel;
        //Debug.Log(startingWidth);
    }

    // Update is called once per frame
    void Update()
    {
        effectiveRemainingTime -= Time.deltaTime;
        var rt = gameObject.transform.GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(startingWidth * (effectiveRemainingTime/timeForLevel), rt.sizeDelta.y);

        if (effectiveRemainingTime < 0)
        {
            gamePanel.SetActive(false);
            gameOverPanel.SetActive(true);
        }

        //Debug.Log(effectiveRemainingTime);
    }
}
