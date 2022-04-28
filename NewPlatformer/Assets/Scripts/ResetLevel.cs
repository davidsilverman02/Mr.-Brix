using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetLevel : MonoBehaviour
{
    // Resets the player's levels completed
    public void LevelReset()
    {
        PlayerPrefs.SetInt("LevelInt", 1);
    }
}
