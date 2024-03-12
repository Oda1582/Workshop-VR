using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class CollisionDetector : MonoBehaviour
{
    public GameObject Wire1;
    public Rigidbody rb;
    private XRGrabInteractable grabInteractable;
   

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject == Wire1)
        {
            
            DisableRagdoll();
            transform.position = Wire1.transform.position;
            Debug.Log(transform.position);
            Debug.Log(Wire1.transform.position);
        }
    }

    void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        rb = GetComponent<Rigidbody>();
        EnableRagdoll();
    }

    // Let the rigidbody take control and detect collisions.
    void EnableRagdoll()
    {
        rb.isKinematic = false;
        rb.detectCollisions = true;
    }

    // Let animation control the rigidbody and ignore collisions.
    void DisableRagdoll()
    {
        rb.isKinematic = true;
        rb.detectCollisions = false;
        rb.constraints = RigidbodyConstraints.FreezePosition;
        grabInteractable.enabled = false;

        // Get the interactor that is currently grabbing this GameObject
            // XRBaseInteractor interactor = grabInteractable.selectingInteractor;

            // Force the interactor to stop interacting with this GameObject
        
    }
}
