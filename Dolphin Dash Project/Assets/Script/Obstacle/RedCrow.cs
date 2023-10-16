using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedCrow : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Dolphin"))
        {
            if(DolphinControl.isDashing)
            {
                Destroy(this.gameObject);
            }
            else
            {
                DolphinHealth.instance.Damage();
            }
            
        }

        if (collision.gameObject.CompareTag("Destroyer"))
        {
            Destroy(this.gameObject);
        }
    }
}
