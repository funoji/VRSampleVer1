using UnityEngine;
using UnityEngine.Events;

public class Ondestroy : MonoBehaviour
{
    public UnityEvent OnDestroyed = new UnityEvent();

    private void OnDestroy()
    {
        Debug.Log("Destroyed");
       // OnDestroyed.Invoke();
    }
}
