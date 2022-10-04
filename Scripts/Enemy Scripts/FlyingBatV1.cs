using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingBatV1 : MonoBehaviour
{
    [SerializeField]
    private float moveSpeedHorizontal = 2f, moveSpeedVertical = -2f;

    [SerializeField]
    private float horizontalTreshold = 7f, verticalTreshold = 4f;

    private float minX, minY, maxX, maxY;

    private Vector3 tempPos;

    private bool moveHorizontal = true;
    private bool moveVertical;

    private SpriteRenderer sr;

    private void Awake()
    {
        minX = transform.position.x - horizontalTreshold;
        maxX = transform.position.x + horizontalTreshold;

        minY = transform.position.y - verticalTreshold;
        maxY = transform.position.y + verticalTreshold;

        moveVertical = Random.Range(0, 2) > 0 ? true : false;

        if (Random.Range(0, 2) > 0)
            moveSpeedHorizontal *= -1f;

        sr = GetComponent<SpriteRenderer>();


    }

    private void Update()
    {
        HandleHorizontalMovement();
        HandleVerticalMovement();
    }

    void HandleHorizontalMovement()
    {
        if(moveHorizontal)
        {
            tempPos = transform.position;
            tempPos.x += moveSpeedHorizontal * Time.deltaTime;

            if (tempPos.x > maxX)
                moveSpeedHorizontal = -Mathf.Abs(moveSpeedHorizontal);
            if (tempPos.x < minX)
                moveSpeedHorizontal = Mathf.Abs(moveSpeedHorizontal);

            transform.position = tempPos;

            if (moveSpeedHorizontal < 0f)
                sr.flipX = true;
            if (moveSpeedHorizontal > 0f)
                sr.flipX = false;
        }
    }

    void HandleVerticalMovement()
    {
        if(moveVertical)
        {
            tempPos = transform.position;
            tempPos.y += moveSpeedVertical * Time.deltaTime;

            if (tempPos.y > maxY)
                moveSpeedVertical = -Mathf.Abs(moveSpeedVertical);
            if (tempPos.y < minY)
                moveSpeedVertical = Mathf.Abs(moveSpeedVertical);

            transform.position = tempPos;
        }
    }









}
