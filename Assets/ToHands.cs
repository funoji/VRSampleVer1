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

        private float scaleedSize;
        private float beforeSize;

        Rigidbody EnemyRig;

/*        [SerializeField] */public RayInteractor[] _rayInteractor;
        
        GameObject[] obj_tes;
        private bool flag = false;
        // Start is called before the first frame update
        void Awake()
        {
            this.AssertField(_rayInteractor, nameof(_rayInteractor));

            Hands[0] = GameObject.Find("LeftHandAnchor");
            GameObject obj = GameObject.Find("HandRayInteractorL");
            _rayInteractor[0] = obj.GetComponent<RayInteractor>();

            Hands[1] = GameObject.Find("RightHandAnchor");
            GameObject obj1 = GameObject.Find("HandRayInteractorR");
            _rayInteractor[1] = obj1.GetComponent<RayInteractor>();

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
                Debug.Log("������");
            }
            if (invaded)
            {
                if (_rayInteractor[0].ModeLR)
                {
                    //GameObject LHand = GameObject.Find("LeftHandAnchor");
                    // transform.position = Vector3.MoveTowards(transform.position, LHand.transform.position,
                    //speed * Time.deltaTime);

                    //EnemyRig.useGravity = false;

                    transform.position = Vector3.MoveTowards(transform.position, Hands[0].transform.position,
                   speed * Time.deltaTime);
                }

                if(!_rayInteractor[1].ModeLR)
                {
                    //GameObject RHand = GameObject.Find("RightHandAnchor");
                    // transform.position = Vector3.MoveTowards(transform.position, RHand.transform.position,
                    //speed * Time.deltaTime);

                    EnemyRig.useGravity = false;


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
                    Destroy(gameObject);
                    _rayInteractor[0].ModeLR = false;
                }

                if (other.gameObject.CompareTag("RHand"))
                {
                    Destroy(gameObject);
                        Debug.Log(gameObject);
                    _rayInteractor[1].ModeLR = true;
                }
            }
        }

        public void StartHikiyose()
        {
            invaded = true;
        }
    }
}