using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private GameObject player;

    private Transform tempPos;
    private float tempNum;

    private void Awake()
    {
        player = GameObject.FindWithTag(TagManager.PLAYER_TAG);
        tempPos = GetComponent<Transform>();
    }

    private void Start()
    {
        tempPos.position = new Vector3(player.transform.position.x, tempPos.position.y, tempPos.position.z);
    }

    private void Update()
    {
        CheckPosAndMove();
    }

    void CheckPosAndMove()
    {
        if (player == null)
            return;
        
        if(Vector2.Distance(tempPos.position, player.transform.GetChild(0).position) > 5)
        {
            tempNum = Vector2.Distance(tempPos.position, player.transform.GetChild(0).position);
            tempNum -= 5;

            tempPos.position = new Vector3(tempPos.position.x - 2*(tempNum * Time.deltaTime), 
                                            tempPos.position.y, tempPos.position.z);

        }

        if (Vector2.Distance(tempPos.position, player.transform.GetChild(1).position) > 5)
        {
            tempNum = Vector2.Distance(tempPos.position, player.transform.GetChild(1).position);
            tempNum -= 5;

            tempPos.position = new Vector3(tempPos.position.x + (tempNum),
                                            tempPos.position.y, tempPos.position.z);

        }
        //* Time.deltaTime 
    }
}
