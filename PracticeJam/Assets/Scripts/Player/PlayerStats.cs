using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public int playerMaxHP;
    public int playerCurrentHP;

    public SpriteRenderer spriteRenderer;
    public GameObject player;
    
    public bool takeDamage (int dmg) {
        playerCurrentHP -= dmg;
        if (playerCurrentHP <= 0) {
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
    }

    public void heal (int amount) {
        playerCurrentHP += amount;
        if (playerCurrentHP >= playerMaxHP) {
            playerCurrentHP = playerMaxHP;
        }
    }
}
