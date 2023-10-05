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


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Sea"))
            Debug.Log("In Water");
        
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

}
