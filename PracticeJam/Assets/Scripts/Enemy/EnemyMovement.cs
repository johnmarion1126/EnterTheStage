using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform player;
    public GameObject playerObject;
    private Vector2 movement;

    private Rigidbody2D rigidbodyEnemy;
    public Animator animatorEnemy;
    public SpriteRenderer spriteRendererEnemy;

    public float moveEnemySpeed = 2f;
    private bool inAction = false;
    private bool inRange = false;

    void Start() {
        rigidbodyEnemy = GetComponent<Rigidbody2D>();
        animatorEnemy = GetComponent<Animator>();
        playerObject = GetComponent<GameObject>();
    }

    void Update() {
        Vector3 direction = player.position - transform.position;
        direction.Normalize();
        movement = direction;

        if (inRange && !inAction) {
            inAction = true;
            rigidbodyEnemy.constraints = RigidbodyConstraints2D.FreezeAll;
            StartCoroutine(attackPlayer());
        }
        
    }

    private void FixedUpdate() {
        if (!inAction) moveEnemy(movement);
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

    void OnTriggerEnter2D(Collider2D playerObject) {
        inRange = true;
    }

    void OnTriggerExit2D(Collider2D playerObject) {
        inRange = false;
    }

    IEnumerator attackPlayer() {

        if (Random.Range(1,3) == 1) {
            Debug.Log("Punch");
            animatorEnemy.Play("BasicEnemyPunch");
        }
        else {
            Debug.Log("Jab");
            animatorEnemy.Play("BasicEnemyJab");
        }

        yield return new WaitForSeconds(0.3f);

        inAction = false;
        rigidbodyEnemy.constraints = RigidbodyConstraints2D.None;
        rigidbodyEnemy.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

}
