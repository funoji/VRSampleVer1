using UnityEngine;

public class DestoryTime : MonoBehaviour
{
    void Start()
    {
        // 5�b���DestroyObject���\�b�h���Ăяo��
        Invoke("DestroyObject", 5f);
    }

    void DestroyObject()
    {
        // �I�u�W�F�N�g���A�N�e�B�u�ɂ��邩�A�j������
        gameObject.SetActive(false);
        // �܂��́ADestroy(gameObject);
    }
}
