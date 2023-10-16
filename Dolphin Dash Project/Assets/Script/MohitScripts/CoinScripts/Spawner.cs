using System.Collections;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Spawner : MonoBehaviour
{
    //public GameObject coinPrefab;
    //public GameObject powerUpPrefab;

    //public Transform spawnPointA;
    //public Transform spawnPointB;
    //public Transform spawnPointC;
    //public Transform spawnPointD;

    //public int spwanCount;

    private CollectiblesPoolA PoolA;
    private CollectiblesPoolB PoolB;
    private CollectiblesPoolC PoolC;
    private CollectiblesPoolD PoolD;
    private CollectiblesPoolE PoolE;

    private ShieldPowerPoolA ShieldPoolA;

    private void Awake()
    {
        PoolA = GetComponent<CollectiblesPoolA>();
        PoolB = GetComponent<CollectiblesPoolB>();
        PoolC = GetComponent<CollectiblesPoolC>();
        PoolD = GetComponent<CollectiblesPoolD>();
        PoolE = GetComponent<CollectiblesPoolE>();
        ShieldPoolA = GetComponent<ShieldPowerPoolA>();
    }

    private void Start()
    {
        //StartCoroutine(SpawnCoin());
        //StartCoroutine(SpawnPowerUp());
        Invoke(nameof(CoinSpawnA), 1f);
        Invoke(nameof(CoinSpawnB), 2.5f);
        Invoke(nameof(CoinSpawnC), 5f);
        Invoke(nameof(CoinSpawnD), 4f);
        Invoke(nameof(CoinSpawnE), 7f);
        Invoke(nameof(ShieldSpawnA), 3f);
    }


    private void CoinSpawnA()
    {
        int randTime = Random.Range(3, 8);
        PoolA.CoinPool.Get();
        Invoke(nameof(CoinSpawnA), randTime);
    }
    
    private void CoinSpawnB()
    {
        int randTime = Random.Range(2, 7);
        PoolB.CoinPool.Get();
        Invoke(nameof(CoinSpawnB), randTime);
    }
    
    private void CoinSpawnC()
    {
        int randTime = Random.Range(1, 9);
        PoolC.CoinPool.Get();
        Invoke(nameof(CoinSpawnC), randTime);
    }
    
    private void CoinSpawnD()
    {
        int randTime = Random.Range(3, 10);
        PoolD.CoinPool.Get();
        Invoke(nameof(CoinSpawnD), randTime);
    }
    
    private void CoinSpawnE()
    {
        int randTime = Random.Range(4, 9);
        PoolE.CoinPool.Get();
        Invoke(nameof(CoinSpawnE), randTime);
    }
    
    private void ShieldSpawnA()
    {
        int randTime = Random.Range(15, 25);
        ShieldPoolA.ShieldPool.Get();
        Invoke(nameof(ShieldSpawnA), randTime);
    }

    //IEnumerator SpawnCoin()
    //{
    //    for(int i =0; i<= spwanCount; i++)
    //    {
    //        yield return new WaitForSeconds(3f);
    //        CollectiblesPool.CoinPool.Get();

    //        //yield return new WaitForSeconds(2f);
    //        //Instantiate(coinPrefab, spawnPointB.position, Quaternion.identity);
    //    }


    //}
    //IEnumerator SpawnPowerUp()
    //{
    //    for (int i = 0; i <= spwanCount; i++)
    //    {
    //        yield return new WaitForSeconds(5f);
    //        Instantiate(powerUpPrefab, spawnPointC.position, Quaternion.identity);

    //        yield return new WaitForSeconds(5f);
    //        Instantiate(powerUpPrefab, spawnPointD.position, Quaternion.identity);
    //    }
    //}

}

