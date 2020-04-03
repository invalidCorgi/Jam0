using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private float timeForLevel = 120;
    [SerializeField]
    private GameObject gamePanel;
    [SerializeField]
    private GameObject gameOverPanel;
    [SerializeField]
    private Image inventoryImage;
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

        var img = gameObject.GetComponent<Image>();

        var ratio = effectiveRemainingTime / timeForLevel;

        img.color = new Color(1 - ratio, ratio, 0);

        rt.sizeDelta = new Vector2(startingWidth * (effectiveRemainingTime/timeForLevel), rt.sizeDelta.y);


        if (effectiveRemainingTime < 0)
        {
            gamePanel.SetActive(false);
            inventoryImage.gameObject.SetActive(false);
            gameOverPanel.SetActive(true);
        }
    }
}
