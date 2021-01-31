using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int playerMaxHP;
    public int playerCurrentHP;
    
    public bool takeDamage (int dmg) {
        playerCurrentHP -= dmg;
        if (playerCurrentHP <= 0) {
            return true;
        }
        else {
            return false;
        }
    }

    public void heal (int amount) {
        playerCurrentHP += amount;
        if (playerCurrentHP >= playerMaxHP) {
            playerCurrentHP = playerMaxHP;
        }
    }
}
