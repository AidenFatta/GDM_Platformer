using UnityEngine;
using System.Collections.Generic;

public class CoinPoolManager : MonoBehaviour
{
    public static CoinPoolManager Instance { get; private set; }

    public GameObject coinPrefab; 

    private ObjectPool coinPool;
    private List<Vector3> coinStartPositions;
    private List<GameObject> activeCoins;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        GameObject[] existingCoins = GameObject.FindGameObjectsWithTag("Coin");
        coinStartPositions = new List<Vector3>();

        foreach (GameObject coin in existingCoins)
        {
            coinStartPositions.Add(coin.transform.position);
            Destroy(coin);
        }

        coinPool = new ObjectPool(coinPrefab, coinStartPositions.Count);
        activeCoins = new List<GameObject>();

        SpawnAllCoins();
    }

    public void SpawnAllCoins()
    {
        foreach (Vector3 position in coinStartPositions)
        {
            GameObject coin = coinPool.Get();
            coin.transform.position = position;
            activeCoins.Add(coin);
        }
    }

    public void ReturnCoin(GameObject coin)
    {
        coinPool.Return(coin);
        activeCoins.Remove(coin);
    }

    public void ResetAllCoins()
    {

        foreach (GameObject coin in activeCoins)
        {
            if (coin != null) coinPool.Return(coin);
        }
        activeCoins.Clear();

        SpawnAllCoins();
    }
}
