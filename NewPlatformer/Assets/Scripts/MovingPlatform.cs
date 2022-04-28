using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    // Makes it so moving platforms move back and forth
    public GameObject platform;
    public float speed = 5f;
    public Transform[] movePoints;
    Transform currentPoint;
    public int pointIndex = 0;
    public bool isOn;

    // Start is called before the first frame update
    void Start()
    {
        currentPoint = movePoints[pointIndex];
    }

    // Update is called once per frame
    void Update()
    {
        platform.transform.position = Vector2.MoveTowards(platform.transform.position, currentPoint.position, Time.deltaTime * speed);
        if (platform.transform.position == currentPoint.position)
        {
            if (pointIndex < movePoints.Length - 1 && isOn == true)
            {
                pointIndex++;
                currentPoint = movePoints[pointIndex];
                Debug.Log(pointIndex);
            }
            else if (isOn == false)
            {
                if(currentPoint != movePoints[0])
                {
                    pointIndex--;
                    currentPoint = movePoints[pointIndex];
                    Debug.Log(pointIndex);
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            isOn = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isOn = false;
        }
    }
}
