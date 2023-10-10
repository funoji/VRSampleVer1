using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion_Bomb_SC : MonoBehaviour
{
    [Header("����p�q�I�u�W�F�N�g(BombArea)")]
    [SerializeField] private GameObject BombArea;
    [Header("����������܂ł̎���")]
    public float delayTime = 3000.0f;
    [Header("�����͈�(���a)")]
    public float Ex_Radius = 5.0f;
    [Header("�����̈З�")]
    public float Ex_power = 20f;
    [Header("������ւ̗�")]
    public float Ex_powerUP = 5f;
    [Header("�����G�t�F�N�g")]
    [SerializeField] private ParticleSystem Ex_particle;
    [Header("������j�Q�����Q���̃��C���[")]
    public int Wall_Layer;

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
            Destroy(other.gameObject);
        }
    }

    private IEnumerator ExplosionCoroutine()
    {
        yield return new WaitForSeconds(delayTime * Time.deltaTime);
        IsExplosion = true;
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
