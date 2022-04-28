using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBall : MonoBehaviour
{
    // runs balls for receptacles
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Hazard")
        {
            Destroy(gameObject);
        }
        else if(collision.gameObject.tag == "Player")
        {
            gameObject.transform.parent = collision.gameObject.transform;
        }
    }
}
