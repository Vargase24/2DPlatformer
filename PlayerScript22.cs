using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript22 : MonoBehaviour
{
    private Rigidbody2D myRigidbody;
    private Animator myAnimator;
    public float moveSpeed;
    public bool facingRight;
    [SerializeField]
    private Transform[] groundPoints;                       //creartes an array of "points" (actually game objects) to collide with the ground
    [SerializeField]
    private float groundRadius;                             //creates the size of the colliders
    [SerializeField]
    private LayerMask whatIsGround;                         //defines what is ground
    private bool isGrounded;                                //can be set to true or false based on out position
    private bool jump;                                      //can be set to true or false when we press the space key
    [SerializeField]
    private float jumpForce;                                //allows us to determine the magnitude of the jump
    public bool isAlive;
    public GameObject reset;
    private Slider healthBar;
    public float health = 2f;
    private float healthBurn = 1f;
    private float smallHealthBurn = 0.2f;
    [SerializeField]
    private GameObject projectile;

    // Start is called before the first frame update
    void Start()
    {
        facingRight = true;
        myRigidbody = GetComponent<Rigidbody2D>();          //a variable to control the Player's body
        myAnimator = GetComponent<Animator>();              //a variable to control the Player's Animator controller
        isAlive = true;
        reset.SetActive(false);
        healthBar = GameObject.Find("health slider").GetComponent<Slider>();
        healthBar.minValue = 0f;
        healthBar.maxValue = health;
        healthBar.value = healthBar.maxValue;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");     //a variable that stores the value of our horizontal movement
        //Debug.Log(horizontal);
        if (isAlive)
        {
            PlayerMovement(horizontal);
            Flip(horizontal);
            HandleInput();
        }
        else
            return;
        isGrounded = IsGrounded();
        if (GameObject.Find("player").GetComponent<Shoot>().isShooting)
        {
            ShootHealth();
        }
    }

    //Function Definitions
    private void PlayerMovement(float horizontal)           //funtion that controls player on the x axis
    {
        if (isGrounded && jump)
        {
            isGrounded = false;
            jump = false;
            myRigidbody.AddForce(new Vector2(0, jumpForce));
            myAnimator.SetBool("jumping", true);
        }
        myRigidbody.velocity = new Vector2(horizontal * moveSpeed, myRigidbody.velocity.y); //adds velocity to the Player's body on the x axis
        myAnimator.SetFloat("speed",Mathf.Abs(horizontal));
        //myAnimator.SetBool("jumping",!isGrounded);
    }
                                                            //boolian opperators: && (and) || (or) == (the same as) != (not the same as)
    private void Flip(float horizontal)
    {
        if (horizontal < 0 && facingRight || horizontal > 0 && !facingRight)
        {
            facingRight = !facingRight;                     //resets the bool to the opposite value
            Vector2 theScale = transform.localScale;        //creating a vector 2 and storing the local scale values
            theScale.x *= -1;
            transform.localScale = theScale;
        }

    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            jump = true;
            //Debug.Log ("I'm jumping");
        }
    }

 
                                                            //function to test for collisions between the array of groundPoints and the Ground LayerMask
    private bool IsGrounded()
    {
        if (myRigidbody.velocity.y <= 0)
        {
                                                            //if the player is not moving vertically, test each of the Player's groundPoints for collision with Ground
            foreach (Transform point in groundPoints)
            {
                Collider2D[] colliders = Physics2D.OverlapCircleAll(point.position, groundRadius, whatIsGround);
                for (int i = 0; 1 < colliders.Length; i++)
                {
                    if (colliders[i].gameObject != gameObject) 
                    {
                        return true;                        //if any of the colliders in the array of groundPoints comes into contact with another gameobject, return true.
                    }
                }
            }
        }
        return false;                                       //if the player is not moving along the y axis, return false.
    }

    private void OnCollisionEnter2D(Collision2D target)
    {
        if(target.gameObject.tag == "ground")
        {
            myAnimator.SetBool("jumping", false);
        }
        if (target.gameObject.tag == "deadly")
        {
            ImDead();
        }
        if (target.gameObject.tag == "damage")
        {
            UpdateHealth();
        }
    }

    void UpdateHealth()
    {
        if (health > 0)
        {
            health -= healthBurn;
            healthBar.value = health;
        }
        if (health <= 0)
        {
            ImDead();
        }
    }

    void ShootHealth()
    {
        if (health > 0)
        {
            health -= smallHealthBurn;
            healthBar.value = health;
        }
        if (health <= 0)
        {
            ImDead();
        }
    }

    public void ImDead()
    {
        isAlive = false;
        myAnimator.SetBool("dead", true);
        reset.SetActive(true);
        healthBar.value = 0f;
    }

}