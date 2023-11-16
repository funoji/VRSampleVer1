using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InGameUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI Num;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Num.text = "" + (SpawnEnemy.Enemy_Count - Enemy_SC.ScoreCount);
    }
}
