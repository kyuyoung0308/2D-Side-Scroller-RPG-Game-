using UnityEngine;

public class CharacterMoveAndJump : MonoBehaviour
{
    [SerializeField]
    private float speed = 4;

    public GameObject normalSprite; //Player without skill active
    public GameObject earthSprite; // Player while earth is selected
    public GameObject fireEffect; //Player has fire around them while selected

    public bool air = false;
    public bool fire = false;
    public bool water = false;
    public bool earth = false;

    public float jumpHeight;
    private bool _isJumping = false;

    private    Rigidbody2D  rb;

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
            rb.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
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

            earthSprite.SetActive(false);
            normalSprite.SetActive(true);

            fireEffect.SetActive(false);

            air = true;
            fire = false;
            water = false;
            earth = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2)) //EARTH
        {
            earthSprite.SetActive(true);
            normalSprite.SetActive(true);

            fireEffect.SetActive(false);

            air = false;
            fire = false;
            water = false;
            earth = true;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))  //FIRE
        {

            fireEffect.SetActive(true);
            earthSprite.SetActive(false);
            normalSprite.SetActive(true);

            air = false;
            fire = true;
            water = false;
            earth = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha4)) //WATER
        {
            earthSprite.SetActive(false);
            normalSprite.SetActive(true);
            fireEffect.SetActive(false);

            air = false;
            fire = false;
            water = true;
            earth = false;
        }

        if (air)
        {
            rb.gravityScale = 1f;
            jumpHeight = 4f;

        }
        else
        {
            rb.gravityScale = 4f;
            jumpHeight = 20f;

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