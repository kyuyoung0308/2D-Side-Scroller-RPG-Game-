using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FireDropSpawner : MonoBehaviour
{
    
    private float _generatedNumber;
    
    public GameObject fireDrop;

    private Rigidbody2D _rb;

    // Start is called before the first frame update
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        drop();
    }


    void drop()
    {
        _generatedNumber = Random.value;
        var position = _rb.position;
        var spawnLocation = new Vector2(position.x, position.y);
        Instantiate(fireDrop, spawnLocation, Quaternion.identity);

        
        Invoke(nameof(drop), _generatedNumber);
    }

}