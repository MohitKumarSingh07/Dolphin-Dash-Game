using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Breathing : MonoBehaviour
{
    [SerializeField] [Range(0,10)] private float MaxOxygenCapacity;
    [SerializeField] private Slider OxygenMeter;
    [SerializeField] [Range(0, 10)] private float CurrentOxygenLevel;
    [SerializeField] private float DepletionRate;
    [SerializeField] private float ReplenishRate;

    private void Awake()
    {
        CurrentOxygenLevel = MaxOxygenCapacity;
    }

    private void Update()
    {
        OxygenControl();

        if(CurrentOxygenLevel <= 0)
        {
            CurrentOxygenLevel = 0;
        }

        OxygenMeter.value = CurrentOxygenLevel / 10;
    }

    private void OxygenControl()
    {
        if (DolphinControl.InWater && this.transform.position.y < -2f)
        {
            CurrentOxygenLevel -= Time.deltaTime * DepletionRate;
        }
        else
        {
            if(CurrentOxygenLevel < MaxOxygenCapacity)
            {
                CurrentOxygenLevel += Time.deltaTime * ReplenishRate;
            }
        }
    }
}
