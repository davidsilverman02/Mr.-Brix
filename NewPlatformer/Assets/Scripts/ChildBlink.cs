using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildBlink : MonoBehaviour
{
    public GameObject parent;
    public SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        parent = GameObject.FindWithTag("Player");
        sprite = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        sprite.enabled = parent.GetComponent<Renderer>().enabled;
    }
}
