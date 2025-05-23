using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrapInstantiate : MonoBehaviour
{
    [Tooltip("ê∂ê¨ä‘äu")]
    [SerializeField] float spawnInterval;

    [SerializeField] GameObject enemyTrapPrefab;

    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(spawnInterval);
        Instantiate(enemyTrapPrefab, transform.position, Quaternion.identity);
    }
}
