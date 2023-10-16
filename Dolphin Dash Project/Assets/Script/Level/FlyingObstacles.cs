using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;

public class FlyingObstacles : MonoBehaviour
{
    [SerializeField] private GameObject ObstaclePrefab;
    [SerializeField] private GameObject WarningObj;
    [SerializeField] private Transform SpawnPoint;
    [SerializeField] private float speed;

    private void Start()
    {
        Invoke("begin", 2f);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            StartCoroutine(FlyingObstacle());
        }
    }

    private void begin()
    {
        float RepeatInterval = Random.Range(3, 8);
        StartCoroutine(FlyingObstacle());
        Invoke("begin", RepeatInterval + 6);
    }

    IEnumerator FlyingObstacle()
    {
        WarningObj.GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds(2f);
        GameObject prefab = Instantiate(ObstaclePrefab, SpawnPoint.position, Quaternion.identity);
        Rigidbody2D rb = prefab.GetComponentInChildren<Rigidbody2D>();
        rb.velocity = new Vector2(-speed, rb.velocity.y);
    }
}
