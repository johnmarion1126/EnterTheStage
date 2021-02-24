using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour, IDamageable
{
    [SerializeField]
    private Rigidbody2D rigidbodyEnemy;
    [SerializeField]
    private Animator animatorEnemy;
    [SerializeField]
    private SpriteRenderer spriteRendererEnemy;

    [SerializeField]
    private Stats enemyStats;
    [SerializeField]
    private GameObject enemyObject;
    [SerializeField]
    private BoxCollider2D enemyAttack;
    [SerializeField]
    protected List <string> enemyAnimations;

    [SerializeField]
    private GameObject playerObject;
    [SerializeField]
    protected Transform player;
    [SerializeField]
    protected Vector2 movement;

    [SerializeField]
    protected float moveEnemySpeed = 2f;
    [SerializeField]
    protected float attackDuration;
    [SerializeField]
    protected int points;

    protected GameObject HPScore;
    protected GameObject scoreObject;
    protected Score score;

    protected int damage;
    protected float damaged = 0.5f;
    protected float range = 2.0f;
    protected bool inAction = false;
    protected bool inRange = false;
    protected bool isDead = false;

    protected void Awake() {
        enemyStats = enemyObject.GetComponent<Stats>();
        rigidbodyEnemy = GetComponent<Rigidbody2D>();
        animatorEnemy = GetComponent<Animator>();
        HPScore = GameObject.Find("HP&Score");
        playerObject = GameObject.Find("Player");
        player = playerObject.GetComponent<Transform>();
    }

    protected void Start() {
        scoreObject = HPScore.transform.GetChild(2).gameObject;
        score = HPScore.GetComponent<Score>();
        damage = playerObject.GetComponent<Stats>().damage;
    }

    public virtual void Update() {
        Vector3 direction = player.position - transform.position;
        direction.Normalize();
        movement = direction;

        if (damaged < 0.5f) damaged += Time.deltaTime;
        if (inRange && !inAction && damaged >= 0.5f) StartCoroutine(delayCall());
        checkInRange();
    }

    protected void FixedUpdate() {
        if (!inAction && damaged >= 0.5f) moveEnemy(movement);
    }

    protected void moveEnemy(Vector2 direction) {
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

        animatorEnemy.Play(enemyAnimations[0]);
        rigidbodyEnemy.MovePosition((Vector2)transform.position + (Vector2)(direction * moveEnemySpeed * Time.deltaTime));
    }

    protected void checkInRange() {
        if (Vector3.Distance(player.position, transform.position) >= range) {
            inRange = false;
            rigidbodyEnemy.constraints = RigidbodyConstraints2D.None;
            rigidbodyEnemy.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }

    protected void OnTriggerEnter2D(Collider2D playerObject) {
        inRange = true;
        rigidbodyEnemy.constraints = RigidbodyConstraints2D.FreezeAll;
        if (playerObject.name == "PlayerAttack" && !isDead) StartCoroutine(takeDamage(damage));
    }

    protected IEnumerator delayCall() {
        inAction = true;
        animatorEnemy.Play(enemyAnimations[1]);
        yield return new WaitForSeconds(0.5f);
        if (inRange && damaged >= 0.5f) StartCoroutine(attackPlayer());
        else inAction = false;
    }

    protected IEnumerator attackPlayer() {

        if (Random.Range(1,3) == 1) {
            animatorEnemy.Play(enemyAnimations[4]);
        }
        else {
            animatorEnemy.Play(enemyAnimations[5]);
        }
        
        enemyAttack.size = new Vector2(1.5f,0.1f);
        yield return new WaitForSeconds(attackDuration);
        enemyAttack.size = new Vector2(0.0001f,0.0001f);
        
        inAction = false;
    }

    public IEnumerator takeDamage(int amount) {
        damaged = 0f;
        isDead = enemyStats.takeDamage(amount);

        if (isDead) {
            animatorEnemy.Play(enemyAnimations[2]);
            damaged = -1f;
            score.increaseScore(points);
            StartCoroutine(enemyStats.fadeOut());
        }
        else {
            animatorEnemy.Play(enemyAnimations[3]);
            yield return new WaitForSeconds(0.2f);
        }
    }

}
