using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static void SetNumValue(string name, int num)
    {
        PlayerPrefs.SetInt(name, num);
    }

    public static int GetNumValue(string name)
    {
        return PlayerPrefs.GetInt(name);
    }
}
