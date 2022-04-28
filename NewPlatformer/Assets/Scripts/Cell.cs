using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    // Sets all of the variables there are
    public Transform player;
    public Transform node;
    public GameObject Camera;
    public float xMag;
    public float yMag;
    public float transitDist = 7.9f;
    // Start is called before the first frame update
    void Start()
    {
        // Sets how the cell works
        node = gameObject.transform;
        Camera = GameObject.FindGameObjectWithTag("MainCamera");
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        // sees if the camera should be at the position of the cell
        xMag = Mathf.Abs(node.position.x - player.position.x);
        yMag = Mathf.Abs(node.position.y - player.position.y);
        if(xMag <= transitDist && yMag <= transitDist)
        {
            Camera.transform.position = new Vector3(node.position.x, node.position.y, Camera.transform.position.z);
        }
    }
}
