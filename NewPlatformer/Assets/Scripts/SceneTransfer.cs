using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransfer : MonoBehaviour
{
    public void GoToScene(string scene)
    {
        if (PlayerPrefs.GetInt("LevelInt") == 0)
        {
            PlayerPrefs.SetInt("LevelInt", 1);
        }
        SceneManager.LoadScene(scene);
    }
}
