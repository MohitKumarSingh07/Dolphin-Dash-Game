using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indicator : MonoBehaviour
{
    [SerializeField] private GameObject IndicatorObj;

    private void Update()
    {
        IndicatorObj.transform.position = transform.position;

        Vector3 minScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        Vector3 maxScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        IndicatorObj.transform.position = new Vector3(Mathf.Clamp(IndicatorObj.transform.position.x, minScreenBounds.x + 1, maxScreenBounds.x - 1), 
            Mathf.Clamp(IndicatorObj.transform.position.y, minScreenBounds.y + 1, maxScreenBounds.y - 3), 
            Camera.main.nearClipPlane);

    }
}
