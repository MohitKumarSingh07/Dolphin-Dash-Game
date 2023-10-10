using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using UnityEngine.Rendering;

public class SEA : MonoBehaviour
{
    private BuoyancyEffector2D sea;
    //[SerializeField] private bool InWater;
    [SerializeField] private Animator CharAnim;
    private GameObject dolphin;

    private void Awake()
    {
        Time.timeScale = 1;
        dolphin = CharAnim.gameObject;
    }

    private void Start()
    {
        sea = GetComponent<BuoyancyEffector2D>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            sea.density = 0;
            sea.linearDrag = 1.5f;
            if (DolphinControl.InWater)
            {
                DolphinControl.DiveIn = true;
                DolphinControl.DiveOut = false;
            }

        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            sea.density = 3;
            DolphinControl.DiveIn = false;
            DolphinControl.DiveOut = true;
            //if (!DolphinControl.InWater)
            //{
            //    DolphinControl.DiveIn = false;
            //    DolphinControl.DiveOut = false;
            //}

        }
        //else
        //{
        //    DolphinControl.DiveOut = false;
        //    DolphinControl.DiveIn = false;
        //}

    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Dolphin"))
        {
            this.GetComponentInChildren<BuoyancyEffector2D>().linearDrag = 25;
        }
    }
}
