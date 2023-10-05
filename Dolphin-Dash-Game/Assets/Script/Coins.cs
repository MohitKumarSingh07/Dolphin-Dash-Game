using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    //[SerializeField] private RectTransform m_CoinPanelLocation;
    //[SerializeField] private float LerpTime;
    [SerializeField] private float m_speed;
    [SerializeField] private GameObject m_TargetObj;
    private Vector3 m_initPos;
    private Vector3 m_TargetPos;
    private bool MOve;


    private void OnEnable()
    {
        m_TargetObj = GameObject.FindGameObjectWithTag("Target");
        //m_initPos = Camera.main.ScreenToWorldPoint(new Vector3(this.transform.position.x, this.transform.position.y, Camera.main.transform.position.z * -1));
        MOve = false;
        GetComponent<CircleCollider2D>().enabled = true;
    }

    private void Update()
    {
        m_TargetPos = Camera.main.ScreenToWorldPoint(m_TargetObj.transform.position);

        //if (MOve)
        //    this.transform.position = Vector3.Lerp(transform.position, m_TargetPos, m_speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Dolphin"))
        {
            StartCoroutine(CoinCollect(this.gameObject.transform, this.transform.position, m_TargetPos));
            MOve = true;
            //Destroy(this.gameObject, 3f);
        }
    }


    private IEnumerator CoinCollect(Transform obj, Vector2 initPos, Vector2 TargetPos)
    {
        this.GetComponent<CircleCollider2D>().enabled = false;
        float time = 0;

        while(time < 1)
        {
            time += m_speed * Time.deltaTime;
            obj.position = Vector2.Lerp(initPos, TargetPos, time);

            yield return new WaitForEndOfFrame();
        }

        Destroy(this.gameObject);
        yield return null;
    }
}
