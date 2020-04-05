using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CraftingManager : MonoBehaviour
{
    public GameObject gamePanel;
    public GameObject winPanel;
    public GameObject timerObject;
    public Image inventoryImage;
    public Image ResultImage;
    public Image Resource1;
    public Image Resource2;
    public Image Resource3;

    public Text ProgressText;
    public Image ProgressImage;
    public float targetProgressImageWidth;

    public GameObject Hammer;
    public GameObject Tube;
    public GameObject Cable;
    public GameObject HamsterReel;

    private List<Image> ResourceImages;

    private CraftingConstants.Recipe recipe;
    private List<CraftingConstants.Resource> availableResources;
    private List<CraftingConstants.Resource> inventory;

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
            CraftingConstants.Resource.Chocolate
        };

        inventory = new List<CraftingConstants.Resource>();

        UpdateProgressTextAndImage();
        FindAndSetNewRecipe();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FinishCrafting()
    {
        GameObject.Find("BackgroundRecipe1").GetComponent<FlashController>().SetPositive();
        GameObject.Find("BackgroundRecipe2").GetComponent<FlashController>().SetPositive();
        GameObject.Find("BackgroundResult").GetComponent<FlashController>().SetPositive();

        availableResources.Add(recipe.Result);
        UpdateProgressTextAndImage();

        if (recipe.Result == CraftingConstants.Resource.Hammer)
            Hammer.SetActive(true);
        if (recipe.Result == CraftingConstants.Resource.Tubes)
            Tube.SetActive(true);
        if (recipe.Result == CraftingConstants.Resource.Cable)
            Cable.SetActive(true);
        if (recipe.Result == CraftingConstants.Resource.HamsterReel)
            HamsterReel.SetActive(true);

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
            inventoryImage.gameObject.SetActive(false);
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

    public void TryAddNewItemToInventory(CraftingConstants.Resource resource)
    {
        if(recipe.Resources[inventory.Count] == resource)
        {
            if(recipe.Resources.Length - 1 == inventory.Count)
            {
                inventory.Clear();
                FinishCrafting();
            }
            else
            {
                ResourceImages[inventory.Count].sprite = Resources.Load<Sprite>("Textures\\UI\\ItemsUI\\check");
                inventory.Add(resource);
                GameObject.Find($"BackgroundRecipe{inventory.Count}").GetComponent<FlashController>().SetPositive();
            }
        }
        else
        {
            GameObject.Find("InHandsBackground").GetComponent<FlashController>().SetNegative();
            GameObject.Find("TimerBackground").GetComponent<FlashController>().SetNegative();
            timerObject.GetComponent<Timer>().effectiveRemainingTime -= 5;
        }
    }

    public void UpdateProgressTextAndImage()
    {
        var recipesCount = (float)CraftingConstants.Recipes.Length;
        var recipesDone = (float)CraftingConstants.Recipes.Select(x => x.Result).Intersect(availableResources).Count();

        ProgressText.text = $"{recipesDone} / {recipesCount}";

        var rt = ProgressImage.GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2((recipesDone / recipesCount) * targetProgressImageWidth, rt.sizeDelta.y);
    }
}
