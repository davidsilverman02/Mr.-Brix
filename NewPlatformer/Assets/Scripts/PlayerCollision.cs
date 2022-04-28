using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement plemove;
    public Rigidbody2D plebod;
    public BoxCollider2D colli;
    public GameObject hitBase;
    public float bounceHeight = 400;
    void Awake()
    {
        plemove = GetComponentInParent<PlayerMovement>();
        plebod = GetComponentInParent<Rigidbody2D>();
        colli = gameObject.GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // The player takes damage on being shot
        if (collision.gameObject.tag == "EnemyProj" && plemove.invincible == false)
        {
            plemove.TakeDamage(1);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // The player takes damage to objects with the following tags
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Hazard")
        {
            if (gameObject.tag != "PlayerBox" && plemove.invincible == false)
            {
                if (gameObject.tag != "PlayerBox" && plemove.invincible == false)
                {
                    if (collision.gameObject.tag == "Enemy")
                    {
                        if (hitBase.transform.position.y > collision.transform.position.y)
                        {
                            plebod.AddForce(new Vector2(0, bounceHeight));
                        }
                        else
                        {
                            plemove.TakeDamage(1);
                        }
                        Destroy(collision.gameObject);
                    }
                }
            }

            if(collision.gameObject.tag == "Hazard")
            {
                plemove.TakeDamage(1);
            }
        }

        if (collision.gameObject.tag == "Boss" && plemove.invincible == false)
        {
            if (gameObject.tag != "PlayerBox")
            {
                plemove.TakeDamage(1);
            }
        }
    }
}
