using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1 : EnemyMovement
{
    public override void Update() {
        Vector3 direction = player.position - transform.position;
        direction.Normalize();
        movement = direction;

        if (damaged < damagedDuration) damaged += Time.deltaTime;
        if (inRange && !inAction && damaged >= damagedDuration) StartCoroutine(delayCall());
        checkInRange();
    }
    //TODO: ADD SOME NEW MECHANIC FOR BOSS
    //TODO: SPAWN NEW ENEMY AT THE END
    //TODO: ADD A NEW SCRIPT FOR NEW ENEMY
    //TODO: ADD A SAVE SYSTEM TO KEEP SCORE AND HP TO NEXT LEVELS

}
