using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLegsCollision : MonoBehaviour
{
    // bounces the player up after jumping on the enemy
    public Rigidbody2D parent;
    // Start is called before the first frame update
    void Start()
    {
        parent = gameObject.GetComponentInParent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            parent.AddForce(Vector2.up * 200);
        }
    }
}
