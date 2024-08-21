using TMPro;
using UnityEngine;

public class ResourcesAmountDisplayer : MonoBehaviour
{
    [SerializeField] private TMP_Text _resourcesAmountText;
    [SerializeField] private ResourcesCollector _resourcesCollector;

    private void OnEnable()
    {
        _resourcesCollector.GoldCountChanged += ChangeText;
    }

    private void OnDisable()
    {
        _resourcesCollector.GoldCountChanged -= ChangeText;
    }

    private void ChangeText(float goldAmount) 
    {
        _resourcesAmountText.text = goldAmount.ToString();    
    }
}
