using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    private Animator anim;

    private SpriteRenderer sr;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    public void PlayWalk(int walk)
    {
        anim.SetInteger(TagManager.WALK_ANIMATION_PARAM, walk);
    }

    public void ChangeFacingDirection(int direction)
    {
        
        if (direction > 0)
            sr.flipX = false;
        else if (direction < 0)
            sr.flipX = true;  
    }


    public void PlayJumpAndFall(int jumpFall)
    {
        anim.SetInteger(TagManager.JUMP_ANIMATION_PARAM, jumpFall);
    }

    public void PlayAnimationWithName(string animName)
    {
        anim.Play(animName);
    }

}
