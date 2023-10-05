using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    private float speedAfterCollect = 5f;
    private bool isCollected;
    private Transform storeLocation;
    [SerializeField] private Vector3 offset;

    private void Start()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Dolphin"))
        {
            gameObject.GetComponent<Collider2D>().enabled = false;
            isCollected = true;
            Destroy(gameObject, 0.7f);
        }
    }
    private void Update()
    {
        storeLocation = GameObject.FindGameObjectWithTag("Dolphin").transform;

        if (isCollected)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, storeLocation.transform.localPosition+offset, speedAfterCollect * Time.deltaTime);
            transform.localScale=Vector3.Lerp(transform.localScale,new Vector3(0.2f,0.2f,0),speedAfterCollect * Time.deltaTime);
        }
    }
}
