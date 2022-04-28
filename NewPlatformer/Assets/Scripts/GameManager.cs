using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Manages the death and body of the player
    public PlayerMovement player;
    public ClickBox[] UIBoxes;
    public PlayerBox[] playerBoxes;
    public Text healthInfo;

    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        healthInfo.text = player.health.ToString();
        for(int i = 0; i < UIBoxes.Length; i++)
        {
            if(UIBoxes[i].active == true)
            {
                playerBoxes[i].ChangeMode(true);
            }
            else
            {
                playerBoxes[i].ChangeMode(false);
            }
        }

        if(player.health <= 0)
        {
            SceneManager.LoadScene("SelectScreen");
        }
    }
}
