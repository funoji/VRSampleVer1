using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryBullet : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
        }
    }
}
