using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField]
    [Header("��������GameObject")]
    private GameObject createPrefab;
    [SerializeField]
    [Header("��������͈�A")]
    private Transform rangeA;
    [SerializeField]
    [Header("��������͈�B")]
    private Transform rangeB;
    [SerializeField]
    [Header("���������Ԋu")]
    private float spawnTime = 1.0f;
    [SerializeField] private TextMeshProUGUI TMpro;

    // �o�ߎ���
    private float time;
    public static int Enemy_Count = 15;
    private int Count = 0;

    private void Start()
    {
        TMpro.enabled = false;
    }

    void Update()
    {
        time = time + Time.deltaTime;

        if (time > spawnTime && Count < Enemy_Count)
        {
            float x = Random.Range(rangeA.position.x, rangeB.position.x);

            float y = Random.Range(rangeA.position.y, rangeB.position.y);

            float z = Random.Range(rangeA.position.z, rangeB.position.z);

            Instantiate(createPrefab, new Vector3(x, 2f, z), createPrefab.transform.rotation);
            Count++;

            time = 0f;
        }
        if(Count == Enemy_Count)
        {
            TMpro.enabled = true;
        }
    }
}