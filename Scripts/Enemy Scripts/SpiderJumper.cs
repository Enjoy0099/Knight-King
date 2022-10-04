using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderJumper : MonoBehaviour
{
    private Animator anim;
     
    private Rigidbody2D mybody;

    [SerializeField]
    private float minForce=5f, maxForce=10f;

    private float jumpForce;
    private float jumpTimer;

    [SerializeField]
    private float minTimer = 2f, maxTimer = 5f;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        mybody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        jumpTimer = Time.time + Random.Range(minTimer, maxTimer);
    }

    private void Update()
    {
        if (Time.time > jumpTimer)
            SpiderJump();
        if (mybody.velocity.y == 0f)
            anim.SetBool(TagManager.JUMP_ANIMATION_PARAM, false);
    }

    void SpiderJump()
    {
        jumpTimer = Time.time + Random.Range(minTimer, maxTimer);
        jumpForce = Random.Range(minForce, maxForce);
        mybody.velocity = new Vector2(0f, jumpForce);
        anim.SetBool(TagManager.JUMP_ANIMATION_PARAM, true);
    }

}
