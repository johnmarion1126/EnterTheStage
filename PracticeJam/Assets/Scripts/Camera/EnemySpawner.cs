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
            Instantiate(enemyObject1, new Vector3(-30.0f, 1.0f, 0f), Quaternion.identity);
            Instantiate(enemyObject1, new Vector3(-52.0f, -1.5f, 0f), Quaternion.identity);
        }

        if (playerObject.transform.position.x <= -16.0f && playerObject.transform.position.x >= -17.0f && levelPhases == 1) {
            levelPhases += 1;
            Instantiate(enemyObject1, new Vector3(-4.0f, 0.5f, 0f), Quaternion.identity);
            Instantiate(enemyObject1, new Vector3(-26.0f, -1.0f, 0f), Quaternion.identity);
            Instantiate(enemyObject1, new Vector3(4.0f, 1.0f, 0f), Quaternion.identity);
        }

        if (playerObject.transform.position.x <= 10.0f && playerObject.transform.position.x >= 9.0f && levelPhases == 2) {
            levelPhases += 1;
            Instantiate(enemyObject1, new Vector3(22.0f, -0.5f, 0f), Quaternion.identity);
            Instantiate(enemyObject1, new Vector3(0.0f, -1.0f, 0f), Quaternion.identity);
            Instantiate(enemyObject1, new Vector3(30.0f, 1.0f, 0f), Quaternion.identity);
        }

        if (playerObject.transform.position.x <= 40.0f && playerObject.transform.position.x >= 39.0f && levelPhases == 3) {
            levelPhases += 1;
            Instantiate(enemyObject1, new Vector3(52.0f, -2.0f, 0f), Quaternion.identity);
            Instantiate(enemyObject1, new Vector3(28.0f, 1.0f, 0f), Quaternion.identity);
            Instantiate(enemyObject1, new Vector3(23.0f, -1.0f, 0f), Quaternion.identity);
            Instantiate(enemyObject1, new Vector3(61.0f, -2.0f, 0f), Quaternion.identity);
        }

        //TODO: 
        //ADD FIRST BOSS
        //ADD PICKUPS TO INCREASE SCORE
    }
}
