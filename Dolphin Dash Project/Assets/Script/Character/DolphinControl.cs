using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DolphinControl : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] private TextMeshProUGUI CoinDisplay;
    private Animator anim;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Sea"))
        {
            Debug.Log("In Water");
             
        }
    }



    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
    }

    private void InWaterCheck()
    {

    }


    private void OnDrawGizmosSelected()
    {
        
    }
}
