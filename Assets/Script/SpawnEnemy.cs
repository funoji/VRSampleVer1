using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField]
    [Header("生成するGameObject")]
    private GameObject createPrefab;
    [SerializeField]
    [Header("生成する範囲A")]
    private Transform rangeA;
    [SerializeField]
    [Header("生成する範囲B")]
    private Transform rangeB;
    [SerializeField]
    [Header("生成される間隔")]
    private float spawnTime = 1.0f;

    // 経過時間
    private float time;
    public static int Enemy_Count = 15;

    void Update()
    {
        time = time + Time.deltaTime;

        for (int Count = Enemy_Count; Count > 0; Count--)
        {
            Debug.Log("Spawn!!222");
            Debug.Log(Count);
            if (time > spawnTime && Count > 0)
            {
                float x = Random.Range(rangeA.position.x, rangeB.position.x);

                float y = Random.Range(rangeA.position.y, rangeB.position.y);

                float z = Random.Range(rangeA.position.z, rangeB.position.z);

                Instantiate(createPrefab, new Vector3(x, 2f, z), createPrefab.transform.rotation);
                Debug.Log("Spawn!!");

                time = 0f;
            }
        }
    }
}
