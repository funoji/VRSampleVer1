using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToHands : MonoBehaviour
{
    private bool invaded;//�t�B�[���h�ɓ�������
    [SerializeField] GameObject[] Hands;
    [SerializeField] float speed = 3.0f;
    Rigidbody CubeRig;

    // Start is called before the first frame update
    void Start()
    {
        CubeRig = this.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (invaded)
        {
            //�X�^�[�g�ʒu�A�^�[�Q�b�g�̍��W�A���x
            transform.position = Vector3.MoveTowards(transform.position, Hands[0].transform.position,
                speed * Time.deltaTime);

            //�X�^�[�g�ʒu�A�^�[�Q�b�g�̍��W�A���x
            transform.position = Vector3.MoveTowards(transform.position, Hands[1].transform.position,
                speed * Time.deltaTime);
            //Rigidbody���~
            //CubeRig.velocity = Vector3.zero;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (invaded)
        {
            if (other.gameObject.CompareTag("Hand"))
            {
                CubeRig.isKinematic = true;
                transform.parent = Hands[0].gameObject.transform;
                transform.parent = Hands[1].gameObject.transform;
                Debug.Log("ToHand!");
            }
        }
    }

    public void StartHikiyose()
    {
        invaded = true;
    }

    public void EndHikiyose()
    {
        CubeRig.isKinematic = false;
        invaded = false;
        transform.parent = null;
    }
}
