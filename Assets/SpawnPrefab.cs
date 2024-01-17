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
        // オブジェクトプールからプレハブを取得
        GameObject spawnedObject = objectPool.GetPooledObject();

        if (spawnedObject != null)
        {
            // プレハブを適切な位置に配置
            spawnedObject.transform.position = transform.position;

            // プレハブをアクティブにする
            spawnedObject.SetActive(true);
        }
    }
}