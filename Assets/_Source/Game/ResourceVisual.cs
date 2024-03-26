using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


namespace Game
{
    public class ResourceVisual : MonoBehaviour
    {
        [SerializeField]
        internal Core.GameResource resource;
        [SerializeField]
        internal TextMeshProUGUI text;


        internal void UpdateText(int newVal)
        {
            text.text = newVal.ToString();
        }
    }
}