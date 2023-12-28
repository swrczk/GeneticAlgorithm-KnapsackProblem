using AI;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class SettingsView : MonoBehaviour
    {
        [SerializeField]
        private TMP_InputField populationSizeInputField;

        [SerializeField]
        private TMP_InputField numberOfItemsInputField;

        [SerializeField]
        private TMP_InputField numberOfGenerationsInputField;

        [SerializeField]
        private TMP_InputField mutationRateInputField;

        [SerializeField]
        private TMP_InputField weightLimitInputField;

        [SerializeField]
        private TMP_InputField priceLimitMinInputField;

        [SerializeField]
        private TMP_InputField priceLimitMaxInputField;

        [SerializeField]
        private TMP_InputField weightLimitMinInputField;

        [SerializeField]
        private TMP_InputField weightLimitMaxInputField;

        [SerializeField]
        private TMP_InputField weightPenaltyInputField;

        [SerializeField]
        private Button button;

        private void Start()
        {
            button.onClick.AddListener(OnButtonClicked);
            populationSizeInputField.text = AlgorithmSettings.PopulationSize.ToString();
            numberOfItemsInputField.text = AlgorithmSettings.NumberOfItems.ToString();
            numberOfGenerationsInputField.text = AlgorithmSettings.NumberOfGenerations.ToString();
            mutationRateInputField.text = AlgorithmSettings.MutationRate.ToString();
            weightLimitInputField.text = AlgorithmSettings.WeightLimit.ToString();
            priceLimitMinInputField.text = AlgorithmSettings.MinPrice.ToString();
            priceLimitMaxInputField.text = AlgorithmSettings.MaxPrice.ToString();
            weightLimitMinInputField.text = AlgorithmSettings.MinWeight.ToString();
            weightLimitMaxInputField.text = AlgorithmSettings.MaxWeight.ToString();
            weightPenaltyInputField.text = AlgorithmSettings.WeightPenalty.ToString();
        }

        private void OnButtonClicked()
        {
            AlgorithmSettings.PopulationSize = int.Parse(populationSizeInputField.text);
            AlgorithmSettings.NumberOfItems = int.Parse(numberOfItemsInputField.text);
            AlgorithmSettings.NumberOfGenerations = int.Parse(numberOfGenerationsInputField.text);
            AlgorithmSettings.MutationRate = float.Parse(mutationRateInputField.text);
            AlgorithmSettings.WeightLimit = float.Parse(weightLimitInputField.text);
            AlgorithmSettings.MinPrice = float.Parse(priceLimitMinInputField.text);
            AlgorithmSettings.MaxPrice = float.Parse(priceLimitMaxInputField.text);
            AlgorithmSettings.MinWeight = float.Parse(weightLimitMinInputField.text);
            AlgorithmSettings.MaxWeight = float.Parse(weightLimitMaxInputField.text);
            AlgorithmSettings.WeightPenalty = float.Parse(weightPenaltyInputField.text);

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        private void OnDestroy()
        {
            button.onClick.RemoveListener(OnButtonClicked);
        }
    }
}