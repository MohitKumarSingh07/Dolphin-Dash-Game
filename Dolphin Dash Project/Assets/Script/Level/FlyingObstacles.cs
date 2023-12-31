using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FlyingObstacles : MonoBehaviour
{
    [SerializeField] private GameObject ObstaclePrefab;
    [SerializeField] private GameObject WarningImage;
    [SerializeField] private Transform SpawnPoint;
    [SerializeField] private float speed;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            StartCoroutine(FlyingObstacle());
        }
    }

    private void begin()
    {
        StartCoroutine(FlyingObstacle());
    }

    IEnumerator FlyingObstacle()
    {
        WarningImage.SetActive(true);
        yield return new WaitForSeconds(2f);
        WarningImage.SetActive(false);
        GameObject prefab = Instantiate(ObstaclePrefab, SpawnPoint.position, Quaternion.identity);
        Rigidbody2D rb = prefab.GetComponentInChildren<Rigidbody2D>();
        rb.velocity = new Vector2(-speed, rb.velocity.y);
        yield return new WaitForSeconds(5f);
        Destroy(prefab);
    }
}
