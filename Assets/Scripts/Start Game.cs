using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void Begin()
    {
        SceneManager.LoadSceneAsync(1);
    }
}
