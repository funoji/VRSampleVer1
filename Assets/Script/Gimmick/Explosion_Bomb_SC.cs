using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Explosion_Bomb_SC : MonoBehaviour
{
    [System.Serializable]
    public class WaitClass
    {
        [Header("爆発までの時間(n秒)")]
        public int delayTime = 3;
    }

    [Header("判定用子オブジェクト(BombArea)")]
    [SerializeField] private GameObject BombArea;
    [Header("爆発範囲(半径)")]
    public float Ex_Radius = 5.0f;
    [Header("爆発の威力")]
    public float Ex_power = 20.0f;
    [Header("上方向への力")]
    public float Ex_powerUP = 5.0f;
    [Header("爆発エフェクト")]
    [SerializeField] private ParticleSystem Ex_particle;
    [Header("爆発を阻害する障害物のレイヤー")]
    public int Wall_Layer;

    [Header("爆発までの時間を設定したい場合")]
    public bool Set_WaitTime = true;
    [FlagConditionalDisableInInspector("Set_WaitTime")]
    public WaitClass _waitclass;

    private bool IsExplosion = false;
    private SphereCollider _SphereColl;

    void Start()
    {
        _SphereColl = BombArea.GetComponent<SphereCollider>();
        _SphereColl.radius = Ex_Radius;
        BombArea.gameObject.SetActive(false);
    }

    void Update()
    {
        //爆発するまでの時間を待ち、エリア内のタグ付きオブジェクトを破壊
        if (BombArea.gameObject.activeSelf)
        {
            StartCoroutine("ExplosionCoroutine");
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Bomb");
            Explosion();
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Bullet")  //当たったら爆発開始するオブジェクトのタグ
        {
            BombArea.gameObject.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (IsExplosion && other.gameObject.tag == "CanExplosion")  //爆発判定を付与するオブジェクトのタグ
        {
            Explosion();
            StartCoroutine("WaitTime");
            Destroy(other.gameObject);
        }
    }

    private IEnumerator ExplosionCoroutine()
    {
        if (Set_WaitTime)
        {
            for (int waitCount = _waitclass.delayTime; waitCount > 0; waitCount--)
            {
                yield return new WaitForSeconds(1000f * Time.deltaTime);
            }
        }
        IsExplosion = true;
    }
    private IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(_waitclass.delayTime * Time.deltaTime);
    }

    private void Explosion()
    {
        Ex_particle.transform.position = BombArea.transform.position;
        Ex_particle.Play();

        Collider[] HitColliders = Physics.OverlapSphere(BombArea.transform.position, Ex_Radius);
        for (int i = 0; i < HitColliders.Length; i++)
        {
            var rb = HitColliders[i].GetComponent<Rigidbody>();
            if (rb)
            {
                // Rayを飛ばして壁を挟んでいたら無視する
                var hits = Physics.RaycastAll(BombArea.transform.position, HitColliders[i].transform.position - BombArea.transform.position, Ex_Radius);
                bool block = false;
                foreach (var o in hits)
                {
                    if (o.collider.gameObject.layer == Wall_Layer)
                    {
                        block = true;
                        break;
                    }
                }
                if (!block)
                {
                    rb.AddExplosionForce(Ex_power, BombArea.transform.position, Ex_Radius, Ex_powerUP, ForceMode.Impulse);
                }
            }
        }
    }
}
