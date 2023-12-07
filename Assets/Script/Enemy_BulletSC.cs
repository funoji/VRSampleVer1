using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_BulletSC : MonoBehaviour
{
    [SerializeField] GameObject Enemy_Red;
    [SerializeField]
    [Header("¶¬‚·‚é”ÍˆÍA")]
    private Transform rangeA;
    [SerializeField]
    [Header("¶¬‚·‚é”ÍˆÍB")]
    private Transform rangeB;
    [SerializeField]
    [Header("¶¬‚³‚ê‚éŠÔŠu")]
    private float spawnTime = 1.0f;
    public float EnemySpeed = 0.01f;

    private float time;
    private GameObject PlayerPos;
    void Start()
    {
        PlayerPos = GameObject.Find("GameOverArea");
    }

    // Update is called once per frame
    void Update()
    {
        time = time + Time.deltaTime;

        if (time > spawnTime)
        {
            float x = Random.Range(rangeA.position.x, rangeB.position.x);

            float y = Random.Range(rangeA.position.y, rangeB.position.y);

            float z = Random.Range(rangeA.position.z, rangeB.position.z);

            GameObject obj =Instantiate(Enemy_Red, new Vector3(x, 5f, z), Enemy_Red.transform.rotation);

            time = 0f;
        }

    }
}
