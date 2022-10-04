using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormSoldier : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 1f;

    private Vector3 tempPos;
    private Vector3 tempScale;

    private bool moveLeft;

    [SerializeField]
    private LayerMask groundLayer;

    private Transform groundCheckPos;

    private RaycastHit2D groundHit;

    private void Awake()
    {
        groundCheckPos = transform.GetChild(0).transform;

        //if (Random.Range(0, 2) > 0)
        //    moveLeft = true;
        //else
        //    moveLeft = false;

        moveLeft = Random.Range(0, 2) > 0 ? true : false;
    }

    private void Update()
    {
        HandleMovement();
        CheckForGround();
    }

    void HandleMovement()
    {
        tempPos = transform.position;
        tempScale = transform.localScale;

        if(moveLeft)
        {
            tempPos.x -= moveSpeed * Time.deltaTime;
            tempScale.x = -1f;
        }
        else
        {
            tempPos.x += moveSpeed * Time.deltaTime;
            tempScale.x = 1f;
        }

        transform.localScale = tempScale;
        transform.position = tempPos;
    }

    void CheckForGround()
    {
        groundHit = Physics2D.Raycast(groundCheckPos.position, Vector2.down, 0.5f, groundLayer);

        if (!groundHit)
            moveLeft = !moveLeft;

        Debug.DrawRay(groundCheckPos.position, Vector2.down * 0.5f, Color.green);
    }




}
