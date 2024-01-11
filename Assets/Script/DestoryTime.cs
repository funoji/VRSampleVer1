using UnityEngine;

public class DestoryTime : MonoBehaviour
{
    void Start()
    {
        // 5秒後にDestroyObjectメソッドを呼び出す
        Invoke("DestroyObject", 5f);
    }

    void DestroyObject()
    {
        // オブジェクトを非アクティブにするか、破棄する
        gameObject.SetActive(false);
        // または、Destroy(gameObject);
    }
}
