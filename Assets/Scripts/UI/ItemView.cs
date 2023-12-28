using AI;
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

    [SerializeField]
    private GameObject blende;

    public void SetItem(Item item)
    {
        priceText.text = priceString.Replace("{value}", item.Price.ToString());
        weightText.text = weightString.Replace("{value}", item.Weight.ToString());
    }

    public void IsInBag(bool isInBag)
    {
        blende.SetActive(!isInBag);
        priceText.fontStyle = isInBag ? FontStyles.Normal : FontStyles.Strikethrough;
        weightText.fontStyle = isInBag ? FontStyles.Normal : FontStyles.Strikethrough;
    }
}