using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneButtons : MonoBehaviour
{
    public int levels;
    public GameObject Button2;
    public GameObject Button3;
    public GameObject Button4;
    public GameObject Button5;
    // Start is called before the first frame update
    void Start()
    {
        levels = PlayerPrefs.GetInt("LevelInt");
        // activates buttons that are accessible to the player
        if (levels >= 2)
        {
            Button2.SetActive(true);
        }
        else
        {
            Button2.SetActive(false);
        }
        if (levels >= 3)
        {
            Button3.SetActive(true);
        }
        else
        {
            Button3.SetActive(false);
        }
        if (levels >= 4)
        {
            Button4.SetActive(true);
        }
        else
        {
            Button4.SetActive(false);
        }
        if (levels >= 5)
        {
            Button5.SetActive(true);
        }
        else
        {
            Button5.SetActive(false);
        }
    }

    private void Update()
    {
        levels = PlayerPrefs.GetInt("LevelInt");
        // activates buttons that are accessible to the player
        if (levels >= 2)
        {
            Button2.SetActive(true);
        }
        else
        {
            Button2.SetActive(false);
        }
        if (levels >= 3)
        {
            Button3.SetActive(true);
        }
        else
        {
            Button3.SetActive(false);
        }
        if (levels >= 4)
        {
            Button4.SetActive(true);
        }
        else
        {
            Button4.SetActive(false);
        }
        if (levels >= 5)
        {
            Button5.SetActive(true);
        }
        else
        {
            Button5.SetActive(false);
        }
    }
}

