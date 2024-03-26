using Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopBuilding : MonoBehaviour
{

    [SerializeField]
    GameManager _gameManager;
    [SerializeField]
    GameResource _gameResource;
    public void IncrementValue()
    {
        _gameManager.Bank.ChangeResource(_gameResource, 1);
    }
}
