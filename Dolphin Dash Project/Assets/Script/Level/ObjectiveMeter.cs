using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ObjectiveMeter : MonoBehaviour
{
    [SerializeField] private GameObject RedFlag;
    [SerializeField] private Slider ObjectiveSlider;
    [SerializeField] private float TargetDistance; // can be set with Level's Objective distance
    private float currentPosition;
    [SerializeField] private TextMeshProUGUI CurrentDistanceText;
    [SerializeField] private TextMeshProUGUI TargetDistanceText;

    private void Start()
    {
        //RedFlag.SetActive(false);
        TargetDistanceText.text = TargetDistance.ToString();
    }

    private void Update()
    {
        //if(ObjectiveSlider.value == 1)
        //{
        //    RedFlag.SetActive(true);
        //}

        currentPosition = GameManager.manager.distance;

        CurrentDistanceText.text = ((int)currentPosition).ToString();

        ObjectiveSlider.value = currentPosition / TargetDistance;
    }

 
}
