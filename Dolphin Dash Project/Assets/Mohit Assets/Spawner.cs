using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject fuelPrefab;

    public Transform spawnPointA;
    public Transform spawnPointB;
    public Transform spawnPointC;
    public Transform spawnPointD;

    public int EnemyCount;

    private void Start()
    {
        StartCoroutine(SpawnEnemy());
        StartCoroutine(SpawnFuel());

    }
    IEnumerator SpawnEnemy()
    {
        for(int i =0; i<= EnemyCount; i++)
        {
            yield return new WaitForSeconds(3f);
            Instantiate(enemyPrefab, spawnPointA.position, Quaternion.identity);

            yield return new WaitForSeconds(2f);
            Instantiate(enemyPrefab, spawnPointB.position, Quaternion.identity);
        }
    }
    IEnumerator SpawnFuel()
    {
        for (int i = 0; i <= EnemyCount; i++)
        {
            yield return new WaitForSeconds(5f);
            Instantiate(fuelPrefab, spawnPointC.position, Quaternion.identity);

            yield return new WaitForSeconds(5f);
            Instantiate(fuelPrefab, spawnPointD.position, Quaternion.identity);
        }
    }

}

