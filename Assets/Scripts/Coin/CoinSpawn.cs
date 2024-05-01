using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawn : MonoBehaviour
{
    public GameObject coinPrefab;

    void Start()
    {
        StartCoroutine(CoinSpawner());
    }

    void Coins()
    {
        if (GameManager.instance.gameStartPanel.activeSelf) return;
        float randomPos = Random.Range(-1.95f, 1.95f);
        GameObject newCoinSpawner = Instantiate(coinPrefab, new Vector3(randomPos, transform.position.y, transform.position.z), Quaternion.identity);
        newCoinSpawner.AddComponent<EnemyMovement>();
        newCoinSpawner.AddComponent<CircleCollider2D>();
        newCoinSpawner.transform.tag = "Coin";
    }

    IEnumerator CoinSpawner()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            Coins();
        }
    }
}
