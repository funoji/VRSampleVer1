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

        private float scaleed;
        private float before;

        [SerializeField] RayInteractor[] _rayInteractor;

        // Start is called before the first frame update
        void Start()
        {
            this.AssertField(_rayInteractor, nameof(_rayInteractor));
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

                    transform.position = Vector3.MoveTowards(transform.position, Hands[0].transform.position,
                   speed * Time.deltaTime);
                }

                if(!_rayInteractor[1].ModeLR)
                {
                    //GameObject RHand = GameObject.Find("RightHandAnchor");
                    // transform.position = Vector3.MoveTowards(transform.position, RHand.transform.position,
                    //speed * Time.deltaTime);
                    transform.position = Vector3.MoveTowards(transform.position, Hands[1].transform.position,
                   speed * Time.deltaTime);
                }

                before += Time.deltaTime * 0.5f;
                //scaleedの値を小さく
                scaleed = 0.2f - before;

                //scaleedに制限を加える。
                scaleed = Mathf.Clamp(scaleed, 0.02f, 0.2f);

                transform.localScale = new Vector3(scaleed, scaleed, scaleed);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (invaded)
            {
                if (other.gameObject.CompareTag("Hand"))
                {
                    Destroy(gameObject);
                }
            }
        }

        public void StartHikiyose()
        {
            invaded = true;
        }
    }
}