using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.UIElements.GraphView;
using UnityEngine;

public class Slime : Enemies
{

    void Update()
    {

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