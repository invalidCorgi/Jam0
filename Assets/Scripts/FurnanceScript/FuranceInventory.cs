using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuranceInventory : MonoBehaviour
{
    // Start is called before the first frame update
    public CraftingConstants.Resource[] inventory;
    public int size;
    private int actualItemsInside;
    void Start()
    {
        if (size == 0) size = 2;
        actualItemsInside = 0;
        createInventory();        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void createInventory()
    {
        inventory = new CraftingConstants.Resource[size];
        for (int i = 0; i < size; i++)
        {
            inventory[i] = CraftingConstants.Resource.None;
            
        }
    }

    public void putItem(CraftingConstants.Resource item)
    {
        if (actualItemsInside < size)
        {
            inventory[actualItemsInside] = item;
            actualItemsInside++;
            for(int i = 0; i < size; i++)
            {
                print("INV: " + inventory[i].ToString());
            }

        }
           
    }

    public void clearInvenory()
    {
        for(int i = 0; i < size; i++)
        {
            inventory[i] = CraftingConstants.Resource.None;
        }
    }
}
