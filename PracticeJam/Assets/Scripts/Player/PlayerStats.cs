using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int playerMaxHP;
    public int playerCurrentHP;
    public int playerDamage;
    
    public void takeDamage (int dmg) {
        playerCurrentHP -= dmg;
        if (playerCurrentHP <= 0) {
            Debug.Log("HP is 0");
        }
    }

    public void heal (int amount) {
        playerCurrentHP += amount;
        if (playerCurrentHP >= playerMaxHP) {
            playerCurrentHP = playerMaxHP;
        }
    }
}
