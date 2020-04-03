using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirBoss : Enemy3
{
    public GameObject whirlWindLeft;
    public GameObject whirlWindRight;


    private Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        whirlWind();
    }

    private void Update()
    {
        if (enemy3Health <= 0)
        {
            Destroy(enemy3);
            Instantiate(expOrb, getBossPos(), Quaternion.identity);
        }
    }

    private void whirlWind()
    {
        var spawnLocation1 = new Vector2(getBossPos().x, getBossPos().y);
        var spawnLocation2 = new Vector2(getBossPos().x, getBossPos().y);
        Instantiate(whirlWindRight, spawnLocation1, Quaternion.identity);
        Instantiate(whirlWindLeft, spawnLocation2, Quaternion.identity);

        Invoke(nameof(whirlWind), 5);
    }

    private Vector2 getBossPos()
    {
        return _rb.position;
    }
}