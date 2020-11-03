using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public GameObject SettingsScreen;
    public void PlayGameButton()
    {
        SceneManager.LoadScene("PaulScene");
    }

    public void OptionsButton()
    {
        SettingsScreen.SetActive(true);
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
