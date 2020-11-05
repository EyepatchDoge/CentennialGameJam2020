using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeTheScenes : MonoBehaviour
{
    public void NextScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void QuitFromGame()
    {
        Application.Quit();
        Debug.Log("The Game has quit");
    }
}
