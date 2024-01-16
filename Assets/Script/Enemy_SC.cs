using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Enemy_SC : MonoBehaviour
{
    public float EnemySpeed = 0.01f;

    public static int ScoreCount = 0;

    private GameObject PlayerPos;
    [HideInInspector]
    public bool ClearFlag = false;
    [SerializeField] AudioClip BreakSE;
    private AudioSource _source;

    void Start()
    {
        _source = GetComponent<AudioSource>();
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
            _source.PlayOneShot(BreakSE);
            ScoreCount++;
            Destroy(this.gameObject);
        }
    }
}
