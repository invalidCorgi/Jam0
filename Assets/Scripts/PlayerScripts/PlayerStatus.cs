using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    // Start is called before the first frame update
    public float x, y, z;
    public CraftingConstants.Resource itemInHands;
    public Image inHandsImage;

    void Start()
    {
        x = gameObject.transform.position.x;
        y = gameObject.transform.position.y;
        z = gameObject.transform.position.z;
        itemInHands = CraftingConstants.Resource.None;
    }

    // Update is called once per frame
    void Update()
    {
        if(itemInHands.ToString() == "None")
            inHandsImage.sprite = Resources.Load<Sprite>("Textures\\UI\\ItemsUI\\smallItemBoxBackground");
        else
            inHandsImage.sprite = Resources.Load<Sprite>(itemInHands.ToString());
        x = gameObject.transform.position.x;
        y = gameObject.transform.position.y;
        z = gameObject.transform.position.z;
    }
}
