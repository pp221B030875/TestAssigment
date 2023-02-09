using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
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
