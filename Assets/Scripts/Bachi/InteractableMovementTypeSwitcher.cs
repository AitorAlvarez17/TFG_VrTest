using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class InteractableMovementTypeSwitcher : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;
    private bool isVelocityTrackingEnabled = false;

    private void Start()
    {
        // Get the XRGrabInteractable component attached to the object
        grabInteractable = GetComponent<XRGrabInteractable>();

        if (grabInteractable.movementType == XRBaseInteractable.MovementType.VelocityTracking) isVelocityTrackingEnabled = true;
        // Add a listener to the collider's OnTrigerEnter event
        Collider collider = GetComponent<Collider>();
        if (collider != null)
        {
            collider.isTrigger = true;
            TriggerEventListener triggerEventListener = collider.gameObject.AddComponent<TriggerEventListener>();
            triggerEventListener.OnTriggerEnterEvent += OnTriggerEnterEventHandler;
            triggerEventListener.OnTriggerExitEvent += OnTriggerExitEventHandler;
        }
    }

    private void OnTriggerEnterEventHandler(Collider other)
    {
        // Check if the entered collider is the one that should trigger the movement type switch
        if (other.CompareTag("MovementTypeSwitchCollider"))
        {
            SwitchMovementType();
        }
    }

    private void OnTriggerExitEventHandler(Collider other)
    {
        // Check if the exited collider is the one that should trigger the movement type switch
        if (other.CompareTag("MovementTypeSwitchCollider"))
        {
            SwitchMovementType();
        }
    }

    private void SwitchMovementType()
    {
        // Switch the movement type based on the current state
        if (isVelocityTrackingEnabled)
        {
            grabInteractable.movementType = XRBaseInteractable.MovementType.Instantaneous;
        }
        else
        {
            grabInteractable.movementType = XRBaseInteractable.MovementType.VelocityTracking;
        }

        // Update the state
        isVelocityTrackingEnabled = !isVelocityTrackingEnabled;
    }
}
