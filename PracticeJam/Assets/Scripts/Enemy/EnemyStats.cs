using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public int enemyMaxHP;
    public int enemyCurrentHP;
    public int enemyDamage;

    public void takeDamage (int dmg) {
        enemyCurrentHP -= dmg;
        if (enemyCurrentHP <= 0) {
            Debug.Log("HP is 0");
        }
    }

}
