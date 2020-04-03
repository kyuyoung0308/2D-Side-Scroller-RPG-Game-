using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthBoss : Enemy3
{
    public GameObject fallingRock;
    private Rigidbody2D _rb;


    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        rockDrop();
    }

    private void Update()
    {
        if (enemy3Health <= 0)
        {
            Destroy(enemy3);
            Instantiate(expOrb, getBossPos(), Quaternion.identity);
        }
    }

    private void rockDrop()
    {
        var spawnLocation = new Vector2(getBossPos().x - 10, getBossPos().y + 10f);
        Instantiate(fallingRock, spawnLocation, Quaternion.identity);

        Invoke(nameof(rockDrop), 3);
    }


    private Vector2 getBossPos()
    {
        return _rb.position;
    }
}