using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    private static bool isOver;
    void Awake()
    {
        isOver = false;
        GameLogic.OnGameOver += Over; 
    }

    public void Over()
    {
        isOver = true;
        StartCoroutine("Wait");
    }

    public static bool GetIsOver()
    {
        return isOver;
    }

    IEnumerator Wait()
    {
        float timer = 3f;
        while(timer > 0f)
        {
            timer -= Time.deltaTime;
            yield return null;
        }
        SceneManager.LoadSceneAsync(0);
        
    }
}
