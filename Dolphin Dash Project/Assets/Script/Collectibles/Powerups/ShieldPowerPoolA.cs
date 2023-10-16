using UnityEngine;
using UnityEngine.Pool;

public class ShieldPowerPoolA : MonoBehaviour
{
    public ObjectPool<PowerUps> ShieldPool;
    [SerializeField] private PowerUps Shields;

    public Transform PowerupSpawnPointA;
    private Vector3 OriginalScale;

    private void Start()
    {
        ShieldPool = new ObjectPool<PowerUps>(OnCreateCollectiblesPool, GetObjFromPool, ReturnObjToPool, OnObjDestroy, true, 10, 20);
    }


    private PowerUps OnCreateCollectiblesPool()
    {
        PowerUps Shield = Instantiate(Shields, PowerupSpawnPointA.position, Quaternion.identity);
        OriginalScale = Shield.transform.localScale;
        Shield.SetPool(ShieldPool);

        return Shield;
    }

    private void GetObjFromPool(PowerUps Shield)
    {
        Shield.transform.position = PowerupSpawnPointA.position;
        Shield.transform.localScale = OriginalScale;
        Shield.GetComponent<CircleCollider2D>().enabled = true;

        Shield.gameObject.SetActive(true);
    }

    private void ReturnObjToPool(PowerUps Shield)
    {
        Shield.gameObject.SetActive(false);
    }

    private void OnObjDestroy(PowerUps Shield)
    {
        Destroy(Shield.gameObject);
    }
}
