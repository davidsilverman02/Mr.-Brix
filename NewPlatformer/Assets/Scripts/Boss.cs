using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    // sets variables
    public int maxHealth = 10;
    public int health;
    public SpriteRenderer rend;
    public Sprite healthy;
    public Sprite unhealthy;
    public float speed = -5f;
    public ColliderFlipper turn;
    public Rigidbody2D veloc;
    // Start is called before the first frame update
    void Start()
    {
        // sets variables
        health = maxHealth;
        rend = gameObject.GetComponent<SpriteRenderer>();
        veloc = gameObject.GetComponent<Rigidbody2D>();
        turn = gameObject.GetComponentInChildren<ColliderFlipper>();
    }

    // Update is called once per frame
    void Update()
    {
        // controls how the boss looks and when it dies
        if(health < maxHealth / 2)
        {
            rend.sprite = unhealthy;
        }
        else
        {
            rend.sprite = healthy;
        }

        if(health <= 0)
        {
            Destroy(gameObject);
        }

        if (turn.touched)
        {
            OnCol();
        }

        veloc.velocity = new Vector2(speed, 0);
    }

    private void OnCol()
    {
        speed = -speed;
        turn.touched = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // makes the player take damage
        if (collision.gameObject.tag == "PlayerProj")
        {
            health--;
        }
    }
}
