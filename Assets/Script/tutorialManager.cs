using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class tutorialManager : MonoBehaviour
{
    [SerializeField] BulletManager bulletManager;
    [SerializeField] TextMeshProUGUI pinchText;
    [SerializeField] TextMeshPro ShootText;
    bool pinched = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(bulletManager.GetBulletCountL());
        if (bulletManager.GetBulletCountL() > 0 && bulletManager.GetBulletCountR() > 0 && !pinched)
        {
            pinchText.enabled = false;
            ShootText.enabled = true;
        }
    }
}
