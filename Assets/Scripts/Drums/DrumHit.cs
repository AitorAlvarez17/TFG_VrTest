using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DrumHit : MonoBehaviour
{
    private AudioSource source;
    bool hit = false;
    private void Start()
    {
        // Get the XRGrabInteractable component attached to the object

        // Add a listener to the collider's OnTrigerEnter event
        //Collider collider = GetComponent<Collider>();
        //if (collider != null)
        //{
        //    collider.isTrigger = true;
        //    TriggerEventListener triggerEventListener = collider.gameObject.AddComponent<TriggerEventListener>();
        //    triggerEventListener.OnTriggerEnterEvent += OnTriggerEnterEventHandler;
        //    triggerEventListener.OnTriggerExitEvent += OnTriggerExitEventHandler;
        //}

        source = GetComponent<AudioSource>();
    }

    //private void OnTriggerEnterEventHandler(Collider other)
    //{
    //    // Check if the entered collider is the one that should trigger the movement type switch
    //    if (other.CompareTag("DrumHead") && hit == false)
    //    {
    //        AudioSource drumSource = other.GetComponent<AudioSource>();
    //        drumSource.Play(drumSource.clip);
    //        hit = true;
    //    }
    //}

    //private void OnTriggerExitEventHandler(Collider other)
    //{
    //    // Check if the exited collider is the one that should trigger the movement type switch
    //    if (other.CompareTag("DrumHead") && hit == true)
    //    {
    //        hit = false;

    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        if(hit == false)
        {
            source.Play();
            Debug.Log("playing sound");
            hit = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        hit = false;
    }



}
