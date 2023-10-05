using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class SEA : MonoBehaviour
{
    private BuoyancyEffector2D sea;
    [SerializeField] private ParticleSystem particles;
    [SerializeField] private bool InWater;
    [SerializeField] private Animator CharAnim;
    private bool DiveIn;
    private bool DiveOut;
    [SerializeField] private CinemachineVirtualCamera Vcam;

    private void Start()
    {
        sea = GetComponentInChildren<BuoyancyEffector2D>();
        particles = GameObject.FindGameObjectWithTag("Dolphin").GetComponent<ParticleSystem>();
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

        if (InWater)
        {
            particles.Emit(1);
        }
        else
        {
            particles.Emit(0);
        }
        CharAnim.SetBool("DiveIn", DiveIn);
        CharAnim.SetBool("DiveOut", DiveOut);

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
            Debug.Log("In water");
        }
    }
}
