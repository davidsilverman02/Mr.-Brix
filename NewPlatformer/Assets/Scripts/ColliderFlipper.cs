using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderFlipper : MonoBehaviour
{
    // The script for flipping the enemies
    public bool touched;
    public bool escape;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag != "EnemyProj")
        {
            touched = true;
        }
    }

    
}
