using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ObjectGrabChecker : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;

    private void Start()
    {
        // Get the XRGrabInteractable component attached to this object
        grabInteractable = GetComponent<XRGrabInteractable>();
    }

    private void Update()
    {
        // Check if the object is currently grabbed
        if (grabInteractable.isSelected)
        {
            Debug.Log("Object is currently grabbed");
        }
        else
        {
            Debug.Log("Object is not currently grabbed");
        }
    }
}
