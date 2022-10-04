using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundOnOff : MonoBehaviour
{
    private Transform tempPos;

    private GameObject soundBG;

    private bool audioSound = true;

    private void Awake()
    {
        tempPos = GetComponent<Transform>();
        soundBG = GameObject.FindWithTag(TagManager.SOUND_TAG);
    }

    public void changeImage()
    {
        audioSound = !audioSound;
        soundBG.GetComponent<AudioSource>().enabled = audioSound;
        tempPos.GetChild(0).gameObject.SetActive(audioSound);
        tempPos.GetChild(1).gameObject.SetActive(!audioSound);
    }
}
