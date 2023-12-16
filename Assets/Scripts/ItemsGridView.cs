using System.Collections.Generic;
using System.Linq;
using GeneticAlgorithm;
using UnityEngine;
using UnityEngine.Pool;

public class ItemsGridView : MonoBehaviour
{
    [SerializeField]
    private Transform content;

    [SerializeField]
    private ItemView itemViewPrefab;

    private ObjectPool<ItemView> _itemViewPool;
    private List<ItemView> _activeItems;

    private void Start()
    {
        FindObjectsOfType<ItemView>().ToList().ForEach(Destroy);
        _activeItems = new List<ItemView>(AlgorithmSettings.NumberOfItems);
        _itemViewPool = new ObjectPool<ItemView>(
            () => Instantiate(itemViewPrefab, content),
            obj => obj.gameObject.SetActive(true),
            obj => obj.gameObject.SetActive(false),
            Destroy
        );
    }

    public void SetItems(List<Item> items)
    {
        _activeItems.ForEach(item => _itemViewPool.Release(item));
        _activeItems.Clear();
        foreach (var item in items)
        {
            var currentItem = _itemViewPool.Get();
            currentItem.SetItem(item);
            _activeItems.Add(currentItem);
        }
    }
}