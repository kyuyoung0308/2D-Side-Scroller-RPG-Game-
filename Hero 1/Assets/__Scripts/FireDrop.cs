using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDrop : Enemy1
{
    
    public float velY = -20f;
    private Rigidbody2D _rb;


    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 3.0f);
        
        
    }

    // Update is called once per frame
    private void Update()

    {
        if (enemy1Health <= 0)
        {
            Destroy(enemy1);
        }

        _rb.velocity = new Vector2(0, velY);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        Destroy(gameObject);
    }
}