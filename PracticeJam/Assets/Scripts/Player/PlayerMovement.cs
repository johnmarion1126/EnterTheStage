using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    public Rigidbody2D rigidBody;
    public Animator animator;
    public SpriteRenderer spriteRenderer;

    public float moveSpeed = 5f; 
    private bool inAction = false;

    Vector2 movement;

    void Start() {
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update() {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (!inAction) {

            if (movement.y != 0) {
                animator.Play("HeroWalk");
            }
            else if (movement.x == 1) {
                animator.Play("HeroWalk");
                spriteRenderer.flipX = false;
            }
            else if (movement.x == -1) {
                animator.Play("HeroWalk");
                spriteRenderer.flipX = true;
            }
            else {
                animator.Play("HeroIdle");
            }

            if (Input.GetKey("z")) {
                StartCoroutine(heroAction("HeroPunch"));
            }
            if (Input.GetKey("x")) {
                StartCoroutine(heroAction("HeroJab"));
            }

            rigidBody.MovePosition(rigidBody.position + movement * moveSpeed * Time.fixedDeltaTime);
        }  
    }

    IEnumerator heroAction(string action) {
        inAction = true;
        animator.Play(action);
        yield return new WaitForSeconds(0.3f);
        inAction = false;
    }
 
}
