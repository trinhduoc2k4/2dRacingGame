using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    GameObject roadPrefab, roadSpawnPos, roadCurrent;
    public float distance;
    void Start()
    {
        roadPrefab = GameObject.Find("RoadPrefab");
        roadSpawnPos = GameObject.Find("RoadSpawnPos");

        roadCurrent = roadPrefab;
    }

    private void FixedUpdate()
    {
        UpdateRoad();
    }

    private void UpdateRoad()
    {
        distance = Vector2.Distance(PlayerController.instance.transform.position, roadCurrent.transform.position);

        if (distance > 18) Spawner();
    }

    private void Spawner()
    {
        Vector3 roadPos = roadSpawnPos.transform.position;
        roadPos.x = 0;

        roadCurrent = Instantiate(roadPrefab, roadPos, roadPrefab.transform.rotation);
    }
}
