using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody2D rigidbodyEnemy;
    public Animator animatorEnemy;
    public SpriteRenderer spriteRendererEnemy;

    public GameObject enemyObject;
    public BoxCollider2D enemyAttack;

    public GameObject playerObject;

    public Transform player;
    private Vector2 movement;

    public float moveEnemySpeed = 2f;
    private bool inAction = false;
    private bool inRange = false;

    void Start() {
        rigidbodyEnemy = GetComponent<Rigidbody2D>();
        animatorEnemy = GetComponent<Animator>();
    }

    void Update() {
        Vector3 direction = player.position - transform.position;
        direction.Normalize();
        movement = direction;

        if (inRange && !inAction) StartCoroutine(attackPlayer());
    }

    private void FixedUpdate() {
        if (!inAction) moveEnemy(movement);
    }

    void moveEnemy(Vector2 direction) {
        if (direction.x > 0) {
            enemyObject.transform.rotation = Quaternion.Euler(new Vector3(0,0,0));
        }
        else {
            enemyObject.transform.rotation = Quaternion.Euler(new Vector3(0,180,0));
        }

        if (direction.y > 0.01f) {
            spriteRendererEnemy.sortingOrder = 3;
        }
        else {
            spriteRendererEnemy.sortingOrder = 1;
        }

        animatorEnemy.Play("BasicEnemyWalk");
        rigidbodyEnemy.MovePosition((Vector2)transform.position + (Vector2)(direction * moveEnemySpeed * Time.deltaTime));
    }

    void OnTriggerEnter2D(Collider2D playerObject) {
        inRange = true;
        if (playerObject.name == "PlayerAttack") StartCoroutine(takeDamage());
    }

    void OnTriggerExit2D(Collider2D playerObject) {
        inRange = false;
    }

    IEnumerator attackPlayer() {
        inAction = true;
        rigidbodyEnemy.constraints = RigidbodyConstraints2D.FreezeAll;

        if (Random.Range(1,3) == 1) {
            animatorEnemy.Play("BasicEnemyPunch");
        }
        else {
            animatorEnemy.Play("BasicEnemyJab");
        }
        
        enemyAttack.size = new Vector2(1.5f,0.5f);
        yield return new WaitForSeconds(0.3f);
        enemyAttack.size = new Vector2(0.0001f,0.0001f);
        
        rigidbodyEnemy.constraints = RigidbodyConstraints2D.None;
        rigidbodyEnemy.constraints = RigidbodyConstraints2D.FreezeRotation;
        inAction = false;
    }

    IEnumerator takeDamage() {
        inAction = true;
        animatorEnemy.Play("BasicEnemyHurt");
        yield return new WaitForSeconds(0.3f);
        inAction = false;
    }

}
