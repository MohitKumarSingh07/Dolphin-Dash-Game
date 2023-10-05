using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DolphinControl : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float speed;
    private int CoinCount = 0;
    [SerializeField] private TextMeshProUGUI CoinDisplay;
    private bool Highestpnt;
    private Animator anim;
    private bool m_isInWater;

    [Header("InWater Check Variables")]
    [SerializeField] private float GizmosRadius;
    [SerializeField] private float BoxCastSize;



    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Highestpnt = false;
        anim = GetComponent<Animator>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Sea"))
        {
            Debug.Log("In Water");
             
        }
            
        
        if (collision.gameObject.CompareTag("Collectible"))
        {
            //Destroy(collision.gameObject);
            CoinCount++;
        }
    }

    private void Update()
    {
        CoinDisplay.text = CoinCount.ToString();

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
        Vector3 SpherePosition = this.transform.position;

    }


    private void OnDrawGizmosSelected()
    {
        Color TransparentRed = new Color(1, 0, 0, .5f);
        Color TransparentGreen = new Color(0, 1, 0, .5f);

        if (m_isInWater)
        {
            Gizmos.color = TransparentGreen;
        }
        else
        {
            Gizmos.color = TransparentRed;
        }

        Gizmos.DrawSphere(this.transform.position, GizmosRadius);
    }
}
