using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject coinPrefab;
    public GameObject powerUpPrefab;

    public Transform spawnPointA;
    public Transform spawnPointB;
    public Transform spawnPointC;
    public Transform spawnPointD;

    public int spwanCount;

    private void Start()
    {
        StartCoroutine(SpawnCoin());
        StartCoroutine(SpawnPowerUp());

    }
    IEnumerator SpawnCoin()
    {
        for(int i =0; i<= spwanCount; i++)
        {
            yield return new WaitForSeconds(3f);
            Instantiate(coinPrefab, spawnPointA.position, Quaternion.identity);

            yield return new WaitForSeconds(2f);
            Instantiate(coinPrefab, spawnPointB.position, Quaternion.identity);
        }
    }
    IEnumerator SpawnPowerUp()
    {
        for (int i = 0; i <= spwanCount; i++)
        {
            yield return new WaitForSeconds(5f);
            Instantiate(powerUpPrefab, spawnPointC.position, Quaternion.identity);

            yield return new WaitForSeconds(5f);
            Instantiate(powerUpPrefab, spawnPointD.position, Quaternion.identity);
        }
    }

}

