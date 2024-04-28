using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    private float horizontalInput;
    private float verticalInput;
    private Vector2 velocity = new Vector2(0, 0);
    private float speedUp = 0.5f;
    private float speedDown = 0.5f;
    private float speedMax = 20f;
    
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        if (verticalInput > 0)
        {
            velocity.y += speedUp;
            velocity.x = horizontalInput;
        }
        else 
        { 
            velocity.y -= speedDown;
            velocity.x = horizontalInput;
            if (velocity.y < 0)
            {
                velocity.y = 0;
                velocity.x = 0;
            }
        }

        if (velocity.y > speedMax) velocity.y = speedMax;
         
        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);

        Vector3 playerPosLimit = transform.position;
        playerPosLimit.x = Mathf.Clamp(playerPosLimit.x, -3.3f, 3.3f);
        transform.position = playerPosLimit;
    }
}
