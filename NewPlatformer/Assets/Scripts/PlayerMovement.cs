using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Declares all variables
    public float moveX = 0f;
    public float baseXSpeed = 5f;
    public float xSpeed;
    public float baseJumpForce = 700f;
    public float gravIncrement = .25f;
    public float inviTime = 1.5f;
    public float cycles = 10f;
    public float frames;
    public float jumpForce;
    public bool isGrounded = false;
    public bool shouldJump = false;
    public bool invincible = false;
    public Rigidbody2D playerBody;
    public LegsCollision legs;
    public int activeBoxes;
    public PlayerBox[] boxes;
    public int maxHealth = 5;
    public int health;
    // Start is called before the first frame update
    void Start()
    {
        // Attaches the components to the script and sets unassigned variables with value
        frames = inviTime / cycles;
        playerBody = gameObject.GetComponent<Rigidbody2D>();
        legs = gameObject.GetComponentInChildren<LegsCollision>();
        xSpeed = baseXSpeed;
        jumpForce = baseJumpForce;
        activeBoxes = 0;
        boxes = FindObjectsOfType<PlayerBox>();
        health = maxHealth;

    }

    // Update is called once per frame
    void Update()
    {
        // Gets the input and weight of the player
        CheckInput();
        CheckWeight();
    }

    void FixedUpdate()
    {
        // Checks the physics movement and the statistics of the player
        Move();
        CheckJump();
        CheckGround();
        SetWeight();
    }

    void CheckInput()
    {
        // Checks Horizontal Speed and Jump
        moveX = Input.GetAxisRaw("Horizontal") * baseXSpeed;
        if(isGrounded)
        {

            if (Input.GetKeyDown(KeyCode.Space))
            {
                shouldJump = true;
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        // The player heals with hearts
        if(collision.gameObject.tag == "Heart")
        {
            RestoreHealth();
            Destroy(collision.gameObject);
        }
    }

    void Move()
    {
        // The Player moves based on its x axis
        playerBody.velocity = new Vector2(moveX, playerBody.velocity.y);
    }

    void Jump()
    {
        // The Player jumps
        shouldJump = false;
        playerBody.AddForce(Vector2.up * jumpForce);
    }

    void CheckJump()
    {
        // The player checks if it should jump
        if (shouldJump)
        {
            Jump();
        }
    }

    void CheckGround()
    {
        // The player checks if it is on the ground
        isGrounded = legs.groundBool;
    }

    void CheckWeight()
    {
        // Gets the weight of the object based on how many player boxes there are
        activeBoxes = 0;
        foreach(PlayerBox box in boxes)
        {
            if(box.weighing == true)
            {
                activeBoxes++;
            }
        }
    }

    void SetWeight()
    {
        // Sets the weight of the object based on how many player boxes there are
        playerBody.gravityScale = 1 + (activeBoxes * gravIncrement);
    }

    public void TakeDamage(int strength)
    {
        // The player takes damage
        health -= strength;
        StartCoroutine(RunInvi());
    }

    public void RestoreHealth()
    {
        // The player restores health
        health = maxHealth;
    }

    public IEnumerator RunInvi()
    {
        invincible = true;
        for (float i = 0; i < inviTime; i += frames)
        {
            if (gameObject.GetComponent<Renderer>().enabled == true)
            {
                gameObject.GetComponent<Renderer>().enabled = false;
            }
            else
            {
                gameObject.GetComponent<Renderer>().enabled = true;
            }
            yield return new WaitForSeconds(frames);
        }
        gameObject.GetComponent<Renderer>().enabled = true;
        invincible = false;
    }
}
