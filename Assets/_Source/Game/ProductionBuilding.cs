using Core;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.UIElements.Experimental;

[RequireComponent(typeof(Button))]
public class ProductionBuilding : MonoBehaviour
{

    [SerializeField]
    GameManager _gameManager;
    [SerializeField]
    GameResource _gameResource;
    [SerializeField]
    GameResource _levelResource;
    [SerializeField]
    float productionTime;

    const float deltaTime = 0.01F;

    private void IncrementValue()
    {
        StartCoroutine(ProduceResourceAfterTime());
    }

    private IEnumerator ProduceResourceAfterTime()
    {
        var slider = transform.Find("Slider");
        var sliderBase = transform.Find("SliderBase");
        var sliderChildren = slider == null ? null : slider.transform.Find("SliderChild");
        var vecOfScale = new Vector3(0, 1, 1);
        var color = new Color(1, 0, 0);

        var totalProductionTime = productionTime * Mathf.Clamp(1 - _gameManager.Bank.GetResource(_levelResource).Value * 1.0F / 100, 0, 1);

        sliderBase?.gameObject.SetActive(true);
        gameObject.GetComponent<Button>().interactable = false;

        float passedTime = 0;
        while (passedTime < totalProductionTime)
        {
            var easing = Easing.InOutQuad(passedTime / totalProductionTime);
            
            vecOfScale.x = easing;
            color.r = Mathf.Lerp(1, 0, easing);
            color.g = Mathf.Lerp(0, 1, easing);

            if (slider != null)
            {
                slider.localScale = vecOfScale;
            }
            if (sliderChildren != null && sliderChildren.gameObject.GetComponent<Image>() != null)
            {
                sliderChildren.GetComponent<Image>().color = color;
            }
            
            passedTime += deltaTime;
            yield return new WaitForSeconds(deltaTime);

        }

        vecOfScale = new Vector3(0, 1, 1);
        if (slider != null)
        {
            slider.localScale = vecOfScale;
        }


        sliderBase?.gameObject.SetActive(false);
        gameObject.GetComponent<Button>().interactable = true;

        if (_gameManager != null)
        {
            var bank = _gameManager.Bank;
            bank?.ChangeResource(_gameResource, 1);
        }
    }
}
