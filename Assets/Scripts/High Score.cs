using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighScore : MonoBehaviour
{
    public void Awake()
    {
        if (PlayerPrefs.HasKey("score"))
        {
            GetComponent<TextMeshProUGUI>().text = "High Score: " + PlayerPrefs.GetInt("score");
        }
        else
        {
            GetComponent<TextMeshProUGUI>().text = "High Score Unset";
        }
        
    }
}
