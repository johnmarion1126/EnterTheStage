using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public int enemyMaxHP;
    public int enemyCurrentHP;

    public SpriteRenderer spriteRenderer;
    public GameObject enemy;

    public bool takeDamage (int dmg) {
        enemyCurrentHP -= dmg;
        if (enemyCurrentHP <= 0) {
            return true;
        }
        else {
            return false;
        }
    }

    public IEnumerator fadeOut() {
        for (float f = 1f; f >= -0.05f; f -= 0.05f) {
            Color c = spriteRenderer.material.color;
            c.a = f;
            spriteRenderer.material.color = c;
            yield return new WaitForSeconds(0.05f);
        }
        Destroy(enemy);
    }

}
