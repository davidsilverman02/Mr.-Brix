using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Receptacle : MonoBehaviour
{
    // runs the receptacles that open the doors
    public bool triggered;
    public Sprite activated;
    // Start is called before the first frame update
    void Start()
    {
        triggered = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Carry")
        {
            triggered = true;
            gameObject.GetComponent<SpriteRenderer>().sprite = activated;
            Destroy(collision.gameObject);
        }
    }
}
