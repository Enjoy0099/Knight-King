using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void HomeMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LevelsShow()
    {
        SceneManager.LoadScene(5);
    }
}
