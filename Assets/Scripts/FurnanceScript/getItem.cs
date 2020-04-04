using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getItem : MonoBehaviour
{
    private PlayerStatus playerStatus;
    private InteractionWithPlayer isInteraction;
    private CraftingConstants.Resource itemsList;
    //private FuranceInventory inventory;
    private CraftingManager craftingManager;

    // Start is called before the first frame update
    void Start()
    {
        playerStatus = GameObject.Find("Player").GetComponent<PlayerStatus>();
        isInteraction = gameObject.GetComponent<InteractionWithPlayer>();
        //inventory = gameObject.GetComponent<FuranceInventory>();
        craftingManager = gameObject.GetComponent<CraftingManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && playerStatus.itemInHands != CraftingConstants.Resource.None)
        {
            if (isInteraction.isInteractionPossible)
            {
                craftingManager.TryAddNewItemToInventory(playerStatus.itemInHands);
            }
            playerStatus.itemInHands = CraftingConstants.Resource.None;
        }
    }
}
