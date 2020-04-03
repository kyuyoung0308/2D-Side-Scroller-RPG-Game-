using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : MonoBehaviour
{

    public GameObject expOrb;
    public GameObject enemy3;
    public float enemy3Health = 6;

    

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("FireBall"))
        {
            enemy3Health -= 1;
        }

        if (col.gameObject.tag.Equals("Sword"))
        {
            enemy3Health -= 1;
        }

        if (col.gameObject.tag.Equals("Spear"))
        {
            enemy3Health -= 2;
        }

    }
}
