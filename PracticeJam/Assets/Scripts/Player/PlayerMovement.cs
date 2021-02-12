using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rigidBody;
    [SerializeField]
    private Animator animator;

    [SerializeField]
    private Stats playerStats;
    [SerializeField]
    private GameObject playerObject;
    [SerializeField]
    private BoxCollider2D playerAttack;
    [SerializeField]
    private HP playerHP;
    [SerializeField]
    private Score playerScore;

    [SerializeField]
    private GameObject enemyObject;
    [SerializeField]
    private float moveSpeed = 5f; 
    
    private bool inAction = false;
    private bool isDead = false;
    private Vector2 movement;

    void Awake() {
        playerStats = playerObject.GetComponent<Stats>();
        playerHP = playerHP.GetComponent<HP>();
        playerScore = playerScore.GetComponent<Score>();
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void Start() {
        playerHP.setHP(playerStats.currentHP);
        playerScore.setScore(0);
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
                playerObject.transform.rotation = Quaternion.Euler(new Vector3(0,0,0));
            }
            else if (movement.x == -1) {
                animator.Play("HeroWalk");
                playerObject.transform.rotation = Quaternion.Euler(new Vector3(0,180,0));
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

    void OnTriggerEnter2D(Collider2D enemyObject) {
        if (enemyObject.name == "EnemyAttack" && !isDead) StartCoroutine(takeDamage());
    }

    IEnumerator heroAction(string action) {
        inAction = true;
        animator.Play(action);

        playerAttack.size = new Vector2(1.5f,0.1f);
        yield return new WaitForSeconds(0.3f);
        playerAttack.size = new Vector2(0.0001f,0.0001f);
        
        inAction = false;
    }

    IEnumerator takeDamage() {
        inAction = true;
        playerHP.removeHP(1);
        isDead = playerStats.takeDamage(1);

        if (isDead) {
            animator.Play("HeroFaint");
            StartCoroutine(playerStats.fadeOut());
        }
        else {
            animator.Play("HeroHurt");
            yield return new WaitForSeconds(0.3f);
            inAction = false;
        }
    }

}
