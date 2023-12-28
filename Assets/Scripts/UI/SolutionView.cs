using System.Collections.Generic;
using AI;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class SolutionView : MonoBehaviour
    {
        [SerializeField]
        List<Button> solutionButtons = new List<Button>();

        [SerializeField]
        private Button allItemsButton;

        [SerializeField]
        private ItemsGridView itemGridView;

        [SerializeField]
        private TMP_Text totalPriceText;

        [SerializeField]
        private TMP_Text totalWeightText;

        [SerializeField]
        private Button tryAgainButton;

        private int _currentSolutionIndex = 0;

        private void Start()
        {
            itemGridView.Clear();
            tryAgainButton.onClick.AddListener(OnTryAgainButtonClicked);
            allItemsButton.onClick.AddListener(ShowAllItems);
            for (var i = 0; i < solutionButtons.Count; i++)
            {
                var index = i;
                solutionButtons[i].onClick.AddListener(() => SelectSolution(index));
            }

            GeneticAlgorithm.Run();
            itemGridView.SetItems(AlgorithmSettings.Items);
            SelectSolution(_currentSolutionIndex);
        }

        private void SelectSolution(int i)
        {
            allItemsButton.image.color = allItemsButton.colors.normalColor;
            _currentSolutionIndex = i;
            for (int j = 0; j < solutionButtons.Count; j++)
            {
                solutionButtons[j].image.color =
                    i == j ? solutionButtons[j].colors.selectedColor : solutionButtons[j].colors.normalColor;
            }

            ShowSolution();
        }

        private void ShowSolution()
        {
            var solution = GeneticAlgorithm.CurrentPopulation.Solutions[_currentSolutionIndex];
            itemGridView.ShowItems(solution.Genes);
            totalPriceText.text = solution.TotalPrice.ToString();
            totalWeightText.text = solution.TotalWeight.ToString();
        }

        private void ShowAllItems()
        {
            allItemsButton.image.color = allItemsButton.colors.pressedColor;
            foreach (var button in solutionButtons)
            {
                button.image.color = button.colors.normalColor;
            }

            itemGridView.ShowAllItems();
            totalPriceText.text = AlgorithmSettings.AllItemsTotalPrice.ToString();
            totalWeightText.text = AlgorithmSettings.AllItemsTotalWeight.ToString();
        }

        private void OnTryAgainButtonClicked()
        {
            SceneManager.LoadScene(0);
        }

        private void OnDestroy()
        {
            tryAgainButton.onClick.RemoveListener(OnTryAgainButtonClicked);
            allItemsButton.onClick.RemoveListener(ShowAllItems);
            for (int i = 0; i < solutionButtons.Count; i++)
            {
                solutionButtons[i].onClick.RemoveAllListeners();
            }
        }
    }
}