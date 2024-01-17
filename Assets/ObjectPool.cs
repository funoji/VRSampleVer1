using Oculus.Interaction;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject prefabToPool;
    [SerializeField] int poolSize = 5;
    [SerializeField] GameObject spawn;

    private void Start()
    {
        InitializeObjectPool();
    }

    private void InitializeObjectPool()
    {
        for (int i = 0; i < poolSize; i++)
        {
            CreateNewObject();
        }
    }

    private GameObject CreateNewObject()
    {
        GameObject newObj = Instantiate(prefabToPool,spawn.transform.position, Quaternion.identity);
        newObj.transform.parent = spawn.transform;
        newObj.SetActive(false);

        return newObj;
    }

    public void RepoolObject(GameObject obj)
    {
        Debug.Log("Repooled");
        obj.transform.position = spawn.transform.position;
        obj.transform.rotation = spawn.transform.rotation;
        obj.transform.localScale = Vector3.one * 0.2f;
        obj.GetComponent<Rigidbody>().useGravity = true;
        obj.SetActive(false);
    }

    public GameObject GetPooledObject()
    {
        foreach (Transform child in transform)
        {
            if (!child.gameObject.activeSelf)
            {
                child.gameObject.SetActive(true);
                child.gameObject.transform.position = spawn.transform.position;
                Debug.Log("Getpooled");
                return child.gameObject;
            }
        }

        // プール内で利用可能なオブジェクトがない場合は新しく生成
        return CreateNewObject();
    }
}