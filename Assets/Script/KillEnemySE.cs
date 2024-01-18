using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEnemySE : MonoBehaviour
{
    [SerializeField] private AudioClip KillEnemy;
    private AudioSource _source;
    void Start()
    {
        _source=GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            _source.PlayOneShot(KillEnemy);
        }
    }
}
