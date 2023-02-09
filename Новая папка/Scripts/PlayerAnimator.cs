using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private PlayerController controller;
    private Animator animator;

    private void Start()
    {
        controller = GetComponent<PlayerController>();
        animator = GetComponent<Animator>();
    }

    public void IsWalk()
    {
        animator.SetBool("isWalk", true);
    }

    public void NotWalk()
    {
        animator.SetBool("isWalk", false);
    }
}
