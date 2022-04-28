using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegsCollision : MonoBehaviour
{
    // runs whether or not the player's legs should be on an object
    public bool groundBool;
    public BoxCollider2D collisionZone;
    public Transform parent;
    // Start is called before the first frame update
    void Start()
    {
        groundBool = false;
        collisionZone = gameObject.GetComponent<BoxCollider2D>();
        parent = gameObject.transform.parent;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        groundBool = true;
        if (collision.gameObject.tag == "MovingPlatform")
        {
            parent.transform.parent = collision.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        groundBool = false;
        if (collision.gameObject.tag == "MovingPlatform")
        {
            parent.transform.parent = null;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            groundBool = true;
        }

        if (collision.gameObject.tag == "Hazard")
        {
            groundBool = true;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            groundBool = true;
        }

        if (collision.gameObject.tag == "Hazard")
        {
            groundBool = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            groundBool = false;
        }

        if (collision.gameObject.tag == "Hazard")
        {
            groundBool = false;
        }
    }
}
