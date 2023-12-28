using AI;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class GeneratedItemsView : MonoBehaviour
    {
        [SerializeField]
        private ItemsGridView itemGridView;

        [SerializeField]
        private TMP_Text totalPriceText;

        [SerializeField]
        private TMP_Text totalWeightText;

        [SerializeField]
        private Button nextButton;

        private void Start()
        {
            itemGridView.Clear();
            nextButton.onClick.AddListener(OnNextButtonClicked);
            AlgorithmSettings.GenerateItems();
            itemGridView.SetItems(AlgorithmSettings.Items);
            totalPriceText.text = AlgorithmSettings.AllItemsTotalPrice.ToString();
            totalWeightText.text = AlgorithmSettings.AllItemsTotalWeight.ToString();
        }

        private void OnNextButtonClicked()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        private void OnDestroy()
        {
            nextButton.onClick.RemoveListener(OnNextButtonClicked);
        }
    }
}