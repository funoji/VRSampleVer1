using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class tutorialManager : MonoBehaviour
{
    [SerializeField] ActiveStateSelector State;
    [SerializeField] TextMeshProUGUI pinchText;
    [SerializeField] GameObject ShootText;
    [SerializeField] GameObject BulletBox;
    bool pinched = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(State.ReadBulletCnt);
        if (!BulletBox)
        {
            pinchText.enabled = false;
            ShootText.SetActive(true);
        }
    }
}
