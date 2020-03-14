using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{

    public GameObject enemy1;
    public float enemy1Health = 3;
    public bool isTargetable = true;

    private Rigidbody2D _rb;


    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        
        if (enemy1Health <= 0)
        {
            Destroy(enemy1);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }


    private void makeTargetable()
    {
        isTargetable = true;
    }

    //Player will be able to phase through enemies while untargetable
    private void phase()
    {
        isTargetable = false;
        Invoke("makeTargetable", 1);
    }


    private void OnCollisionEnter2D(Collision2D col)
    {

        if (isTargetable)
        {
            if (col.gameObject.tag.Equals("Sword") || col.gameObject.tag.Equals("FireBall"))
            {
                enemy1Health -= 1;
                phase();
            }

            if (col.gameObject.tag.Equals("Spear"))
            {
                enemy1Health -= 2;
                phase();
            }
            
        }
    }
}