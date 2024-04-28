using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject[] lstEnemy;

    void Start()
    {
        StartCoroutine(EnemySpawner());
    }

    void Cars()
    {
        int random = Random.Range(0, lstEnemy.Length);
        float randomPos = Random.Range(-1.95f, 1.95f);
        GameObject newEnemySpawner = Instantiate(lstEnemy[random], new Vector3(randomPos, transform.position.y, transform.position.z), Quaternion.Euler(0,0, 90));
        newEnemySpawner.AddComponent<EnemyMovement>();
        newEnemySpawner.AddComponent<BoxCollider2D>();
        newEnemySpawner.transform.localScale = new Vector3(0.4f, 0.4f, 1);
        newEnemySpawner.transform.tag = "Enemy";
    }

    IEnumerator EnemySpawner()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.5f);
            Cars();
        }
    }
}
