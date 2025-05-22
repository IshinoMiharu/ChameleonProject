using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemData
{
    [Header("Item Prefab")]
    [Tooltip("��������A�C�e���̃v���n�u��ݒ�")]
    public GameObject prefab;

    [Range(0f, 1f)]
    [Tooltip("�A�C�e���̏o����")]
    public float weight = 1f;
}

public class ItemSpawner : MonoBehaviour
{
    [Header("Prefab List with Probability")]
    [Tooltip("�v���n�u��o�^���Ă��������܂��A���̊m����ݒ肵�Ă�������")]
    public List<ItemData> itemList = new List<ItemData>();

    [Header("Spawn Settings")]
    [Tooltip("�����Ԋu�̍ŏ��l")]
    public float minSpawnInterval = 1.0f;

    [Header("Spawn Settings")]
    [Tooltip("�����Ԋu�̍ő�l")]
    public float maxSpawnInterval = 1.0f;

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

            float witTime = Random.Range(minSpawnInterval, maxSpawnInterval);

            yield return new WaitForSeconds(witTime);
        }
    }

    void SpawnRandomPrefab()
    {
        if (itemList == null || itemList.Count == 0)
        {
            Debug.LogWarning("�A�C�e�����X�g����ł�");
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
