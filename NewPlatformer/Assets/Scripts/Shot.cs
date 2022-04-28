﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    // runs shots by enemies
    public Rigidbody2D rb;
    public Vector2 move;
    public float moveX;
    public float moveY;
    public float life;
    public float speed = 50f;
    public float lifetime = 1f;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        moveX = gameObject.GetComponentInParent<Barrel>().xShot;
        moveY = gameObject.GetComponentInParent<Barrel>().yShot;
        move = new Vector2(moveX, moveY);
        rb.AddForce(speed * move);
    }

    // Update is called once per frame
    void Update()
    {
        life += Time.deltaTime;
        if(life >= lifetime)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag != "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
