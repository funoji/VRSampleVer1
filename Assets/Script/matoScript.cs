using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class matoScript : MonoBehaviour
{
    public float speed = 5.0f;
    public float changeDirectionInterval = 2.0f;
    public float reverseDirectionInterval = 1.0f;
    public bool random = false;
    public Vector3 Vec;

    private Vector3 targetDirection;
    private float timer;
    private bool isMovingForward = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        SetRandomDirection();
        InvokeRepeating("ReverseDirection", reverseDirectionInterval, reverseDirectionInterval);
    }

    private void Update()
    {
        // �^�C�}�[���X�V
        timer += Time.deltaTime;

        // ���̎��Ԃ��o�߂�����V���������ɐ؂�ւ�
        if (timer >= changeDirectionInterval)
        {
            if(random)
            {
                SetRandomDirection();
            }
            SetDirection(Vec);
            timer = 0;
        }

        // �ړ�
        MoveInDirection(targetDirection);
    }

    private void SetRandomDirection()
    {
        // �����_���ȕ�����ݒ�
        targetDirection = Random.insideUnitSphere.normalized;
        targetDirection.y = 0;
    }

    private void ReverseDirection()
    {
        // �i�s�����𔽓]
        isMovingForward = !isMovingForward;
    }

    // �V�������\�b�h: �O������ړ��������w��ł���
    public void SetDirection(Vector3 direction)
    {
        targetDirection = direction.normalized;
        targetDirection.y = 0;
    }

    private void MoveInDirection(Vector3 direction)
    {
        // �ړ�
        transform.Translate(direction * speed * (isMovingForward ? 1 : -1) * Time.deltaTime);
    }


}