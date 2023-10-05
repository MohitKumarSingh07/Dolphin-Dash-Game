using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class CharacterHealth : MonoBehaviour
{
    public static CharacterHealth instance { get; private set; }
    private int MaxHealth = 3;
    public int currHealth;
    private Vector2 OPos;
    [SerializeField] private TextMeshProUGUI CurrHealthDisplay;
    private SpriteRenderer rend;
    [SerializeField] private int NumberOfBlink;
    [SerializeField] private float m_iFramesDuration;
    [SerializeField] private GameObject GameOverPanel;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(instance);
        }
        else
        {
            instance = this;
        }

        Time.timeScale = 1;
        currHealth = MaxHealth;
        OPos = this.gameObject.transform.position;
        rend = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (currHealth <= 0)
        {
            GameOverPanel.SetActive(true);
            Time.timeScale = 0;
            //this.gameObject.transform.position = OPos;
            //currHealth = MaxHealth;
        }

        CurrHealthDisplay.text = "X " + currHealth.ToString();
    }

    public void Damage()
    {
        if (currHealth > 0)
        {
            StartCoroutine(Iframes());
            currHealth--;
        }
    }

    private IEnumerator Iframes()
    {
        Physics2D.IgnoreLayerCollision(6, 7, true);
        for (int i = 0; i < NumberOfBlink; i++)
        {
            rend.color = new Color(1, 1, 1, 0.5f);
            yield return new WaitForSeconds(m_iFramesDuration / (NumberOfBlink));
            rend.color = Color.white;
            yield return new WaitForSeconds(m_iFramesDuration / (NumberOfBlink));
        }
        Physics2D.IgnoreLayerCollision(6, 7, false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Health"))
        {
            Destroy(collision.gameObject);
            currHealth++;
        }
    }
}

