using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1 : EnemyMovement
{
    public override void Update() {
        Vector3 direction = player.position - transform.position;
        direction.Normalize();
        movement = direction;

        if (damaged < 0.5f) damaged += Time.deltaTime;
        if (inRange && !inAction && damaged >= 0.5f) StartCoroutine(delayCall());
        checkInRange();
    }
}
