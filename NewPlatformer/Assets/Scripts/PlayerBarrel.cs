using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBarrel : MonoBehaviour
{
    public GameObject shotPrefab;
    public Transform body;
    public float fireRate = 1f;
    public float xShot;
    public float yShot;
    // Start is called before the first frame update
    void Start()
    {
        body = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            GameObject shot = Instantiate(shotPrefab, body.position, body.rotation);
            shot.transform.parent = body;
        }
    }
}
