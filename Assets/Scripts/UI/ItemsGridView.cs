using System.Collections.Generic;
using AI;
using UnityEngine;

namespace UI
{
    public class ItemsGridView : MonoBehaviour
    {
        [SerializeField]
        private Transform content;

        [SerializeField]
        private ItemView itemViewPrefab;

        private List<ItemView> _activeItems = new List<ItemView>();


        public void Clear()
        {
            var existingItems = FindObjectsOfType<ItemView>();
            foreach (var existingItem in existingItems)
            {
                Destroy(existingItem.gameObject);
            }
        }

        public void SetItems(List<Item> items)
        {
            foreach (var item in items)
            {
                var currentItem = Instantiate(itemViewPrefab, content);
                currentItem.SetItem(item);
                _activeItems.Add(currentItem);
            }
        }

        public void ShowAllItems()
        {
            foreach (var item in _activeItems)
            {
                item.IsInBag(false);
            }
        }

        public void ShowItems(List<bool> genes)
        {
            for (int i = 0; i < genes.Count; i++)
            {
                var itemView = _activeItems[i];
                itemView.IsInBag(genes[i]);
            }
        }

        private void OnDestroy()
        {
            foreach (var item in _activeItems)
            {
                Destroy(item.gameObject);
            }
        }
    }
}