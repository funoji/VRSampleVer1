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
        [Header("�����܂ł̎���(n�b)")]
        public int delayTime = 3;
    }

    [Header("����p�q�I�u�W�F�N�g(BombArea)")]
    [SerializeField] private GameObject BombArea;
    [Header("�����͈�(���a)")]
    public float Ex_Radius = 5.0f;
    [Header("�����̈З�")]
    public float Ex_power = 20.0f;
    [Header("������ւ̗�")]
    public float Ex_powerUP = 5.0f;
    [Header("�����G�t�F�N�g")]
    [SerializeField] private ParticleSystem Ex_particle;
    [Header("������j�Q�����Q���̃��C���[")]
    public int Wall_Layer;

    [Header("�����܂ł̎��Ԃ�ݒ肵�����ꍇ")]
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
        //��������܂ł̎��Ԃ�҂��A�G���A���̃^�O�t���I�u�W�F�N�g��j��
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
        if (col.gameObject.tag == "Bullet")  //���������甚���J�n����I�u�W�F�N�g�̃^�O
        {
            BombArea.gameObject.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (IsExplosion && other.gameObject.tag == "CanExplosion")  //���������t�^����I�u�W�F�N�g�̃^�O
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
                // Ray���΂��ĕǂ�����ł����疳������
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
