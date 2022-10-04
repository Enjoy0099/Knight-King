using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D myBody;

    [SerializeField]
    private float player_MoveSpeed = 5f;

    private float horizontalMovement;

    private PlayerAnimation playerAnim;

    //[SerializeField]
    //private bool facingright;

    [SerializeField]
    private float normal_JumpForce = 5f, double_JumpForce = 5f;

    private float jumpForce = 5f;

    private RaycastHit2D groundCast;
    private BoxCollider2D boxCol2D;

    [SerializeField]
    private LayerMask groundMask;

    private bool canDoubleJump;
    private bool jumped;


    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<PlayerAnimation>();
        boxCol2D = GetComponent<BoxCollider2D>();

        canDoubleJump = true;
    }


    private void Update()
    {
        horizontalMovement = Input.GetAxisRaw(TagManager.HORIZONTAL_MOVEMENT_AXIS);

        HandleAnimation();

        HandleJumping();

        CheckToDoubleJump();

        FromJumpToWalkOrIdle();
    }

    private void FixedUpdate()
    {

        HandleMovement();
    }

    void HandleMovement()
    {
        if (horizontalMovement > 0)
        {
            myBody.velocity = new Vector2(player_MoveSpeed, myBody.velocity.y);
        }
        else if (horizontalMovement < 0)
        {
            myBody.velocity = new Vector2(-player_MoveSpeed, myBody.velocity.y);
        }
        else
        {
            myBody.velocity = new Vector2(0f, myBody.velocity.y);
        }
    }


    void HandleAnimation()
    {
        //if on the ground
        if(myBody.velocity.y == 0f)
        {
            playerAnim.PlayWalk(Mathf.Abs((int)myBody.velocity.x));
        }

        playerAnim.ChangeFacingDirection((int)myBody.velocity.x);

        /*
        if ((horizontalMovement < 0 && facingRight) || (horizontalMovement > 0 && !facingRight))
        {
            facingRight = !facingRight;
            transform.Rotate(new Vector3(0, 180, 0));
        }
        */

        playerAnim.PlayJumpAndFall((int)myBody.velocity.y);

    }

    void HandleJumping()
    {

        if (Input.GetButtonDown(TagManager.JUMP_BUTTON))
        {

            if(IsGrounded())
            {
                jumpForce = normal_JumpForce;
                Jump();
            }
            else
            {
                if(canDoubleJump)
                {
                    canDoubleJump = false;
                    jumpForce = double_JumpForce;
                    Jump();
                }
            }

            
        }
    }

    bool IsGrounded()
    {
        /*
        groundCast = Physics2D.Raycast(boxCol2D.bounds.center, Vector2.down, 
                                       boxCol2D.bounds.extents.y + 0.02f, groundMask);

        Debug.DrawRay(boxCol2D.bounds.center, Vector2.down * (boxCol2D.bounds.extents.y + 0.02f), Color.red);
        */
        groundCast = Physics2D.BoxCast(boxCol2D.bounds.center, boxCol2D.bounds.size, 
                                        0f, Vector2.down, 0.04f, groundMask);

        //Debug.DrawRay(boxCol2D.bounds.center + new Vector3(boxCol2D.bounds.extents.x, 0f),
        //               Vector2.down * (boxCol2D.bounds.extents.y + 0.02f), Color.red);          //Right Line
        //Debug.DrawRay(boxCol2D.bounds.center - new Vector3(boxCol2D.bounds.extents.x, 0f),
        //               Vector2.down * (boxCol2D.bounds.extents.y + 0.02f), Color.red);          //Left Line
        //Debug.DrawRay(boxCol2D.bounds.center - new Vector3(boxCol2D.bounds.extents.x, 
        //               boxCol2D.bounds.extents.y + 0.02f),
        //               Vector2.right * (boxCol2D.bounds.size.x), Color.red);          //Left to Right Horizontal Line

        return groundCast.collider != null;


    }

    void Jump()
    {
        myBody.velocity = Vector2.up * jumpForce;
        // OR
        // myBody.velocity = new Vector2(0f, jumpForce);

        jumped = true;
    }

    void CheckToDoubleJump()
    {
        if (!canDoubleJump && myBody.velocity.y == 0f)
            canDoubleJump = true;
    }


    void FromJumpToWalkOrIdle()
    {
        if(jumped && myBody.velocity.y == 0f)
        {
            jumped = false;

            if(Mathf.Abs((int)myBody.velocity.x) > 0f)      //we are walking
            {
                playerAnim.PlayAnimationWithName(TagManager.WALK_ANIMATION_NAME);
            }
            else                                           //we are idle
            {
                playerAnim.PlayAnimationWithName(TagManager.IDLE_ANIMATION_NAME);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag(TagManager.DANGER_TAG))
        {
            AgainPlay();
            Destroy(gameObject);
        }
    }

    void AgainPlay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }












}
