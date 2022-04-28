using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    // Sets variables and objects
    public GameObject shotPrefab;
    public Transform body;
    public float fireRate = 1f;
    public float xShot;
    public float yShot;
    public bool cooling;
    public float coolingTime;
    // Start is called before the first frame update
    void Start()
    {
        // gets the location of the object
        body = gameObject.GetComponent<Transform>();
        
    }

    private void Update()
    {
        // run a loop
        TShot();
    }

    public void TShot()
    {
        // Shoots a bullet on a loop
        if(cooling == false)
        {
            GameObject shot = Instantiate(shotPrefab, body.position, body.rotation);
            shot.transform.parent = body;
            cooling = true;
        }
        else if(cooling)
        {
            coolingTime += Time.deltaTime;
        }

        if (coolingTime >= fireRate)
        {
            cooling = false;
            coolingTime = 0;
        }

    }
}
