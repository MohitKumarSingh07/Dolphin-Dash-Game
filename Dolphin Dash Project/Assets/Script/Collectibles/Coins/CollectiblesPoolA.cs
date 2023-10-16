using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class CollectiblesPoolA : MonoBehaviour
{
    public ObjectPool<CoinCollect> CoinPool;
    [SerializeField] private CoinCollect Coins;

    public Transform spawnPointA;
    private Vector3 OriginalScale;


    private void Start()
    {
        CoinPool = new ObjectPool<CoinCollect>(OnCreateCollectiblesPool, GetCoinFromPool, ReturnCoinToPool, OnCoinDestroy, true, 10, 20) ;
    }


    private CoinCollect OnCreateCollectiblesPool()
    {
        CoinCollect Coin = Instantiate(Coins, spawnPointA.position, Quaternion.identity);
        OriginalScale = Coin.transform.localScale;
        Coin.SetPool(CoinPool);

        return Coin;
    }

    private void GetCoinFromPool(CoinCollect Coin)
    {
        Coin.transform.position = spawnPointA.position;
        Coin.transform.localScale = OriginalScale;
        Coin.GetComponent<CircleCollider2D>().enabled = true;

        Coin.gameObject.SetActive(true);
    }

    private void ReturnCoinToPool(CoinCollect Coin)
    {
        Coin.gameObject.SetActive(false);
    }

    private void OnCoinDestroy(CoinCollect Coin)
    {
        Destroy(Coin.gameObject);
    }

}
