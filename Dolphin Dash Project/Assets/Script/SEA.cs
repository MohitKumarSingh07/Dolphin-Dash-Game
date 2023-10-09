using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class SEA : MonoBehaviour
{
    private BuoyancyEffector2D sea;
    //[SerializeField] private bool InWater;
    [SerializeField] private Animator CharAnim;


    private void Start()
    {
        sea = GetComponent<BuoyancyEffector2D>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            sea.density = 0;
            sea.linearDrag = 2;
            if (DolphinControl.InWater)
            {
                DolphinControl.DiveIn = true;
                DolphinControl.DiveOut = false;
            }

            //DolphinControl.DiveTrigger = true;

        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            sea.density = 3;
            DolphinControl.DiveIn = false;
            DolphinControl.DiveOut = true;

            //DolphinControl.DiveTrigger = false;
        }

    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Dolphin"))
    //    {
    //        InWater = true;

    //    }
    //}

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Dolphin"))
        {
            //DiveOut = false;
            //DiveIn = false;
            //InWater = false;
            this.GetComponentInChildren<BuoyancyEffector2D>().linearDrag = 25;
            //this.GetComponentInChildren<BuoyancyEffector2D>().density = 5;
        }
    }
}
