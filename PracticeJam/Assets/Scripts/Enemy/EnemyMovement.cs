using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform player;
    private Rigidbody2D rigidbodyEnemy;
    private Vector2 movement;

    public float moveEnemySpeed = 2f;

    void Start() {
        rigidbodyEnemy = GetComponent<Rigidbody2D>();
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
        rigidbodyEnemy.MovePosition((Vector2)transform.position + (Vector2)(direction * moveEnemySpeed * Time.deltaTime));
    }


}
