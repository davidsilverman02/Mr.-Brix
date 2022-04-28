using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickBox : MonoBehaviour
{
    // Runs the transparency of the buttons used in the matrix
    public bool active;
    public Image self;
    public Color selfColor;
    // Start is called before the first frame update
    void Start()
    {
        active = false;
        self = gameObject.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        self.color = selfColor;
        switch (active)
        {
            case true:
                selfColor.a = 1;
                break;
            case false:
                selfColor.a = 0;
                break;
        }
    }

    public void Active()
    {
        active = !active;
    }
}
