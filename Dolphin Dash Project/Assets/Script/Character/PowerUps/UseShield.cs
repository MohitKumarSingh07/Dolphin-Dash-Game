using System.Collections;
using UnityEngine;

public class UseShield : MonoBehaviour
{
    [SerializeField] private GameObject Shield;
    public static bool isShielding;
    private SpriteRenderer rend;
    [SerializeField] private int NumberOfBlink;
    [SerializeField] private float m_iFramesDuration;

    private void Awake()
    {
        isShielding = false;
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && GameManager.manager.powerUp > 0 && !isShielding)
        {
            StartCoroutine(UsePower());

        }
    }

    private IEnumerator UsePower()
    {
        isShielding = true;
        Physics2D.IgnoreLayerCollision(6, 7, true);
        GameManager.manager.UsePowerUps();
        Shield.SetActive(true);
        rend = Shield.GetComponent<SpriteRenderer>();
        yield return new WaitForSeconds(7f);
        for (int i = 0; i < NumberOfBlink; i++)
        {
            rend.color = new Color(1, 1, 1, 0.2f);
            yield return new WaitForSeconds(m_iFramesDuration / (NumberOfBlink));
            rend.color = Color.white;
            yield return new WaitForSeconds(m_iFramesDuration / (NumberOfBlink));
        }
        Shield.SetActive(false);
        Physics2D.IgnoreLayerCollision(6, 7, false);
        isShielding = false;
    }
}
