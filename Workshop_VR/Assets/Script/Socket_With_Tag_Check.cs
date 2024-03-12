using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Socket_With_Tag_Check : XRSocketInteractor
{   
    public string targetTag = string.Empty;
    private bool isInteractableInSocket = false;
    public FlashlightScript FLRef;

    [Obsolete("This method is obsolete, use newMethod instead.")]
    public override bool CanHover(XRBaseInteractable interactable)
    {
        bool canHover = base.CanHover(interactable) && MatchUsingTag(interactable);
        // if (canHover && interactable.selectingInteractor != null && interactable.selectingInteractor is XRSocketInteractor)
        // {
        //     isInteractableInSocket = true;
        //     // Debug.Log("Hover");
        //     // this.enabled = false;
        // }
        // else
        // {
        //     isInteractableInSocket = false;
        //     // this.enabled = true;
        // }

        return canHover;
    }

    [Obsolete("This method is obsolete, use newMethod instead.")]
    public override bool CanSelect(XRBaseInteractable interactable)
    {
        bool canSelect = base.CanSelect(interactable) && MatchUsingTag(interactable);
        // if (canSelect && interactable.selectingInteractor != null && interactable.selectingInteractor is XRSocketInteractor)
        // {
        //     isInteractableInSocket = true;
        //     // Debug.Log("Select");
        //     // this.enabled = false;
        // }
        // else
        // {
        //     isInteractableInSocket = false;
        //     // this.enabled = true;
        // }

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
        FLRef.isInteractableInSocket = true;
        Debug.Log("Select entered");
        // this.enabled = false;
    }

    [Obsolete("This method is obsolete, use newMethod instead.")]
    protected override void OnSelectExited(XRBaseInteractable interactable)
    {
        base.OnSelectExited(interactable);
        isInteractableInSocket = false;
        FLRef.isInteractableInSocket = false;
        // FLRef.Light.spotAngle = FLRef.OGSpotAngle;
        // FLRef.Light.intensity = FLRef.OGIntensity;
        Debug.Log("Select exited");
        // this.enabled = true;
    }
}
