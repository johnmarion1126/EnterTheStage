using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public int enemyMaxHP;
    public int enemyCurrentHP;

    public bool takeDamage (int dmg) {
        enemyCurrentHP -= dmg;
        if (enemyCurrentHP <= 0) {
            return true;
        }
        else {
            return false;
        }
    }

}
