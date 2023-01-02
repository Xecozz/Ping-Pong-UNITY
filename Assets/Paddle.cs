using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public bool isJ1;
    public float speed = 5f;
    public Rigidbody2D rb;
    public Vector3 startPosition;

    private float movement;

    private void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isJ1)
        {
            movement = Input.GetAxisRaw("Vertical");

        }
        else
        {
            movement = Input.GetAxisRaw("Vertical2");
        }
        
        rb.velocity = new Vector2(0, movement * speed);
        
    }
    
    
    public void Reset()
    {
        rb.velocity = Vector2.zero;
        transform.position = startPosition;
    }
}
