using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class SEA : MonoBehaviour
{
    private BuoyancyEffector2D sea;
    [SerializeField] private ParticleSystem particles;
    [SerializeField] private bool InWater;

    private void Start()
    {
        sea = GetComponentInChildren<BuoyancyEffector2D>();
        particles = GameObject.FindGameObjectWithTag("Dolphin").GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            sea.density = 0;
            sea.linearDrag = 2;
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            sea.density = 5;
        }

        if (InWater)
        {
            particles.Emit(1);
        }
        else
        {
            particles.Emit(0);
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
            InWater = false;
            this.GetComponentInChildren<BuoyancyEffector2D>().linearDrag = 25;
            //this.GetComponentInChildren<BuoyancyEffector2D>().density = 5;
            Debug.Log("In water");
        }
    }
}
