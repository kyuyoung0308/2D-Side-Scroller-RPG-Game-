using UnityEngine;
using UnityEngine.Serialization;

public class CharacterMoveAndJump : MonoBehaviour
{
    [SerializeField] private float speed = 4;

    public GameObject normalSprite; //Player without skill active
    public GameObject earthEffect; // Rock sprite while player is selected
    public GameObject fireEffect; //Player has fire around them while fire is selected
    public GameObject airEffect; //Player has air around them while air is selected
    public GameObject waterEffect; //Player has water around them while 

    public bool air = false;
    public bool fire = false;
    public bool water = false;
    public bool earth = false;

    private float _jumpHeight;
    private bool _isJumping = false;
    public float height = 0.05f;
    public float heightPadding = 0.05f;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !_isJumping && !earth)
        {
            rb.AddForce(Vector2.up * _jumpHeight, ForceMode2D.Impulse);
            _isJumping = true;
        }

        if (!earth)
        {
            float movementHorizontal = Input.GetAxis("Horizontal");

            Vector2 movement = new Vector3(movementHorizontal, 0.01f);
            rb.AddForce(movement * speed);
        }

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

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            
            earthEffect.SetActive(false);
            normalSprite.SetActive(true);
            fireEffect.SetActive(false);
            airEffect.SetActive(false);
            waterEffect.SetActive(false);
            
        }

        if (air)
        {
            rb.gravityScale = 2f;
            _jumpHeight = 20f;
        }
        else
        {
            rb.gravityScale = 6f;
            _jumpHeight = 20f;
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            _isJumping = false;
        }
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            _isJumping = true;
        }
    }
}