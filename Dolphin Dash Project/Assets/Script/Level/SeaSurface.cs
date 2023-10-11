using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaSurface : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Dolphin"))
        {
            Debug.Log("On Surface");
            Animator CharAnim = collision.gameObject.GetComponent<Animator>();
            CharAnim.SetBool("OnSurface", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Dolphin"))
        {
            Debug.Log("Off Surface");
            Animator CharAnim = collision.gameObject.GetComponent<Animator>();
            CharAnim.SetBool("OnSurface", false);
        }
    }
}
