using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class DolphinControl : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float speed;
    private Animator Anim;
    [SerializeField] private CapsuleCollider2D m_CapsuleCollider2D;
    [SerializeField] private LayerMask SeaLayer;
    private RaycastHit2D raycastHit;
    [SerializeField] private ParticleSystem particles;

    [Header("Gizmos Param")]
    [SerializeField] private float m_GizmosSphereRadius;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
        particles = GetComponent<ParticleSystem>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Sea"))
        {
            Debug.Log("In Water");

        }
    }

    private void Update()
    {
        if (InWaterCheck())
        {
            particles.Emit(1);
        }
        else
        {
            particles.Emit(0);
        }

        Anim.SetBool("DiveIn", SEA.DiveIn);
        Anim.SetBool("DiveOut", SEA.DiveOut);
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
    }

    public bool InWaterCheck()
    {
        raycastHit = Physics2D.CapsuleCast(m_CapsuleCollider2D.bounds.center, m_CapsuleCollider2D.size, CapsuleDirection2D.Horizontal, 0, Vector2.down, 0.2f, SeaLayer);
        return raycastHit.collider != null;
    }


    private void OnDrawGizmosSelected()
    {
        Color TransparentRed = new Color(1, 0, 0, .5f);
        Color TransparentGreen = new Color(0, 1, 0, .5f);

        if (InWaterCheck())
        {
            Gizmos.color = TransparentGreen;
        }
        else
        {
            Gizmos.color = TransparentRed;
        }

        Gizmos.DrawSphere(this.transform.position, m_GizmosSphereRadius);
    }
}
