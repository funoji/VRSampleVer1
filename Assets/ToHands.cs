using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Oculus.Interaction
{
    public class ToHands : MonoBehaviour
    {
        private bool invaded;//フィールドに入ったか
        [SerializeField] OVRHand[] Hands;
        [SerializeField] float speed = 3.0f;

        private float scaleedSize;
        private float beforeSize;

        Rigidbody EnemyRig;

        [SerializeField] RayInteractor[] _rayInteractor;

        // Start is called before the first frame update
        void Start()
        {
            this.AssertField(_rayInteractor, nameof(_rayInteractor));
            EnemyRig = this.GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void Update()
        {
            if (invaded)
            {
                if (_rayInteractor[0].ModeLR)
                {
                    //GameObject LHand = GameObject.Find("LeftHandAnchor");
                    // transform.position = Vector3.MoveTowards(transform.position, LHand.transform.position,
                    //speed * Time.deltaTime);

                    EnemyRig.useGravity = false;

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