using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    // Makes it so the enemeies move back and forth
    public float speed = -5f;
    public SpriteRenderer sprite;
    public ColliderFlipper turn;
    public Rigidbody2D veloc;
    // Start is called before the first frame update
    void Start()
    {
        sprite = gameObject.GetComponent<SpriteRenderer>();
        veloc = gameObject.GetComponent<Rigidbody2D>();
        turn = gameObject.GetComponentInChildren<ColliderFlipper>();
    }

    // Update is called once per frame
    void Update()
    {
        if (turn.touched)
        {
            OnCol();
        }

        veloc.velocity = new Vector2(speed, 0);
       
    }

    private void OnCol()
    {
        sprite.flipX = !sprite.flipX;
        speed = -speed;
        turn.touched = false;
    }
}
