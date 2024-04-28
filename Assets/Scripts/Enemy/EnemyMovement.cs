using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyMovement : MonoBehaviour
{
    private float speed = 4f;

    private void Update()
    {
        if (transform.position.y < -6) Destroy(gameObject);
    }
    private void FixedUpdate()
    {
        transform.position -= new Vector3(0, speed * Time.fixedDeltaTime, 0);
    }
}
