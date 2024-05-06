using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour
{
    public void PlayButton()
    {
        SceneManager.LoadScene("PlayArea");
    }
    public void ExitButton()
    {
        Application.Quit();
    }
}
