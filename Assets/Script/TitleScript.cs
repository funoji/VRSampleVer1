using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScript : MonoBehaviour
{
    [SerializeField] GameObject titleObj;
    [SerializeField] GameObject MenuObj;
    [SerializeField] Transform objPos;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            GoInMenu();
        }
    }
    void GoInMenu()
    {
        titleObj.GetComponent<Rigidbody>().useGravity = true;
        Destroy(titleObj);
        CreateManu();
    }
    void CreateManu()
    {
        GameObject newObj = Instantiate(MenuObj,objPos);
    }
}
