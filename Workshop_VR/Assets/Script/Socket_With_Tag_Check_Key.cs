using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Socket_With_Tag_Check_Key : XRSocketInteractor
{   
    public string targetTag = string.Empty;
    private bool isInteractableInSocket = false;
    public MeshCollider KeyMeshCollider;
    public HingeJoint DoorHingeJoint;
    JointLimits limits;
    public Reveal RevealScript;

    new private void Start() 
    {
        limits = DoorHingeJoint.limits;
        limits.min = 0f;
        DoorHingeJoint.limits = limits;
    }

    public void Update() 
    {
        if (isInteractableInSocket == true)
        {
        RevealScript.SetShaderRecursively(RevealScript.gameObject, RevealScript.Standard);
        }
    }

    [Obsolete("This method is obsolete, use newMethod instead.")]
    public override bool CanHover(XRBaseInteractable interactable)
    {
        bool canHover = base.CanHover(interactable) && MatchUsingTag(interactable);
        if (canHover && interactable.selectingInteractor != null && interactable.selectingInteractor is XRSocketInteractor)
        {
            isInteractableInSocket = true;
            // Debug.Log("Hover");
            // this.enabled = false;
        }
        else
        {
            isInteractableInSocket = false;
            // this.enabled = true;
        }

        return canHover;
    }

    [Obsolete("This method is obsolete, use newMethod instead.")]
    public override bool CanSelect(XRBaseInteractable interactable)
    {
        bool canSelect = base.CanSelect(interactable) && MatchUsingTag(interactable);
        if (canSelect && interactable.selectingInteractor != null && interactable.selectingInteractor is XRSocketInteractor)
        {
            isInteractableInSocket = true;
            // Debug.Log("Select");
            // this.enabled = false;
        }
        else
        {
            isInteractableInSocket = false;
            // this.enabled = true;
        }

        return canSelect;
    }

    private bool MatchUsingTag(XRBaseInteractable interactable)
    {
        return interactable.CompareTag(targetTag);
    }

    [Obsolete("This method is obsolete, use newMethod instead.")]
    protected override void OnSelectEntered(XRBaseInteractable interactable)
    {
        base.OnSelectEntered(interactable);
        isInteractableInSocket = true;
        Debug.Log("Select entered");
        limits = DoorHingeJoint.limits;
        limits.min = -120f;
        DoorHingeJoint.limits = limits;
        KeyMeshCollider.enabled = false;
    }

    [Obsolete("This method is obsolete, use newMethod instead.")]
    protected override void OnSelectExited(XRBaseInteractable interactable)
    {
        base.OnSelectExited(interactable);
        isInteractableInSocket = false;
        KeyMeshCollider.enabled = true;
        Debug.Log("Select exited");
        // this.enabled = true;
    }
}
