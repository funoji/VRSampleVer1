using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class matoScript : MonoBehaviour
{

    public float speed = 5.0f;
    public float changeDirectionInterval = 2.0f;
    public float reverseDirectionInterval = 1.0f;

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
        //InvokeRepeating("ReverseDirection", reverseDirectionInterval, reverseDirectionInterval);
    }

    private void Update()
    {
        // タイマーを更新
        timer += Time.deltaTime;

        // 一定の時間が経過したら新しい方向に切り替え
        if (timer >= changeDirectionInterval)
        {
            ReverseDirection();
            timer = 0;
        }

        // 移動
        transform.Translate(targetDirection * speed * (isMovingForward ? 1 : -1) * Time.deltaTime);
    }

    private void SetRandomDirection()
    {
        // ランダムな方向を設定
        targetDirection = Random.insideUnitSphere.normalized;
        targetDirection.y = 0;
    }

    private void ReverseDirection()
    {
        // 進行方向を反転
        isMovingForward = !isMovingForward;
    }
}
