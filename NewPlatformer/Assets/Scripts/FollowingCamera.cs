using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingCamera : MonoBehaviour
{
    public GameObject self;
    public GameObject player;
    public Transform playerTransform;
    public float xPosition;
    public float yPosition;
    public float xRoun;
    public float yRoun;
    public float cellSize = 8f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerTransform = player.transform;
        self = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        playerTransform = player.transform;
        xRoun = GetClosestEnemy(playerTransform)[0];
        yRoun = GetClosestEnemy(playerTransform)[1];
        xPosition = GetClosestEnemy(playerTransform)[0];
        yPosition = GetClosestEnemy(playerTransform)[1];
        self.transform.position = new Vector2(xPosition, yPosition);
        
    }

    public float[] GetClosestEnemy(Transform fromThis)
    {
        float[] bestTarget = null;

        float xRound = fromThis.position.x;// Mathf.Round(fromThis.position.x / cellSize) * cellSize;
        float yRound = fromThis.position.y;// Mathf.Round(fromThis.position.y / cellSize) * cellSize;
        
        bestTarget[0] = xRound;
        bestTarget[1] = yRound;
        return bestTarget;
    }

}
