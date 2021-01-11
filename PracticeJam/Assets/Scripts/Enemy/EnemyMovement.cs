using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform player;
    private Vector2 movement;

    private Rigidbody2D rigidbodyEnemy;
    public Animator animatorEnemy;
    public SpriteRenderer spriteRendererEnemy;

    public float moveEnemySpeed = 2f;

    void Start() {
        rigidbodyEnemy = GetComponent<Rigidbody2D>();
        animatorEnemy = GetComponent<Animator>();
    }

    void Update() {
        Vector3 direction = player.position - transform.position;
        direction.Normalize();
        movement = direction;
    }

    private void FixedUpdate() {
        moveEnemy(movement);
    }

    void moveEnemy(Vector2 direction) {
        
        if (direction.x > 0) {
            spriteRendererEnemy.flipX = false;
        }
        else {
            spriteRendererEnemy.flipX = true;
        }

        animatorEnemy.Play("BasicEnemyWalk");
        rigidbodyEnemy.MovePosition((Vector2)transform.position + (Vector2)(direction * moveEnemySpeed * Time.deltaTime));
    }

}
