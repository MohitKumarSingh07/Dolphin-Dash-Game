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
    private Animator anim;
    [SerializeField] private CapsuleCollider2D m_CapsuleCollider2D;
    [SerializeField] private LayerMask SeaLayer;
    private RaycastHit2D raycastHit;
    [SerializeField] private ParticleSystem particles;
    public static bool InWater;
    public static bool DiveIn;
    public static bool DiveOut;
    public static bool AtBottom;

    [Header("Dash Settings")]
    [SerializeField] private bool canDash;
    [SerializeField] private float DashMultiplier;
    [SerializeField] private float DashTime;
    [SerializeField] private TrailRenderer TrailRend;
    [SerializeField] private float DashCoolDownTime;


    [Header("Gizmos Param")]
    [SerializeField] private float m_GizmosSphereRadius;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        particles = GetComponent<ParticleSystem>();
        TrailRend = GetComponent<TrailRenderer>();
        DiveIn = false;
        DiveOut = false;
        AtBottom = false;
        canDash = true;
        DashMultiplier = 2f;
        DashTime = .3f;
        DashCoolDownTime = 1f;
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
            InWater = true;
        }
        else
        {
            InWater = false;
        }

        if (InWater)
        {
            particles.Emit(1);
        }
        else
        {
            particles.Emit(0);
            DiveIn = false;
            DiveOut = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && canDash)
        {
            StartCoroutine(Dash());
        }

        //if(InWaterCheck() && rb.velocity.y == 0)
        //{
        //    SEA.DiveOut = false;
        //    SEA.DiveIn = false;
        //}

        anim.SetBool("DiveIn", DiveIn);
        anim.SetBool("DiveOut", DiveOut);

    }

    private void FixedUpdate()
    {

        rb.velocity = new Vector2(speed, rb.velocity.y);


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

        if (InWater)
        {
            Gizmos.color = TransparentGreen;
        }
        else
        {
            Gizmos.color = TransparentRed;
        }

        Gizmos.DrawSphere(this.transform.position, m_GizmosSphereRadius);
    }

    IEnumerator Dash()
    {
        canDash = false;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0;
        float originalspeed = speed;
        TrailRend.emitting = true;
        speed *= DashMultiplier;
        yield return new WaitForSeconds(DashTime);
        TrailRend.emitting = false;
        rb.gravityScale = originalGravity;
        speed = originalspeed;
        yield return new WaitForSeconds(DashCoolDownTime);
        canDash = true;
    }
}
