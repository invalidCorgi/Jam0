using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CraftingManager : MonoBehaviour
{
    public GameObject gamePanel;
    public GameObject winPanel;
    public Image ResultImage;
    public Image Resource1;
    public Image Resource2;
    public Image Resource3;
    private List<Image> ResourceImages;

    private CraftingConstants.Recipe recipe;
    private List<CraftingConstants.Resource> availableResources;

    // Start is called before the first frame update
    void Start()
    {
        ResourceImages = new List<Image>
        {
            Resource1,
            Resource2,
            Resource3
        };

        availableResources = new List<CraftingConstants.Resource> 
        { 
            CraftingConstants.Resource.Bananana, 
            CraftingConstants.Resource.Bunny, 
            CraftingConstants.Resource.Chocolate,
            //CraftingConstants.Resource.Hammer,
            //CraftingConstants.Resource.Tubes,
            //CraftingConstants.Resource.Cable,
            //CraftingConstants.Resource.HamsterReel
        };

        FindAndSetNewRecipe();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FinishCrafting()
    {
        availableResources.Add(recipe.Result);
        FindAndSetNewRecipe();
    }

    public void FindAndSetNewRecipe()
    {
        for (int i = 0; i < ResourceImages.Count; i++)
        {
            ResourceImages[i].transform.parent.gameObject.SetActive(true);
        }

        var recipes = CraftingConstants.Recipes
            .Where(x => !availableResources.Contains(x.Result))
            .Where(x => x.Resources.Intersect(availableResources).Count() == x.Resources.Distinct().Count())
            .ToList();

        recipe = recipes
            .FirstOrDefault();

        if(recipe == default)
        {
            gamePanel.SetActive(false);
            winPanel.SetActive(true);
            return;
        }

        ResultImage.sprite = Resources.Load<Sprite>(recipe.Result.ToString());

        for (int i = 0; i < recipe.Resources.Length; i++)
        {
            ResourceImages[i].sprite = Resources.Load<Sprite>(recipe.Resources[i].ToString());
        }

        for (int i = recipe.Resources.Length; i < ResourceImages.Count; i++)
        {
            ResourceImages[i].transform.parent.gameObject.SetActive(false);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        FinishCrafting();
        //Debug.Log("heh");
        //collision.gameObject;
        /*foreach (ContactPoint contact in collision.contacts)
        {
            Debug.DrawRay(contact.point, contact.normal, Color.white);
        }*/
    }
}
