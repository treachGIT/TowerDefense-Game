using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEnemy : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        try
        {
            animator = GetComponent<Animator>();
        }
        catch (Exception e)
        {
            Debug.LogException(e, this);
        }

        animator.SetBool("RUN", false);
        animator.SetBool("Victory", true);
    }

}
