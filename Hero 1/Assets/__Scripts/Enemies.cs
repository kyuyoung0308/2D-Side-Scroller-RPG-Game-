using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public GameObject enemy1;
    public float enemy1Health = 1;
    public bool isTargetable = true;

    public float speed = 2;
    public char direction = 'R';


    private Rigidbody2D _rb;

    // Start is called before the first frame update
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    

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