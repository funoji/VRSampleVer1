using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyApproachSC : MonoBehaviour
{
    [SerializeField] private Image WarningPanel;
    public float interval = 0.1f;
    public float AP_EnemySpeed = 0.8f;

    private Enemy_SC _enemy;
    public static bool IsApproach = false;
    private Color _color;
    private bool IsBlinking = false;
    private Collider[] defaultColl;
    private int defaultNum = 0;
    private int enemynum = 0;
    void Start()
    {
        WarningPanel.enabled = false;
        defaultColl = Physics.OverlapSphere(this.gameObject.transform.localScale, 6);
        for (int count = 0; count < defaultColl.Length; count++)
        {
            if (defaultColl[count].gameObject.tag == "Enemy")
            {
                defaultNum++;
            }
        }
    }

    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            _enemy = other.GetComponent<Enemy_SC>();
            _enemy.EnemySpeed = AP_EnemySpeed * Time.deltaTime;
            IsApproach = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {

            StartCoroutine("Blink");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            IsApproach = false;
            IsBlinking = false;
        }
    }

    private IEnumerator Blink()
    {
        if (!IsBlinking)
        {
            IsBlinking = true;
            while (true)
            {
                WarningPanel.enabled = !WarningPanel.enabled;
                yield return new WaitForSeconds(interval);
                Collider[] hitcollider = Physics.OverlapSphere(this.gameObject.transform.localScale, 6);
                for(int count=0; count<hitcollider.Length; count++)
                {
                    if(hitcollider[count].gameObject.tag == "Enemy")
                    {
                        enemynum++;
                    }
                }
                if (enemynum == 0)
                {
                    WarningPanel.enabled = false;
                    IsBlinking = false;
                    break;
                }
                enemynum = 0;
            }
        }
    }
}
