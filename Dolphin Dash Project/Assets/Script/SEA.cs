using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class SEA : MonoBehaviour
{
    private BuoyancyEffector2D sea;
    [SerializeField] private bool InWater;
    [SerializeField] private Animator CharAnim;
    public static bool DiveIn;
    public static bool DiveOut;
    [SerializeField] private CinemachineVirtualCamera Vcam;
    [SerializeField] private DolphinControl dolphin;

    private void Start()
    {
        sea = GetComponent<BuoyancyEffector2D>();
        DiveIn = false;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            sea.density = 0;
            sea.linearDrag = 2;
            if (InWater)
            {
                DiveIn = true;
                DiveOut = false;
            }

            Vcam.m_Lens.OrthographicSize = Mathf.Lerp(5f, 4.5f,Time.deltaTime);

        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            sea.density = 5;
            DiveIn = false;
            DiveOut = true;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Dolphin"))
        {
            InWater = true;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Dolphin"))
        {
            DiveOut = false;
            DiveIn = false;
            InWater = false;
            this.GetComponentInChildren<BuoyancyEffector2D>().linearDrag = 25;
            //this.GetComponentInChildren<BuoyancyEffector2D>().density = 5;
        }
    }
}
