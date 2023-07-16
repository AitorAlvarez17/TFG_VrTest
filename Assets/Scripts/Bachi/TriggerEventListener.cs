using UnityEngine;

public class TriggerEventListener : MonoBehaviour
{
    // Event delegates
    public delegate void TriggerEventHandler(Collider other);
    public event TriggerEventHandler OnTriggerEnterEvent;
    public event TriggerEventHandler OnTriggerExitEvent;

    private void OnTriggerEnter(Collider other)
    {
        OnTriggerEnterEvent?.Invoke(other);
    }

    private void OnTriggerExit(Collider other)
    {
        OnTriggerExitEvent?.Invoke(other);
    }
}
