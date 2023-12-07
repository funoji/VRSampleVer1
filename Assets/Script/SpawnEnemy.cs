using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField]
    [Header("¶¬‚·‚éGameObject")]
    private GameObject createPrefab;
    [SerializeField]
    [Header("¶¬‚·‚é”ÍˆÍA")]
    private Transform rangeA;
    [SerializeField]
    [Header("¶¬‚·‚é”ÍˆÍB")]
    private Transform rangeB;
    [SerializeField]
    [Header("¶¬‚³‚ê‚éŠÔŠu")]
    private float spawnTime = 1.0f;
    [SerializeField] private TextMeshProUGUI _text;

    // Œo‰ßŽžŠÔ
    private float time;
    public static int Enemy_Count = 10;
    public static int Count = 0;
    [SerializeField]private Enemy_SC _enem;

    public static bool IsSpawn = false;

    private void Start()
    {
        _text.gameObject.SetActive(false);
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
            IsSpawn = true;
        }
        if (Enemy_SC.ScoreCount==Enemy_Count)
        {
            _text.gameObject.SetActive(true);
        }
    }
}
