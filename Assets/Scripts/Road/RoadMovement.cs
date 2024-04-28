using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private Renderer meshRenderer;
    private float speedUp = 0.1f;
    private float speedDown = 0.1f;
    private float speedMax = 1f;
    private float speed;
    void Start()
    {
        meshRenderer = GetComponent<Renderer>();    
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //if (PlayerController.instance.verticalInput > 0)
        //{
        //    speed += speedUp;
        //} else
        //{
        //    speed -= speedDown;
        //    if (speed < 0) speed = 0;
        //}

        if(speed > speedMax) speed = speedMax;
        meshRenderer.material.mainTextureOffset += new Vector2(0, speedMax * Time.fixedDeltaTime);   
    }
}
