using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_SC : MonoBehaviour
{
    [SerializeField]
    [Header("Playerをアタッチ")]
    private GameObject target;
    public float EnemySpeed = 0.01f;

    public static int ScoreCount = 0;

    private Vector3 PlayerPosition;
    private Vector3 EnemyPosition;


    void Start()
    {

    }

    void Update()
    {
        Quaternion lookRotation = Quaternion.LookRotation(target.transform.position - transform.position, Vector3.up);

        lookRotation.z = 0;
        lookRotation.x = 0;

        transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, 0.1f);

        Vector3 p = new Vector3(0f, 0f, EnemySpeed);

        transform.Translate(p);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            Destroy(this.gameObject);
            ScoreCount++;
        }
    }
}
