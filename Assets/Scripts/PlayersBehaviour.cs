using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersBehaviour : MonoBehaviour
{
    public Animator animator; // Reference to the Animator component
    public float changeInterval = 2f; // Time interval in seconds to change direction
    public int newDirection = 1;
    private float timeSinceLastChange = 0f;

    void Start()
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }

        ChangeDirection();
    }

    void Update()
    {
        timeSinceLastChange += Time.deltaTime;
        if (timeSinceLastChange >= changeInterval)
        {
            ChangeDirection();
            timeSinceLastChange = 0f;
        }
    }

    void ChangeDirection()
    {
        newDirection *= -1;
        animator.SetInteger("Direction", newDirection);
    }
}
