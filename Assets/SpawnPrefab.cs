using Unity.VisualScripting;
using UnityEngine;

public class SpawnPrefab : MonoBehaviour
{
    [SerializeField] ObjectPool objectPool;

    void Start()
    {
        SpawnObject();
    }

    void SpawnObject()
    {
        // �I�u�W�F�N�g�v�[������v���n�u���擾
        GameObject spawnedObject = objectPool.GetPooledObject();

        if (spawnedObject != null)
        {
            // �v���n�u��K�؂Ȉʒu�ɔz�u
            spawnedObject.transform.position = transform.position;

            // �v���n�u���A�N�e�B�u�ɂ���
            spawnedObject.SetActive(true);
        }
    }
}