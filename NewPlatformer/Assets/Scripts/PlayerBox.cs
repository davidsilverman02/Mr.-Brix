using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBox : MonoBehaviour
{
    public GameObject parent;
    public SpriteRenderer sprite;
    public BoxCollider2D box;
    public bool weighing;
    void Start()
    {
        parent = GameObject.FindWithTag("Player");
        sprite = gameObject.GetComponent<SpriteRenderer>();
        box = gameObject.GetComponent<BoxCollider2D>();
        ChangeMode(false);
    }

    private void Update()
    {
        if(weighing == true)
        {
            sprite.enabled = parent.GetComponent<Renderer>().enabled;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "MovingPlatform")
        {
            parent.transform.parent = collision.transform;
        }

        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Boss")
        {
            //parent.GetComponent<PlayerMovement>().health += 1;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "MovingPlatform")
        {
            parent.transform.parent = null;
        }
    }

    public void ChangeMode(bool state)
    {
        sprite.enabled = state;
        box.enabled = state;
        if(state == true)
        {
            weighing = true;
        }
        else
        {
            weighing = false;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyProj")
        {
            
        }
    }
}
