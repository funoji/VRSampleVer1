using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Oculus.Interaction
{
    public class ToHands : MonoBehaviour
    {
        private bool invaded;//�t�B�[���h�ɓ�������
/*        [SerializeField]*/public GameObject[] Hands;
        [SerializeField] float speed = 3.0f;
        [SerializeField] bool isNotPool = false;
        ObjectPool objectPool;
        ActiveStateSelector activeSelectorR;
        ActiveStateSelector activeSelectorL;

        private float scaleedSize;
        private float beforeSize;

        Rigidbody EnemyRig;

/*        [SerializeField] */public RayInteractor[] _rayInteractor;
        
        GameObject[] obj_tes;
        private bool flag = false;

        [SerializeField] private AudioClip SuikomiSE;
        private AudioSource _source;
        // Start is called before the first frame update
        void Awake()
        {
            _source = GetComponent<AudioSource>();
            this.AssertField(_rayInteractor, nameof(_rayInteractor));

            Hands[0] = GameObject.Find("LeftHandAnchor");
            GameObject obj = GameObject.Find("HandRayInteractorL");
            _rayInteractor[0] = obj.GetComponent<RayInteractor>();

            Hands[1] = GameObject.Find("RightHandAnchor");
            GameObject obj1 = GameObject.Find("HandRayInteractorR");
            _rayInteractor[1] = obj1.GetComponent<RayInteractor>();
            objectPool = GameObject.Find("cubeSpawn").GetComponent<ObjectPool>();
            activeSelectorR = GameObject.Find("HandGunR").GetComponent<ActiveStateSelector>();
            activeSelectorL = GameObject.Find("HandGunL").GetComponent<ActiveStateSelector>();

            EnemyRig = this.GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void Update()
        {
            //if (this.gameObject.activeSelf&&flag==false)
            //{
            //    //Hands[0] = GameObject.Find("LeftHandAnchor");
            //    //Hands[1] = GameObject.Find("RightHandAnchor");

            //    GameObject obj = GameObject.Find("HandRayInteractorL");
            //    _rayInteractor[0] = obj.GetComponent<RayInteractor>();
            //    GameObject obj1 = GameObject.Find("HandRayInteractorR");
            //    _rayInteractor[1] = obj1.GetComponent<RayInteractor>();
            //    flag = true;
            //}
            if (SpawnEnemy.IsSpawn&&BulletManager.IsFillList)
            {
                EnemyRig = this.GetComponent<Rigidbody>();
                Hands[0] = GameObject.Find("LeftHandAnchor");
                GameObject obj = GameObject.Find("HandRayInteractorL");
                _rayInteractor[0] = obj.GetComponent<RayInteractor>();
                Hands[1] = GameObject.Find("RightHandAnchor");
                GameObject obj1 = GameObject.Find("HandRayInteractorR");
                _rayInteractor[1] = obj1.GetComponent<RayInteractor>();
                SpawnEnemy.IsSpawn = false;
                BulletManager.IsFillList = false;
            }
            if (invaded)
            {
                if (_rayInteractor[0].ModeLR)
                {
                    EnemyRig.useGravity = false;

                    transform.position = Vector3.MoveTowards(transform.position, Hands[0].transform.position,
                   speed * Time.deltaTime);

                    if (flag == false)
                    {
                        _source.PlayOneShot(SuikomiSE);
                        flag = true;
                    }
                }

                if(!_rayInteractor[1].ModeLR)
                {
                    EnemyRig.useGravity = false;

                    if (flag == false)
                    {
                        _source.PlayOneShot(SuikomiSE);
                        flag = true;
                    }

                    transform.position = Vector3.MoveTowards(transform.position, Hands[1].transform.position,
                   speed * Time.deltaTime);
                }

                beforeSize += Time.deltaTime * 0.5f;
                //scaleedの値を小さく
                scaleedSize = 0.2f - beforeSize;

                //scaleedに制限を加える。
                scaleedSize = Mathf.Clamp(scaleedSize, 0.02f, 0.2f);

                transform.localScale = new Vector3(scaleedSize, scaleedSize, scaleedSize);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (invaded)
            {
                if (other.gameObject.CompareTag("LHand"))
                {
                    activeSelectorL.ReloadBullet();
                    invaded = false;
                    _rayInteractor[0].ModeLR = false;
                    if (!isNotPool)
                    {
                        gameObject.GetComponentInParent<ObjectPool>().RepoolObject(gameObject);
                        gameObject.GetComponentInParent<ObjectPool>().GetPooledObject();
                        flag = false;
                    }
                    else
                    {
                        GameObject.Destroy(gameObject);
                        flag = false;
                    }

                }

                if (other.gameObject.CompareTag("RHand"))
                {
                    activeSelectorR.ReloadBullet();
                    invaded = false;
                    _rayInteractor[1].ModeLR = true;
                    if (!isNotPool)
                    {
                        gameObject.GetComponentInParent<ObjectPool>().RepoolObject(gameObject);
                        gameObject.GetComponentInParent<ObjectPool>().GetPooledObject();
                        flag = false;
                    }
                    else
                    {
                        GameObject.Destroy(gameObject);
                        flag=false;
                    } 
                }
            }
        }

        public void StartHikiyose()
        {
            invaded = true;
        }
    }
}