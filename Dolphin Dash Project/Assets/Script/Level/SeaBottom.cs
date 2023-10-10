using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaBottom : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Dolphin"))
        {
            Debug.Log("SEA BOTTOM!!!");
            DolphinControl.DiveIn = false;
            DolphinControl.DiveOut = false;
        }
    }
}
