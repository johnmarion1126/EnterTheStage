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

    private int numberOfEnemies = 0;
    private float playerPosition;
    private float startingPosition;
    private float differenceInPosition;
    private Vector3 spawnPosition;

    void Start() {
        startingPosition = playerObject.transform.position.x;
    }

    void Update()
    {
        playerPosition = playerObject.transform.position.x;
        differenceInPosition = Mathf.Abs(startingPosition - playerPosition);

        if (differenceInPosition >= 30.0f) {
            differenceInPosition = 0.0f;
            startingPosition = playerPosition;
            StartCoroutine(spawnEnemies());
        }
    }

    IEnumerator spawnEnemies() {
        numberOfEnemies += 1;
        for (int i = 0; i < numberOfEnemies; i++) {
            if (i % 2 == 0) spawnPosition = new Vector3(Random.Range(playerPosition+10.0f,playerPosition+15.0f),Random.Range(-2.0f,1.5f), 0f);
            else spawnPosition = new Vector3(Random.Range(playerPosition-8.0f,playerPosition-12.0f),Random.Range(-2.0f,1.5f), 0f);
            Instantiate(enemyObject1, spawnPosition, Quaternion.identity);

            if (i % 2 == 1) yield return new WaitForSeconds(2.0f);
        }
    }
}
