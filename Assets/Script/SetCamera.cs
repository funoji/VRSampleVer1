using UnityEngine;

public class SetCamera : MonoBehaviour
{
    void Start()
    {
        GetComponent<Camera>().enabled = false;
        GetComponent<Camera>().enabled = true;
    }
}