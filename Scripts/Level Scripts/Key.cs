using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{

    public delegate void KeyCollected();
    public static event KeyCollected keyCollectedInfo;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag(TagManager.PLAYER_TAG))
        {
            //Lock.instance.UnlockDoor();
            if (keyCollectedInfo != null)
                keyCollectedInfo();

            Destroy(gameObject);
        }
    }

}
