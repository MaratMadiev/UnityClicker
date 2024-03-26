using Core;
using Game;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    List<ResourceVisual> visuals;
    [SerializeField]
    List<ShopVisual> shopVisuals;


    ResourceBank _bank = new ResourceBank();

    internal ResourceBank Bank
    {
        get { return _bank; }
    }

    private void Awake()
    {
        StartGame();
    }
    /// <summary>
    /// Starts game
    /// </summary>
    private void StartGame()
    {
        SubscribeVisuals();
        SetBankStartResources();
    }

    private void SubscribeVisuals()
    {
        foreach (var comp in visuals)
        {
            if (comp != null)
            {
                var resourceCount = _bank.GetResource(comp.resource);
                resourceCount.OnValueChanged = comp.UpdateText;
            }
        }

        foreach (var shop in shopVisuals)
        {
            if (shop != null)
            {
                var resourceCount = _bank.GetResource(shop.resource);
                resourceCount.OnValueChanged = shop.UpdateText;
            }
        }

    }

    /// <summary>
    /// Sets start resources
    /// </summary>
    private void SetBankStartResources()
    {
        _bank.ChangeResource(GameResource.Human, 10);
        _bank.ChangeResource(GameResource.Food, 5);
        _bank.ChangeResource(GameResource.Wood, 5);
    }
}
