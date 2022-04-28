using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    // runs the doors in the level, seeing if they need to be unlocked or not
    public string scene;
    public bool trigger;
    public bool active;
    public SpriteRenderer sprite;
    public Sprite locked;
    public Sprite unlocked;
    public int nextLevel;
    // Start is called before the first frame update
    public void Start()
    {
        sprite = gameObject.GetComponent<SpriteRenderer>();
        if(trigger == false)
        {
            active = true;
        }
        else
        {
            Receptacle gate = GameObject.FindObjectOfType<Receptacle>();
            active = gate.triggered;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (trigger)
        {
            Receptacle gate = GameObject.FindObjectOfType<Receptacle>();
            active = gate.triggered;
        }

        if (active)
        {
            sprite.sprite = unlocked;
        }
        else
        {
            sprite.sprite = locked;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (active)
        {
            if(collision.gameObject.tag == "Player" || collision.gameObject.tag == "PlayerBox")
            {
                if(PlayerPrefs.GetInt("LevelInt") == 0)
                {
                    PlayerPrefs.SetInt("LevelInt", 1);
                }

                if (PlayerPrefs.GetInt("LevelInt") <= nextLevel)
                {
                    PlayerPrefs.SetInt("LevelInt", nextLevel);
                }

                SceneManager.LoadScene("SelectScreen");
            }
        }
    }
}
