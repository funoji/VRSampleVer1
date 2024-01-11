using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Ondestory : MonoBehaviour
{
    [SerializeField] GameObject cube;
    [SerializeField] GameObject SpawnPoint;
    private void OnDestroy()
    {
        Instantiate(cube, SpawnPoint.transform.position, Quaternion.identity);
    }
}