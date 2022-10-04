using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag(TagManager.PLAYER_TAG))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            PlayerPrefs.SetInt(TagManager.LEVEL_COMPLETE, SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}