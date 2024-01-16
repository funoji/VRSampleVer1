using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayGameClearSE : MonoBehaviour
{
    [SerializeField] private AudioClip ClearSE;
    private AudioSource _source;
    void Start()
    {
        _source.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (SpawnEnemy.ClearFlag == true)
        {
            _source.PlayOneShot(ClearSE);
        }
    }
}
