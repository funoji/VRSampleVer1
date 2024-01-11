using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCube : MonoBehaviour
{
    [SerializeField] GameObject cube;
    void Update()
    {
        if (!cube)
        {
            Instantiate(cube);
        }
    }
}
