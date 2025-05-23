using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
class ItemData
{
    [Header("Item Prefab")]
    [Tooltip("生成するアイテムのプレハブを設定")]
    public GameObject prefab;

    [Range(0f, 1f)]
    [Tooltip("アイテムの出現率")]
    public float weight = 1f;
}

public class ItemSpawner : MonoBehaviour
{
    [Header("Prefab List with Probability")]
    [Tooltip("プレハブを登録してくださいまた、その確率を設定してください")]
    [SerializeField]
    List<ItemData> itemList = new List<ItemData>();

    [Header("Spawn Settings")]
    [Tooltip("生成間隔")]
    [SerializeField]
    float spawnInterval = 1.0f;

    Coroutine spawanCoroutine;

    private void Start()
    {
        spawanCoroutine = StartCoroutine(SpawnPrefabLoop());
    }

    IEnumerator SpawnPrefabLoop()
    {
        while (true)
        {
            SpawnRandomPrefab();

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnRandomPrefab()
    {
        if (itemList == null || itemList.Count == 0)
        {
            Debug.LogWarning("アイテムリストが空です");
            return;
        }

        float totalWeight = 0f;

        foreach (var item in itemList)
        {
            totalWeight += item.weight;
        }

        float randomValue = Random.Range(0f, totalWeight);
        float currenWeight = 0f;

        foreach (var item in itemList)
        {
            currenWeight += item.weight;
            if (randomValue <= currenWeight)
            {
                Instantiate(item.prefab, transform.position, Quaternion.identity);

                break;
            }
        }
    }

    void StopSpawning()
    {
        if (spawanCoroutine != null)
        {
            StopCoroutine(spawanCoroutine);
            spawanCoroutine = null;
        }
    }
}
