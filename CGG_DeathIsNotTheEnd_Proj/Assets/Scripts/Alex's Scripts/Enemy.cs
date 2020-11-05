using Fungus;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public Vector2 originalPosition;
    public float agroRange;
    public float attackRange;
    public float moveSpeed;
    Rigidbody2D rb;
    public Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer < attackRange)
        {
            attackPlayer();
        }
        if(distanceToPlayer < agroRange)
        {
            chasePlayer();
        }
        else
        {
            moveToOriginalPosition();
        }

        if (animator != null)
        {
            if (rb.velocity.x > 0.0f)
            {
                animator.SetBool("isMoving", true);
            }
            else
            {
                animator.SetBool("isMoving", false);
            }
        }
    }

    void moveToOriginalPosition()
    {
        if (transform.position.x < originalPosition.x -2)
        {
            rb.velocity = new Vector2(moveSpeed/2, 0);
            transform.localScale = new Vector2(-1, 1);
        }
        else if (transform.position.x > originalPosition.x +2)
        {
            rb.velocity = new Vector2(-moveSpeed/2, 0);
            transform.localScale = new Vector2(1, 1);
        }
    }

    void chasePlayer()
    {
        if(transform.position.x < player.position.x)
        {
            rb.velocity = new Vector2(moveSpeed, 0);
            transform.localScale = new Vector2(-1, 1);
        }
        else
        {
            rb.velocity = new Vector2(-moveSpeed, 0);
            transform.localScale = new Vector2(1, 1);
        }
    }

    void attackPlayer()
    {
        if (animator != null)
        {
            animator.SetTrigger("Attack");

        }
    }
}
