using GeneticAlgorithm;
using UnityEngine;
using TMPro;

public class ItemView : MonoBehaviour
{
    [SerializeField]
    private TMP_Text priceText;

    [SerializeField]
    private TMP_Text weightText;

    [SerializeField]
    private string priceString;

    [SerializeField]
    private string weightString;

    public void SetItem(Item item)
    {
        priceText.text = priceString.Replace("{value}", item.Price.ToString());
        weightText.text = weightString.Replace("{value}", item.Weight.ToString());
    }
}