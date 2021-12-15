using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BazziMovement : MonoBehaviour
{
    public Animator animator;

    private float moveSpeed = 2.25f;

    public Rigidbody2D rb;

    public Vector2 movement;
    public float x = -4.25f;
    public float y = 3.25f;
    const int MaxLengthHorizontal = 15;
    const int MaxLengthVertical = 13;

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    void FixedUpdate()
    {
        // rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += transform.right * Time.deltaTime * moveSpeed;
            return;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position -= transform.right * Time.deltaTime * moveSpeed;
            return;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += transform.up * Time.deltaTime * moveSpeed;
            return;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position -= transform.up * Time.deltaTime * moveSpeed;
            return;
        }

    }


    void FreezeHero()
    {
        if (PutBoomSpawn.GetDistanceHeroWithBoom(transform.position) >= 0.5f)
        {
            var rend = this.gameObject.GetComponent<SpriteRenderer>();
            rend.sortingOrder = 4;

        }
    }

    public void UpSpeedHero()
    {
        moveSpeed += 0.5f;
    }
}
