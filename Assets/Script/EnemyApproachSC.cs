using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyApproachSC : MonoBehaviour
{
    [SerializeField] private Image WarningPanel;

    private Enemy_SC _enemy;
    public static bool IsApproach = false;
    private Color _color;
    void Start()
    {
        WarningPanel.color = new Color(255, 0, 0, 0);
    }

    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            _enemy = other.GetComponent<Enemy_SC>();
            _enemy.EnemySpeed = 0.005f;
            IsApproach = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            IsApproach = false;
            WarningPanel.color = new Color(255, 0, 0, 0);
        }
    }
}
