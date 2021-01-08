using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    public float moveSpeed = 5f; 
    public Rigidbody2D rigidBody;
    public Animator animator;
    public SpriteRenderer spriteRenderer;


    Vector2 movement;

    void Start() {
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update() {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (movement.x == 1) {
            animator.Play("HeroWalk");
            spriteRenderer.flipX = false;
        }
        else if (movement.x == -1) {
            animator.Play("HeroWalk");
            spriteRenderer.flipX = true;
        }
        else if (Input.GetKey("z")) {
            animator.Play("HeroPunch");
            Debug.Log("Punch");
        }
        else if (Input.GetKey("x")) {
            animator.Play("HeroJab");
            Debug.Log("Jab");
        }
        else {
            animator.Play("HeroIdle");
        }

    }

    void FixedUpdate() {
        rigidBody.MovePosition(rigidBody.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
    
}
