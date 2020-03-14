using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 4;

    public float playerHealth = 3;
    public bool isTargetable = true;
    public bool playerIsDead = false;


    public GameObject player; //Main player object
    public GameObject normalSprite; //Player without skill active

    public GameObject earthEffect; // Rock sprite while player is selected
    public GameObject fireEffect; //Player has fire around them while fire is selected
    public GameObject airEffect; //Player has air around them while air is selected
    public GameObject waterEffect; //Player has water around them while 


    //Fireball stuff
    public GameObject fireBallLeft;
    public GameObject fireBallRight;
    private Vector2 _fireBallPos;


    //Cool-downs of abilities
    public float cooldown = 1;
    public float nextAbility = 0.0f;
    public bool canUseAbility;

    //Direction variable - These variables will be used to know the players current direction
    private KeyCode _directionGetter;
    private char _direction;


    public bool air = false;
    public bool fire = false;
    public bool water = false;
    public bool earth = false;

    private float _jumpHeight;
    private bool _isJumping = false;

    private Rigidbody2D _rb;

    // Start is called before the first frame update
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        //Checking if player is dead
        if (playerHealth <= 0)
        {
            Destroy(player);
        }


        // --DIRECTION SETTER----------
        if (Input.GetKey(KeyCode.D))
        {
            _direction = 'R';
        }

        if (Input.GetKey(KeyCode.A))
        {
            _direction = 'L';
        }


        canUseAbility = Time.time > nextAbility;


        //ACTION BUTTON
        if (Input.GetKeyDown(KeyCode.E) && canUseAbility) // E Key will be used for action combat
        {
            if (fire)
            {
                if (_direction == 'R')
                {
                    fireRight();
                }

                if (_direction == 'L')
                {
                    fireLeft();
                }
            }

            nextAbility = Time.time + cooldown;
        }


        /*------------------------MOVEMENT-------------------------------*/
        if (Input.GetKeyDown(KeyCode.Space) && !_isJumping && !earth)
        {
            _rb.AddForce(Vector2.up * _jumpHeight, ForceMode2D.Impulse);
            _isJumping = true;
        }

        // ----------------Movement----------------------------
        if (!earth)
        {
            float movementHorizontal = Input.GetAxis("Horizontal");

            Vector2 movement = new Vector3(movementHorizontal, 0.01f);
            _rb.AddForce(movement * speed);
        }


        //------------------------ELEMENTS----------------------------

        if (Input.GetKeyDown(KeyCode.Alpha1)) //AIR 

        {
            earthEffect.SetActive(false);
            normalSprite.SetActive(true);
            airEffect.SetActive(true);
            fireEffect.SetActive(false);
            waterEffect.SetActive(false);

            air = true;
            fire = false;
            water = false;
            earth = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2)) //EARTH
        {
            earthEffect.SetActive(true);
            normalSprite.SetActive(true);
            fireEffect.SetActive(false);
            airEffect.SetActive(false);
            waterEffect.SetActive(false);

            air = false;
            fire = false;
            water = false;
            earth = true;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3)) //FIRE
        {
            fireEffect.SetActive(true);
            earthEffect.SetActive(false);
            normalSprite.SetActive(true);
            airEffect.SetActive(false);
            waterEffect.SetActive(false);

            air = false;
            fire = true;
            water = false;
            earth = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha4)) //WATER
        {
            earthEffect.SetActive(false);
            normalSprite.SetActive(true);
            fireEffect.SetActive(false);
            airEffect.SetActive(false);
            waterEffect.SetActive(true);


            air = false;
            fire = false;
            water = true;
            earth = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha5)) // Nothing
        {
            earthEffect.SetActive(false);
            normalSprite.SetActive(true);
            fireEffect.SetActive(false);
            airEffect.SetActive(false);
            waterEffect.SetActive(false);
        }


        //---- This if statement checks if air is selected. If it is the the player will be able to float more
        if (air)
        {
            _rb.gravityScale = 2f;
            _jumpHeight = 20f;
        }
        else
        {
            _rb.gravityScale = 6f;
            _jumpHeight = 20f;
        }
    }


    private void makeTargetable()
    {
        isTargetable = true;
        normalSprite.SetActive(true);
    }

    //Player will be able to phase through enemies while unTargetable
    private void phase()
    {
        isTargetable = false;
        normalSprite.SetActive(false);
        Invoke(nameof(makeTargetable), 2);
    }


    //Checks if the player is grounded
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Ground"))
        {
            _isJumping = false;
        }

        if (isTargetable)
        {
            if (col.gameObject.tag.Equals("Enemy1"))
            {
                playerHealth = playerHealth - 1;
                phase();
            }

            if (col.gameObject.tag.Equals("Enemy2"))
            {
                playerHealth = playerHealth - 2;
                phase();
            }

            if (col.gameObject.tag.Equals("Enemy3"))
            {
                playerHealth = playerHealth - 3;
                phase();
            }
        }
    }


    //Checks if player is grounded
    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Ground"))
        {
            _isJumping = true;
        }
    }

    private void fireRight()
    {
        Vector2 spawnLocation = new Vector2(_rb.position.x + 1.5f, _rb.position.y + 0.05f);
        Instantiate(fireBallRight, spawnLocation, Quaternion.identity);
    }

    private void fireLeft()
    {
        Vector2 spawnLocation = new Vector2(_rb.position.x - 1.5f, _rb.position.y + 0.05f);
        Instantiate(fireBallLeft, spawnLocation, Quaternion.identity);
    }
}