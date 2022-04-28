using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blast : MonoBehaviour
{
    public GameObject parent;
    // Start is called before the first frame update
    void Start()
    {
        // sets what will become the player
        parent = GameObject.FindWithTag("Player");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // sets the player as parent on collision
        if(collision.gameObject.tag == "Player" || collision.gameObject.tag == "PlayerBox")
        {
            gameObject.transform.parent = collision.gameObject.transform;
        }
        // prevents the tool from causing damage to the player
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Boss")
        {
          //  parent.GetComponent<PlayerMovement>().health += 1;
        }
    }
}
