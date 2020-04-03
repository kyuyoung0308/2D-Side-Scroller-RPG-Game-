using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.UIElements.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;
using playerClass;

public class Slime : Enemy1
{
   

    
    
    private void Update()
    {
        if (enemy1Health <= 0)
        {
            Destroy(enemy1);
            Player.TeleportToLevel2();
            
        }

        Vector2 slimeScale = transform.localScale;


        switch (direction)
        {
            //SLIME MOVES RIGHT IF DIRECTION IS RIGHT
            case 'R':
                transform.Translate(2 * Time.deltaTime * speed, 0, 0);
                slimeScale.x = 0.5f;
                break;
            //SLIME MOVES LEFT IF DIRECTION IS LEFT
            case 'L':
                transform.Translate(-2 * Time.deltaTime * speed, 0, 0);
                slimeScale.x = -0.5f;
                break;
        }

        transform.localScale = slimeScale;
    }
}