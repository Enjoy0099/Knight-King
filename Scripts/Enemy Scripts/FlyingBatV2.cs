using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingBatV2 : MonoBehaviour
{
    [SerializeField]
    private float minX = -8.2f, maxX = 8f, minY = -3.5f, maxY = 4.5f;

    private Vector3 targetPosition;

    [SerializeField]
    private float moveSpeed = 2f;

    private SpriteRenderer sr;

    private float previousX;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        targetPosition = new Vector3(transform.position.x + 0.5f, transform.position.y, transform.position.z);
    }

    private void Update()
    {
        moveToTargetPosition();
    }

    void moveToTargetPosition()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition,
                                                    moveSpeed * Time.deltaTime);
        if(Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            targetPosition = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0f);
            previousX = transform.position.x;
        }

        ChangeFacingDirection();
    }

    void ChangeFacingDirection()
    {
        if (transform.position.x > previousX)
            sr.flipX = false;
        if (transform.position.x < previousX)
            sr.flipX = true;
    }
}
