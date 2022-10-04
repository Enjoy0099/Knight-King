using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{

    public static Lock instance;

    [SerializeField]
    private float scaleTime = 1f;

    private Vector3 myScale;

    private bool canScale;

    private BoxCollider2D myCollider;

    private void Awake()
    {
        if (instance == null)
            instance = this;

        myCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        Unlock();
    }

    void Unlock()
    {
        if(canScale)
        {
            myScale = transform.localScale;
            myScale.y -= scaleTime * Time.deltaTime;

            if (myScale.y <= 0f)
            {
                myScale.y = 0f;
                canScale = false;
                myCollider.enabled = false;
            }
                

            transform.localScale = myScale;
        }
    }

    public void UnlockDoor()
    {
        canScale = true;
    }


}
