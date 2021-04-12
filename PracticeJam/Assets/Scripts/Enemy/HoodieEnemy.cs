using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoodieEnemy : EnemyMovement
{
    [SerializeField]
    private GameObject dogObject;
    private int callOnce = 0;

    public override void Update() {
        Vector3 direction = player.position - transform.position;
        direction.Normalize();
        movement = direction;

        if (isDead && callOnce == 0) {
            callOnce += 1;
            StartCoroutine(spawnDog());
        }
        if (damaged < damagedDuration) damaged += Time.deltaTime;
        if (inRange && !inAction && damaged >= damagedDuration) StartCoroutine(delayCall());
        checkInRange();
    }

    private IEnumerator spawnDog() {
        yield return new WaitForSeconds(1.0f);
        Instantiate(dogObject, 
        new Vector3(enemyObject.transform.position.x, enemyObject.transform.position.y, 0f),
        Quaternion.identity);
    }
}
