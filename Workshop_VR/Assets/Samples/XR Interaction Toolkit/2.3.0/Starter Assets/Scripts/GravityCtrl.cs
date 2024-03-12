using UnityEngine;
using System.Collections;
using UnityEngine.XR.Interaction.Toolkit;

public class ExampleClass : MonoBehaviour
{
    public Collider coll;

    void Start()
    {
        coll = GetComponent<Collider>();
        coll.isTrigger = true;
    }

    // Disables gravity on all rigidbodies entering this collider.
    void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody)
            other.attachedRigidbody.useGravity = false;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.attachedRigidbody)
            other.attachedRigidbody.useGravity = true;
            other.GetComponent<XRGrabInteractable>().forceGravityOnDetach = true;

    }
}