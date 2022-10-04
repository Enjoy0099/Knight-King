using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelsManager : MonoBehaviour
{
    public void PlayLevel1()
    {
        SceneManager.LoadScene(1);
    }
    public void PlayLevel2()
    {
        SceneManager.LoadScene(2);
    }
    public void PlayLevel3()
    {
        SceneManager.LoadScene(3);
    }



    private int LevelCompleteCount;

    [SerializeField]
    private GameObject[] CheckObject;

    [SerializeField]
    private Button[] levelComplete_Click;
    
    
    private void Awake()
    {
        LevelCompleteCount = DataManager.GetNumValue(TagManager.LEVEL_COMPLETE);
    }
    private void Update()
    {
        CheckLevel_Complete();
    }

    void CheckLevel_Complete()
    {
        switch(LevelCompleteCount)
        {
            case 2:
                CheckObject[0].SetActive(true);
                levelComplete_Click[0].enabled = true;
                break;

            case 3:
                CheckObject[0].SetActive(true);
                CheckObject[1].SetActive(true);
                levelComplete_Click[0].enabled = true;
                levelComplete_Click[1].enabled = true;
                break;

            case 4:
                CheckObject[0].SetActive(true);
                CheckObject[1].SetActive(true);
                CheckObject[2].SetActive(true);
                levelComplete_Click[0].enabled = true;
                levelComplete_Click[1].enabled = true;
                levelComplete_Click[2].enabled = true;
                break;

            default:
                CheckObject[0].SetActive(false);
                CheckObject[1].SetActive(false);
                CheckObject[2].SetActive(false);
                levelComplete_Click[0].enabled = false;
                levelComplete_Click[1].enabled = false;
                levelComplete_Click[2].enabled = false;
                break;
        }
    }
}
