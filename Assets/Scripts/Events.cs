using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Events : MonoBehaviour
{
    public void ReplayGame()
    {
        SceneManager.LoadScene("GamePlay");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
