using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayKillEnemySound : MonoBehaviour
{
    [SerializeField]private AudioClip m_AudioClip;
    private AudioSource _sorce;

    // Start is called before the first frame update
    void Start()
    {
        _sorce = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            _sorce.PlayOneShot(m_AudioClip);
        }
    }
}
