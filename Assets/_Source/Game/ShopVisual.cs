using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopVisual : MonoBehaviour
{
    [SerializeField]
    internal Core.GameResource resource;
    [SerializeField]
    internal TextMeshProUGUI text;


    internal void UpdateText(int newVal)
    {
        text.text = $"lvl {newVal + 1}";
    }
}
