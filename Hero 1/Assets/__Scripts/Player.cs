namespace playerClass
{
    using System;
    using UnityEngine;
    using UnityEngine.SceneManagement;
    using UnityEngine.Serialization;


    public class Player : MonoBehaviour
    {
        //player pos
        private static Vector2 _pos;

        //Player Movement Speed
        [SerializeField] private float speed = 4;

        //-----------Basic PLayer Stats
        public float playerHealth = 3;
        private int exp = 1;
        private int level = 1;

        //Boolean to check if player can be hit
        public bool isTargetable = true;


        //PLAYER HAS/DOES NOT HAVE ELEMENTS
        public bool hasAir = false;
        public bool hasEarth = false;
        public bool hasFire = false;
        public bool hasWater = false;

        //PLAYER HEALTH SPRITES ICONS
        public GameObject health11;
        public GameObject health10;
        public GameObject health9;
        public GameObject health8;
        public GameObject health7;
        public GameObject health6;
        public GameObject health5;
        public GameObject health4;
        public GameObject health3;
        public GameObject health2;
        public GameObject health1;
        public GameObject dead;

        //PLAYER LEVEL ICONS
        public GameObject lvl1;
        public GameObject lvl2;
        public GameObject lvl3;
        public GameObject lvl4;
        public GameObject lvl5;
        public GameObject lvl6;
        public GameObject lvl7;
        public GameObject lvl8;


        //SHIELD ICON FOR ONE PLAYER IS UNTARGETABLE
        public GameObject shieldIcon;

        public GameObject mainBodyRight; //Player looking right
        public GameObject mainBodyLeft; //Player 

        public GameObject earthEffect; // Rock sprite while player is selected
        public GameObject fireEffect; //Player has _fire around them while _fire is selected
        public GameObject airEffect; //Player has _air around them while _air is selected
        public GameObject waterEffect; //Player has _water around them while 


        //Fireball stuff
        public GameObject fireBallLeft;
        public GameObject fireBallRight;


        //Sword Attacks
        public GameObject swordRight;
        public GameObject swordLeft;
        public float strikeCooldown = 0.1f;
        public float nextStrike = 0.0f;
        public bool canStrike;
        public bool isStriking = false;

        //Spear Attacks
        public GameObject spearRight;
        public GameObject spearLeft;
        public float stabCooldown = 0.5f;
        public float nextStab = 0.0f;
        public bool canStab;
        public bool isStabbing = false;


        //Cool-downs of abilities
        public float abilityCooldown = 1;
        public float nextAbility = 0.0f;
        public bool canUseAbility;

        //Direction variable - These variables will be used to know the players current direction
        private KeyCode _directionGetter;
        private char _direction;


        private bool _air = false;
        private bool _fire = false;
        private bool _water = false;
        private bool _earth = false;

        private float _jumpHeight;
        private bool _isJumping = false;

        private static Rigidbody2D _rb;

        // Start is called before the first frame update
        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        private void Update()
        {
            /*----------------------HEALTH UI---------------------------------*/
            switch (playerHealth)
            {
                case 0:
                        mainBodyLeft.SetActive(false);
                        mainBodyRight.SetActive(false);
                        health1.SetActive(false);
                        dead.SetActive(true);
                    break;
                case 1:
                    health1.SetActive(true);
                    health2.SetActive(false);
                    health3.SetActive(false);
                    health4.SetActive(false);
                    health5.SetActive(false);
                    health6.SetActive(false);
                    health7.SetActive(false);
                    health8.SetActive(false);
                    health9.SetActive(false);
                    health10.SetActive(false);
                    health11.SetActive(false);
                    break;
                case 2:
                    health1.SetActive(false);
                    health2.SetActive(true);
                    health3.SetActive(false);
                    health4.SetActive(false);
                    health5.SetActive(false);
                    health6.SetActive(false);
                    health7.SetActive(false);
                    health8.SetActive(false);
                    health9.SetActive(false);
                    health10.SetActive(false);
                    health11.SetActive(false);
                    break;
                case 3:
                    health1.SetActive(false);
                    health2.SetActive(false);
                    health3.SetActive(true);
                    health4.SetActive(false);
                    health5.SetActive(false);
                    health6.SetActive(false);
                    health7.SetActive(false);
                    health8.SetActive(false);
                    health9.SetActive(false);
                    health10.SetActive(false);
                    health11.SetActive(false);
                    break;
                case 4:
                    health1.SetActive(false);
                    health2.SetActive(false);
                    health3.SetActive(false);
                    health4.SetActive(true);
                    health5.SetActive(false);
                    health6.SetActive(false);
                    health7.SetActive(false);
                    health8.SetActive(false);
                    health9.SetActive(false);
                    health10.SetActive(false);
                    health11.SetActive(false);
                    break;
                case 5:
                    health1.SetActive(false);
                    health2.SetActive(false);
                    health3.SetActive(false);
                    health4.SetActive(false);
                    health5.SetActive(true);
                    health6.SetActive(false);
                    health7.SetActive(false);
                    health8.SetActive(false);
                    health9.SetActive(false);
                    health10.SetActive(false);
                    health11.SetActive(false);
                    break;
                case 6:
                    health1.SetActive(false);
                    health2.SetActive(false);
                    health3.SetActive(false);
                    health4.SetActive(false);
                    health5.SetActive(false);
                    health6.SetActive(true);
                    health7.SetActive(false);
                    health8.SetActive(false);
                    health9.SetActive(false);
                    health10.SetActive(false);
                    health11.SetActive(false);
                    break;
                case 7:
                    health1.SetActive(false);
                    health2.SetActive(false);
                    health3.SetActive(false);
                    health4.SetActive(false);
                    health5.SetActive(false);
                    health6.SetActive(false);
                    health7.SetActive(true);
                    health8.SetActive(false);
                    health9.SetActive(false);
                    health10.SetActive(false);
                    health11.SetActive(false);
                    break;
                case 8:
                    health1.SetActive(false);
                    health2.SetActive(false);
                    health3.SetActive(false);
                    health4.SetActive(false);
                    health5.SetActive(false);
                    health6.SetActive(false);
                    health7.SetActive(false);
                    health8.SetActive(true);
                    health9.SetActive(false);
                    health10.SetActive(false);
                    health11.SetActive(false);
                    break;
                case 9:
                    health1.SetActive(false);
                    health2.SetActive(false);
                    health3.SetActive(false);
                    health4.SetActive(false);
                    health5.SetActive(false);
                    health6.SetActive(false);
                    health7.SetActive(false);
                    health8.SetActive(false);
                    health9.SetActive(true);
                    health10.SetActive(false);
                    health11.SetActive(false);
                    break;
                case 10:
                    health1.SetActive(false);
                    health2.SetActive(false);
                    health3.SetActive(false);
                    health4.SetActive(false);
                    health5.SetActive(false);
                    health6.SetActive(false);
                    health7.SetActive(false);
                    health8.SetActive(false);
                    health9.SetActive(false);
                    health10.SetActive(true);
                    health11.SetActive(false);
                    break;
                case 11:
                    health1.SetActive(false);
                    health2.SetActive(false);
                    health3.SetActive(false);
                    health4.SetActive(false);
                    health5.SetActive(false);
                    health6.SetActive(false);
                    health7.SetActive(false);
                    health8.SetActive(false);
                    health9.SetActive(false);
                    health10.SetActive(false);
                    health11.SetActive(true);
                    break;
            }

            //LEVELING PLAYER UP BASED OFF OF EXP
            switch (exp)
            {
                case 1:

                    level = 1;

                    lvl1.SetActive(true);
                    lvl2.SetActive(false);
                    lvl3.SetActive(false);
                    lvl4.SetActive(false);
                    lvl5.SetActive(false);
                    lvl6.SetActive(false);
                    lvl7.SetActive(false);
                    lvl8.SetActive(false);

                    break;
                case 3:

                    if (level != 2)
                    {
                        level = 2;

                        lvl1.SetActive(false);
                        lvl2.SetActive(true);
                        lvl3.SetActive(false);
                        lvl4.SetActive(false);
                        lvl5.SetActive(false);
                        lvl6.SetActive(false);
                        lvl7.SetActive(false);
                        lvl8.SetActive(false);

                        playerHealth += 1;
                        strikeCooldown = 0.095f;
                        stabCooldown = 0.495f;
                        abilityCooldown = 0.95f;
                    }

                    break;
                case 6:
                    if (level != 3)
                    {
                        level = 3;

                        lvl1.SetActive(false);
                        lvl2.SetActive(false);
                        lvl3.SetActive(true);
                        lvl4.SetActive(false);
                        lvl5.SetActive(false);
                        lvl6.SetActive(false);
                        lvl7.SetActive(false);
                        lvl8.SetActive(false);

                        playerHealth += 1;
                        strikeCooldown = 0.090f;
                        stabCooldown = 0.490f;
                        abilityCooldown = 0.90f;
                    }

                    break;
                case 9:
                    if (level != 4)
                    {
                        level = 4;

                        lvl1.SetActive(false);
                        lvl2.SetActive(false);
                        lvl3.SetActive(false);
                        lvl4.SetActive(true);
                        lvl5.SetActive(false);
                        lvl6.SetActive(false);
                        lvl7.SetActive(false);
                        lvl8.SetActive(false);

                        playerHealth += 1;
                        strikeCooldown = 0.085f;
                        stabCooldown = 0.485f;
                        abilityCooldown = 0.985f;
                    }

                    break;
                case 12:
                    if (level != 5)
                    {
                        level = 5;

                        lvl1.SetActive(false);
                        lvl2.SetActive(false);
                        lvl3.SetActive(false);
                        lvl4.SetActive(false);
                        lvl5.SetActive(true);
                        lvl6.SetActive(false);
                        lvl7.SetActive(false);
                        lvl8.SetActive(false);

                        playerHealth += 1;
                        strikeCooldown = 0.080f;
                        stabCooldown = 0.480f;
                        abilityCooldown = 0.80f;
                    }

                    break;
                case 15:
                    if (level != 6)
                    {
                        level = 6;

                        lvl1.SetActive(false);
                        lvl2.SetActive(false);
                        lvl3.SetActive(false);
                        lvl4.SetActive(false);
                        lvl5.SetActive(false);
                        lvl6.SetActive(true);
                        lvl7.SetActive(false);
                        lvl8.SetActive(false);

                        playerHealth += 1;
                        strikeCooldown = 0.075f;
                        stabCooldown = 0.475f;
                        abilityCooldown = 0.75f;
                    }

                    break;
                case 18:
                    if (level != 7)
                    {
                        level = 7;

                        lvl1.SetActive(false);
                        lvl2.SetActive(false);
                        lvl3.SetActive(false);
                        lvl4.SetActive(false);
                        lvl5.SetActive(false);
                        lvl6.SetActive(false);
                        lvl7.SetActive(true);
                        lvl8.SetActive(false);

                        playerHealth += 1;
                        strikeCooldown = 0.070f;
                        stabCooldown = 0.470f;
                        abilityCooldown = 0.70f;
                    }

                    break;
                case 21:
                    if (level != 8)
                    {
                        level = 8;

                        lvl1.SetActive(false);
                        lvl2.SetActive(false);
                        lvl3.SetActive(false);
                        lvl4.SetActive(false);
                        lvl5.SetActive(false);
                        lvl6.SetActive(false);
                        lvl7.SetActive(false);
                        lvl8.SetActive(true);

                        playerHealth += 1;
                        strikeCooldown = 0.065f;
                        stabCooldown = 0.465f;
                        abilityCooldown = 0.65f;
                    }

                    break;
            }


            // --DIRECTION SETTER----------
            if (Input.GetKey(KeyCode.D))
            {
                _direction = 'R';
                mainBodyRight.SetActive(true);
                mainBodyLeft.SetActive(false);
            }

            if (Input.GetKey(KeyCode.A))
            {
                _direction = 'L';
                mainBodyRight.SetActive(false);
                mainBodyLeft.SetActive(true);
            }


            //CHECK IF PLAYER CAN USE ABILITY
            canUseAbility = Time.time > nextAbility;

            //CHECK IF PLAYER CAN STRIKE
            canStrike = Time.time > nextStrike;

            //CHECKING IF PLAYER CAN STAB
            canStab = Time.time > nextStab;


            //ABILITY BUTTON
            if (Input.GetKeyDown(KeyCode.P) && canUseAbility) // P Key will be used for ability combat
            {
                if (_fire) //This is what happens when _fire is selected
                {
                    if (_direction == 'R') //if facing right
                    {
                        fireRight();
                    }

                    if (_direction == 'L') //if facing left
                    {
                        fireLeft();
                    }
                }

                nextAbility = Time.time + abilityCooldown;
            }


            //SPEAR ATTACK Using M key
            if (Input.GetKeyDown(KeyCode.M) && canStab)
            {
                isStabbing = true;

                if (_direction == 'R' && Time.time < Time.time + stabCooldown)
                {
                    spearRight.SetActive(true);
                    spearLeft.SetActive(false);
                }

                if (_direction == 'L')
                {
                    spearLeft.SetActive(true);
                    spearRight.SetActive(false);
                }

                nextStab = Time.time + stabCooldown;
            }
            else
            {
                spearRight.SetActive(false);
                spearLeft.SetActive(false);
            }

            //SWORD ATTACK
            if (Input.GetKeyDown(KeyCode.O) && canStrike) // O Key will be used for weapon combat
            {
                if (_direction == 'R')
                {
                    swordRight.SetActive(true);
                    swordLeft.SetActive(false);
                }

                if (_direction == 'L')
                {
                    swordLeft.SetActive(true);
                    swordRight.SetActive(false);
                }


                nextStrike = Time.time + strikeCooldown;
            }
            else
            {
                swordRight.SetActive(false);
                swordLeft.SetActive(false);
            }

            /*------------------------MOVEMENT-------------------------------*/
            if (Input.GetKeyDown(KeyCode.Space) && !_isJumping && !_earth)
            {
                _rb.AddForce(Vector2.up * _jumpHeight, ForceMode2D.Impulse);
                _isJumping = true;
            }

            // ----------------Movement----------------------------
            if (!_earth)
            {
                var movementHorizontal = Input.GetAxis("Horizontal");

                var movement = new Vector2(movementHorizontal, 0.01f);
                _rb.AddForce(movement * speed);
            }


            //------------------------ELEMENTS----------------------------
            {
                if (Input.GetKeyDown(KeyCode.Alpha1) && hasAir) //AIR 

                {
                    earthEffect.SetActive(false);
                    airEffect.SetActive(true);
                    fireEffect.SetActive(false);
                    waterEffect.SetActive(false);

                    _air = true;
                    _fire = false;
                    _water = false;
                    _earth = false;

                    isTargetable = true;
                }

                if (Input.GetKeyDown(KeyCode.Alpha2) && hasEarth) //EARTH
                {
                    earthEffect.SetActive(true);
                    fireEffect.SetActive(false);
                    airEffect.SetActive(false);
                    waterEffect.SetActive(false);


                    _air = false;
                    _fire = false;
                    _water = false;
                    _earth = true;
                }

                if (Input.GetKeyDown(KeyCode.Alpha3) && hasFire) //FIRE
                {
                    fireEffect.SetActive(true);
                    earthEffect.SetActive(false);
                    airEffect.SetActive(false);
                    waterEffect.SetActive(false);

                    _air = false;
                    _fire = true;
                    _water = false;
                    _earth = false;

                    isTargetable = true;
                }

                if (Input.GetKeyDown(KeyCode.Alpha4) && hasWater) //WATER
                {
                    earthEffect.SetActive(false);
                    fireEffect.SetActive(false);
                    airEffect.SetActive(false);
                    waterEffect.SetActive(true);


                    _air = false;
                    _fire = false;
                    _water = true;
                    _earth = false;

                    isTargetable = true;
                }

                if (Input.GetKeyDown(KeyCode.Alpha5)) // Nothing
                {
                    earthEffect.SetActive(false);
                    fireEffect.SetActive(false);
                    airEffect.SetActive(false);
                    waterEffect.SetActive(false);

                    _air = false;
                    _fire = false;
                    _earth = false;
                    _water = false;

                    isTargetable = true;
                }
            }

            //---- This if statement checks if _air is selected. If it is the the player will be able to float more
            if (_air)
            {
                _rb.gravityScale = 4f;
                _jumpHeight = 30f;
            }

            else
            {
                _rb.gravityScale = 10f;
                _jumpHeight = 30f;
            }

            if (_earth)
            {
                canStrike = false;
                isTargetable = false;
            }
        }


        private void makeTargetable()
        {
            isTargetable = true;
            shieldIcon.SetActive(false);
        }


//Player will be able to phase through enemies while unTargetable
        private void phase()
        {
            isTargetable = false;
            shieldIcon.SetActive(true);

            Invoke(nameof(makeTargetable), 2);
        }


//Checks if the player is grounded
        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.tag.Equals("Ground"))
            {
                _isJumping = false;
            }
        }

        private void OnTriggerStay2D(Collider2D col)
        {
            if (isTargetable)
            {
                if (col.gameObject.tag.Equals("Enemy1"))
                {
                    playerHealth -= 1;
                    phase();
                }

                if (col.gameObject.tag.Equals("Enemy2"))
                {
                    playerHealth -= 1;
                    phase();
                }

                if (col.gameObject.tag.Equals("Enemy3"))
                {
                    playerHealth -= 1;
                    phase();
                }
            }

            if (col.gameObject.tag.Equals("FireSkill"))
            {
                hasFire = true;
            }

            if (col.gameObject.tag.Equals("AirSkill"))
            {
                hasAir = true;
            }

            if (col.gameObject.tag.Equals("EarthSkill"))
            {
                hasEarth = true;
            }

            if (col.gameObject.tag.Equals("WaterSkill"))
            {
                hasWater = true;
            }

            if (col.gameObject.tag.Equals("Exp1"))
            {
                Destroy(col.gameObject);
                exp += 1;
            }

            if (!col.gameObject.tag.Equals("Exp3")) return;
            Destroy(col.gameObject);
            exp += 3;

            // if (col.gameObject.tag.Equals("Teleporter"))
            // {
            //     SceneManager.LoadScene("Level2");
            //     _pos = _rb.transform.position;
            //     _pos.x = -140f;
            //     _pos.y = 38f;
            //     _rb.transform.position = _pos;
            // }
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
            var position = _rb.position;
            var spawnLocation = new Vector2(position.x + 1.5f, position.y + 0.05f);
            Instantiate(fireBallRight, spawnLocation, Quaternion.identity);
        }

        private void fireLeft()
        {
            var position = _rb.position;
            var spawnLocation = new Vector2(position.x - 1.5f, position.y + 0.05f);
            Instantiate(fireBallLeft, spawnLocation, Quaternion.identity);
        }

        public static void TeleportToLevel2()
        {
            SceneManager.LoadScene("Level2");
            _pos = _rb.transform.position;
            _pos.x = -140f;
            _pos.y = 38f;
            _rb.transform.position = _pos;
        }
    }
}