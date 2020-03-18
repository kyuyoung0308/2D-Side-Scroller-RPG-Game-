using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.UIElements.GraphView;
using UnityEngine;

public class Slime : MonoBehaviour
{
    public GameObject enemy1;
    public float enemy1Health = 1;
    public bool isTargetable = true;

    public float speed = 2;
    public char direction = 'R';


    private Rigidbody2D _rb;


    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy1Health <= 0)
        {
            Destroy(enemy1);
        }

        Vector2 slimeScale = transform.localScale;


        //SLIME MOVES RIGHT IF DIRECTION IS RIGHT
        if (direction == 'R')
        {
            transform.Translate(2 * Time.deltaTime * speed, 0, 0);
            slimeScale.x = 1;
        }

        //SLIME MOVES LEFT IF DIRECTION IS LEFT
        if (direction == 'L')
        {
            transform.Translate(-2 * Time.deltaTime * speed, 0, 0);
            slimeScale.x = -1;
        }

        transform.localScale = slimeScale;
    }


    private void makeTargetable()
    {
        isTargetable = true;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("FireBall"))
        {
            enemy1Health -= 1;
        }

        if (col.gameObject.tag.Equals("Sword"))
        {
            enemy1Health -= 1;
        }

        if (col.gameObject.tag.Equals("Spear"))
        {
            enemy1Health -= 2;
        }

        if (col.gameObject.tag.Equals("TurnRight"))
        {
            direction = 'R';
        }

        if (col.gameObject.tag.Equals("TurnLeft"))
        {
            direction = 'L';
        }
    }
}