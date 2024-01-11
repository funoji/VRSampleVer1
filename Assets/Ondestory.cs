using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Ondestory : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] Transform pos;

    void Update()
    {
        if (projectilePrefab == null)
        {
            projectilePrefab = Instantiate(projectilePrefab,pos) as GameObject;
        }
    }
}
