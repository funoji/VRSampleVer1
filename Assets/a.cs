using Oculus.Interaction;
using OVRSimpleJSON;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class a : MonoBehaviour
{
    [SerializeField] GameObject aa;
    [SerializeField] BulletManager bulletManager;
    int bb = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
        bb++;

        if (bb % 300 == 0)
        {
            var a = Instantiate(aa);
            bulletManager.AddbulletBox(a);
        }
    }
}
