using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class CollectiblesPoolD : MonoBehaviour
{
    public ObjectPool<CoinCollect> CoinPool;
    [SerializeField] private CoinCollect Coins;

    public Transform spawnPointD;

    private void Start()
    {
        CoinPool = new ObjectPool<CoinCollect>(OnCreateCollectiblesPool, GetCoinFromPool, ReturnCoinToPool, OnCoinDestroy, true, 10, 20) ;
    }


    private CoinCollect OnCreateCollectiblesPool()
    {
        CoinCollect Coin = Instantiate(Coins, spawnPointD.position, Quaternion.identity);

        Coin.SetPool(CoinPool);

        return Coin;
    }

    private void GetCoinFromPool(CoinCollect Coin)
    {
        Coin.transform.position = spawnPointD.position;
        Coin.transform.localScale = Vector3.one;
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