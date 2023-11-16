using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menu : MonoBehaviour
{
    [SerializeField] GameObject menuObj;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            GoInMenu();
        }
    }
    void GoInMenu()
    {
        menuObj.GetComponent<Rigidbody>().useGravity = true;
        Invoke("DestroyMenu", 5f);
    }

    void DestoryMenu()
    {
        Destroy(menuObj);
    }
}
