using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroScript : MonoBehaviour
{

    public void Exit_Game()
    {
        Application.Quit();
    }

    public void Play_Game()
    {
        if(PlayerPrefs.GetInt(TagManager.LEVEL_COMPLETE) > 0)
            SceneManager.LoadScene(PlayerPrefs.GetInt(TagManager.LEVEL_COMPLETE));
        else
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LevelsList()
    {
        SceneManager.LoadScene(5);
    }
}
