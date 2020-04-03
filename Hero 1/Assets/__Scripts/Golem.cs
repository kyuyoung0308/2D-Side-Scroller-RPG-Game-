using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golem : Enemy1
{
    private Rigidbody2D _rb;

    
    
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (enemy1Health <= 0)
        {
            Destroy(enemy1);
            Instantiate(expOrb, getEnemyPos(), Quaternion.identity);
        }

        Vector2 scale = transform.localScale;


        switch (direction)
        {
            //SLIME MOVES RIGHT IF DIRECTION IS RIGHT
            case 'R':
                transform.Translate(2 * Time.deltaTime * speed, 0, 0);
                scale.x = 2;
                break;
            //SLIME MOVES LEFT IF DIRECTION IS LEFT
            case 'L':
                transform.Translate(-2 * Time.deltaTime * speed, 0, 0);
                scale.x = -2;
                break;
        }

        transform.localScale = scale;
    }

    private Vector2 getEnemyPos()
    {
        return _rb.position;
    }
}