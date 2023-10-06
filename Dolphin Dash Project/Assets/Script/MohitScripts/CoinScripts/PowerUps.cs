using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    private float speedAfterCollect = 5f;
    private bool isCollected = false;
    private Transform storeLocation;
    [SerializeField] private Vector3 offset;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Dolphin"))
        {
            gameObject.GetComponent<Collider2D>().enabled = false;
            isCollected = true;
            GameManager.manager.AddPowerUps(1);
            Destroy(gameObject, 0.7f);
        }
    }
    private void Update()
    {
        if (!isCollected)
        {
            transform.Translate(new Vector3(-1, 0, 0) * 2 * Time.deltaTime);
        }

        storeLocation = GameObject.FindGameObjectWithTag("Dolphin").transform;

        if (isCollected)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, storeLocation.transform.localPosition + offset, speedAfterCollect * Time.deltaTime);
            transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(0.2f, 0.2f, 0), speedAfterCollect * Time.deltaTime);
        }
    }
}
