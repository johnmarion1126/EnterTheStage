using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject playerObject;
    [SerializeField]
    private GameObject enemyObject1;
    [SerializeField]
    private GameObject enemyObject2;

    private int levelPhases = 0;

    void Update()
    {
        if (playerObject.transform.position.x <= -42.0f && playerObject.transform.position.x >= -43.0f && levelPhases == 0) {
            levelPhases += 1;
            Instantiate(enemyObject1, new Vector3(-32.0f, 1.0f, 0f), Quaternion.identity);
            //Instantiate(enemyObject1, new Vector3(-32.0f, -1.5f, 0f), Quaternion.identity);
        }

        //TODO: ADD A COLLIDER FOR ENEMIES FOR OTHER ENEMIES
        //TODO: ADD PICKUPS TO INCREASE SCORE
    }
}
