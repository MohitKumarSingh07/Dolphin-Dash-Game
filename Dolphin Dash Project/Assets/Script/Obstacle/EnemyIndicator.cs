using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyIndicator : MonoBehaviour
{
    private Renderer rend;
    [SerializeField] private GameObject Indicator;

    private void Awake()
    {
        rend = GetComponent<Renderer>();
        Indicator = GameObject.FindGameObjectWithTag("Indicator");
    }


    private void Update()
    {
        if (this.gameObject.activeSelf)
        {
            if(rend.isVisible == true)
            {
                Indicator.GetComponent<SpriteRenderer>().enabled = false;
            }
        }
    }

}
