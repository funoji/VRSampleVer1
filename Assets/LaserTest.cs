using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(LineRenderer))]
public class LaserTest : MonoBehaviour
{
    #region//レーザーポインターその１
    [SerializeField]
    GameObject hand;
    LineRenderer lineRenderer;
    Vector3 hitPos;
    Vector3 tmpPos;

    float lazerDistance = 10f;
    float lazerStartPointDistance = 0.15f;
    float lineWidth = 0.01f;

    void Reset()
    {
        lineRenderer = this.gameObject.GetComponent<LineRenderer>();
        lineRenderer.startWidth = lineWidth;
    }

    void Start()
    {
        lineRenderer = this.gameObject.GetComponent<LineRenderer>();
        lineRenderer.startWidth = lineWidth;
    }


    void Update()
    {
        OnRay();
    }

    void OnRay()
    {
        Vector3 direction = hand.transform.forward * lazerDistance;
        //Vector3 rayStartPosition = hand.transform.position * lazerStartPointDistance;
        Vector3 pos = hand.transform.position;
        RaycastHit hit;
        //Ray ray = new Ray(pos + rayStartPosition, hand.transform.forward);
        Ray ray = new Ray(pos, hand.transform.forward);

        //lineRenderer.SetPosition(0, pos + rayStartPosition);
        lineRenderer.SetPosition(0, pos);

        if (Physics.Raycast(ray, out hit, lazerDistance))
        {
            hitPos = hit.point;
            lineRenderer.SetPosition(1, hitPos);
        }
        else
        {
            lineRenderer.SetPosition(1, pos + direction);
        }

        Debug.DrawRay(ray.origin, ray.direction, Color.red, 0.1f);
    }
    #endregion
}