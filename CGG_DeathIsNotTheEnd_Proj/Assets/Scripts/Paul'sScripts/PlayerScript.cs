﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rb;
    public Animator animator;
    public bool facingLeft;
    public float speed, jumpForce = 50, gCRadious;
    public Transform GroundPos;
    public LayerMask Groundz;
    public bool canMove;

    public PlayerScript pScript;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pScript = GetComponent<PlayerScript>();
        canMove = true;
    }

    public void Update()
    {
        if(canMove == true)
        {
            Collider2D isGrounded = Physics2D.OverlapCircle(GroundPos.position, gCRadious, Groundz);

            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");
            float xRaw = Input.GetAxisRaw("Horizontal");
            float yRaw = Input.GetAxisRaw("Vertical");

            Vector2 dir = new Vector2(x, y);

            Running(dir);

            if (animator != null)
            {
                if (dir.x == 0f)
                {
                    animator.SetBool("isMoving", false);
                }
                else
                {
                    animator.SetBool("isMoving", true);
                }

                animator.SetBool("Grounded", isGrounded);
            }


            if (dir.x > 0.0f)
            {
                if (facingLeft) Flip();
            }
            else if (dir.x < 0.0f)
            {
                if (!facingLeft) Flip();
            }

            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                rb.velocity = new Vector2(rb.velocity.y, 0);
                rb.velocity += Vector2.up * jumpForce;
                //animator.SetTrigger("Jump");

            }
            
        }

        else if(canMove == false)
        {
            rb.velocity = Vector2.zero;
            animator.SetBool("isMoving", false);
        }


    }

    public void Flip()
    {
        facingLeft = !facingLeft;
        transform.Rotate(0f, 180f, 0f);
    }

    private void Running(Vector2 dir)
    {
           rb.velocity = (new Vector2(dir.x * speed, rb.velocity.y));    

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(GroundPos.position, gCRadious);
    }

    public void StopPlayer()
    {
        //pScript.enabled = false;
        canMove = false;
        Debug.Log("Player has stopped moving");
    }

    public void MovePlayer()
    {
        // pScript.enabled = true;
        canMove = true;
        Debug.Log("Player has continued moving");
    }

}
