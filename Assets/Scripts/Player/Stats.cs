using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    [SerializeField]
    private int maxHP;
    [SerializeField]
    public int currentHP;
    [SerializeField]
    public int damage;

    [SerializeField]
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private GameObject unit;
    
    public bool takeDamage (int dmg) {
        currentHP -= dmg;
        if (currentHP <= 0) {
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
        yield return new WaitForSeconds(0.25f);
        Destroy(unit);
    }

    public void heal (int amount) {
        currentHP += amount;
        if (currentHP >= maxHP) {
            currentHP = maxHP;
        }
    }
}
