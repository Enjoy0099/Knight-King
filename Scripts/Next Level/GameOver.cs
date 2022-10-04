using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void Exit_Game()
    {
        Application.Quit();
    }

    public void Play_Again()
    {
        SceneManager.LoadScene(0);
        DataManager.SetNumValue(TagManager.LEVEL_COMPLETE, 0);   
    }
}
