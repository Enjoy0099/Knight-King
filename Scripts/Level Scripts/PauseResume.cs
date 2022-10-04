using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseResume : MonoBehaviour
{
    private Transform tempPos;

    private void Awake()
    {
        tempPos = GetComponent<Transform>();
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        tempPos.GetChild(0).gameObject.SetActive(false);
        tempPos.GetChild(1).gameObject.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        tempPos.GetChild(1).gameObject.SetActive(false);
        tempPos.GetChild(0).gameObject.SetActive(true);
    }
}
