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
    }
    private void makeTargetable()
    {
        isTargetable = true;
    }
}
