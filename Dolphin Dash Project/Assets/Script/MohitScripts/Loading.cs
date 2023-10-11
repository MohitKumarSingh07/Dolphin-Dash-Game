using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class Loading : MonoBehaviour
{
    [SerializeField] private GameObject loobbyPanel;
    [SerializeField] private GameObject loadingPanel;

    [SerializeField] private Slider loadingSlider;
    [SerializeField] private TMP_Text sliderValue;

    private int temp;

    private void Awake()
    {
        loadingPanel.SetActive(true);
        loadingSlider.value = 0;
    }

    private void Update()
    {
        loadingSlider.value += 10f * Time.deltaTime;

        temp = (int)loadingSlider.value;

        sliderValue.text = "Loading... " + temp + "%";

        if(loadingSlider.value >= 100)
        {
            loobbyPanel.SetActive(true);
            loadingPanel.SetActive(false);
        }
    }
}