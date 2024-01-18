using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearSE : MonoBehaviour
{
    [SerializeField] private AudioClip Clear;
    private AudioSource _source;
    private bool flag = false;
    // Start is called before the first frame update
    void Start()
    {
        _source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (SpawnEnemy.ClearFlag)
        {
            if (flag == false)
            {
                _source.PlayOneShot(Clear);
                flag = true;
            }

        }
    }
}
