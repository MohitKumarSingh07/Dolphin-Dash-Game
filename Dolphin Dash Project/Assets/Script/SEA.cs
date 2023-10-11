using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using UnityEngine.Rendering;

public class SEA : MonoBehaviour
{
    private BuoyancyEffector2D sea;

    private void Awake()
    {
        Time.timeScale = 1;
    }

    private void Start()
    {
        sea = GetComponent<BuoyancyEffector2D>();
    }


    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            sea.density = 0f;
            sea.linearDrag = 1.5f;
            if (DolphinControl.InWater)
            {
                DolphinControl.DiveIn = true;
                DolphinControl.DiveOut = false;
            }

        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            sea.density = 3f;
            DolphinControl.DiveIn = false;
            DolphinControl.DiveOut = true;
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Dolphin"))
        {
            //DolphinControl.InWater = false;
            this.GetComponentInChildren<BuoyancyEffector2D>().linearDrag = 25;
        }
    }
}
