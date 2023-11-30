using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Enemy_SC : MonoBehaviour
{
    [SerializeField]
    [Header("Playerをアタッチ")]
    private GameObject target;
    public float EnemySpeed = 0.01f;

    public static int ScoreCount = 0;

    private GameObject PlayerPos;
    public bool ClearFlag = false;


    void Start()
    {
        PlayerPos = GameObject.Find("GameOverArea");
    }

    void Update()
    {
        Quaternion lookRotation = Quaternion.LookRotation(PlayerPos.transform.position - transform.position, Vector3.up);

        lookRotation.z = 0;
        lookRotation.x = 0;

        transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, 0.1f);

        Vector3 p = new Vector3(0f, 0f, EnemySpeed * Time.deltaTime);

        transform.Translate(p);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            Destroy(this.gameObject);
            Debug.Log("Score="+ScoreCount);
            Debug.Log("EnemyCount=" + SpawnEnemy.Enemy_Count);
            ScoreCount++;
        }
    }
}
