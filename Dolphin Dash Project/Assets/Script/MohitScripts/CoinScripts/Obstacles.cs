using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public float speed;
    public int value;

    void Update()
    {
        transform.Translate(new Vector3(0,-1,0) * speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Destroy"))
        {
            Destroy(gameObject);
        }
    }
}
