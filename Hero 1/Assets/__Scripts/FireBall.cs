using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public float velX = 20f;
    private Rigidbody2D _rb;


    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 3.0f);
    }

    // Update is called once per frame
    void Update()
    {
        _rb.velocity = new Vector2(velX, 0);
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        Destroy(gameObject);
    }
    
}