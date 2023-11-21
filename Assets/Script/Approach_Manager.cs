using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Approach_Manager : MonoBehaviour
{
    [SerializeField] private Image WarningPanel;
    void Start()
    {
        
    }

    void Update()
    {
        if (EnemyApproachSC.IsApproach)
        {
            StartCoroutine("Approach");
        }
    }
    private IEnumerator Approach()
    {
        WarningPanel.color = new Color(255, 0, 0, 255);
        yield return new WaitForSeconds(1f);
        WarningPanel.color = new Color(255, 0, 0, 0);
        yield return new WaitForSeconds(1f);
    }
}
