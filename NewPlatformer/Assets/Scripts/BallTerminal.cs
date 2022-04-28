using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTerminal : MonoBehaviour
{
    // Sets objects
    public Transform initTran;
    public GameObject ballPrefab;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" || collision.gameObject.tag == "PlayerBox")
        {
            // Produces balls for the player
            GameObject ball = Instantiate(ballPrefab, initTran.position, initTran.rotation) as GameObject;
        }
    }
}
