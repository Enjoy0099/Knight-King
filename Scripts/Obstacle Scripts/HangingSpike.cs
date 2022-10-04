using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HangingSpike : MonoBehaviour
{

    private Rigidbody2D myBody;

    [SerializeField]
    private LayerMask collisionLayer;

    private RaycastHit2D playerCast;

    private bool collidedWithPlayer;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        CheckForPlayerCollision();
    }

    void CheckForPlayerCollision()
    {

        if (collidedWithPlayer)
            return;

        playerCast = Physics2D.Raycast(transform.position, Vector2.down, Mathf.Infinity, collisionLayer);

        if(playerCast.collider != null)
        {
            collidedWithPlayer = true;
            myBody.gravityScale = 6f;
        }
    
    
    }
}
