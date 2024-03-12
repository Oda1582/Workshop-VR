using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;

public class Labyrinthe_Sphere_Script : MonoBehaviour
{
    public Material DeactivatedMat, DeactivatedMatHovered, ActivatedMat, ActivatedMatHovered;
    public Renderer MeshRenderer;
    public bool IsActivated = false;
    public InputActionReference L_Trigger;
    public InputActionReference R_Trigger;
    public XRBaseInteractor LDirect;
    public XRBaseInteractor LRay;
    public XRBaseInteractor RDirect;
    public XRBaseInteractor RRay;
    public SlidingDoor DoorRef;
    private XRSimpleInteractable Interactable;
    public Animator DoorAnim;
    public GameObject parentGameObject;
    public GameObject childGameObject;
    public Light LightComponent;
    public Color LightDeactivated;
    public Color LightActivated;
    public Labyrinthe_Puzzle_Script PuzzleRef;
    public bool IsCompleted;
    public AudioManager AudioManager;

    // Start is called before the first frame update
    void Start()
    {
        Interactable = GetComponent<XRSimpleInteractable>();
        MeshRenderer = GetComponent<Renderer>();
        // Interactable.hoverEntered.RemoveListener(OnActivate);
        // Interactable.hoverExited.RemoveListener(OnDeactivate);
        parentGameObject = GameObject.Find(gameObject.name);
        childGameObject = parentGameObject.transform.Find("Point Light").gameObject;
        LightComponent = childGameObject.GetComponentInChildren<Light>();
        LightDeactivated = new Color32(255, 0, 0, 255);
        LightActivated = new Color32(0, 255, 0, 255);
    }

    // Update is called once per frame
    void Update()
    {
        if (IsActivated == true)
        {
        // Debug.Log(gameObject.name + " is " + IsActivated);
        }
    }
    
    private void OnEnable()
    {
        GetComponent<XRSimpleInteractable>().hoverEntered.AddListener(OnActivate);
        GetComponent<XRSimpleInteractable>().hoverExited.AddListener(OnDeactivate);
        // GetComponent<XRGrabInteractable>().onSelectExited.AddListener(OnReleased);
    }

    private void OnDisable()
    {
        // Interactable.hoverEntered.RemoveListener(OnActivate);
        // Interactable.hoverExited.RemoveListener(OnDeactivate);
        // GetComponent<XRGrabInteractable>().onSelectExited.RemoveListener(OnReleased);
    }

    private void OnActivate(HoverEnterEventArgs args)
    {
        XRBaseInteractor interactor = args.interactor;

        // Debug.Log(interactor + "entered and is now " + Interactable.IsHovered(interactor));
        if ((interactor == LDirect || interactor == LRay) && Interactable.IsHovered(interactor))
        {
            // Debug.Log("Object grabbed by Left");
            L_Trigger.action.performed += OnActivateAction;
            L_Trigger.action.Enable();
            // R_Trigger.action.performed -= OnActivateAction;
        } else if ((interactor == RDirect || interactor == RRay) && Interactable.IsHovered(interactor))
        {
            // Debug.Log("Object grabbed by Right");
            R_Trigger.action.performed += OnActivateAction;
            R_Trigger.action.Enable();
            // L_Trigger.action.performed -= OnActivateAction;
        }
        // Debug.Log("Object grabbed by " + interactor.name);
    }

    private void OnDeactivate(HoverExitEventArgs args)
    {
            XRBaseInteractor interactor = args.interactor;
            // Debug.Log(interactor + "exited and is now " + Interactable.IsHovered(interactor));
        if ((interactor == LDirect || interactor == LRay) && Interactable.IsHovered(interactor) == false)
        {
            L_Trigger.action.performed -= OnActivateAction;
        }
        else if ((interactor == RDirect || interactor == RRay) && Interactable.IsHovered(interactor) == false)
        {
            R_Trigger.action.performed -= OnActivateAction;
        }
    }


    public void OnActivateAction(InputAction.CallbackContext context)
    {
        if (IsActivated == false)
        {
            MeshRenderer.material = ActivatedMatHovered;
            LightComponent.color = LightActivated;
            AudioManager.PlayOneShot("Activated");
            IsActivated = true;
            PuzzleRef.CheckPuzzle();
            // DoorRef.Open();
            // DoorRef.Close();
            // DoorAnim.SetTrigger("Open");
        } else if (IsActivated == true)
        {
            MeshRenderer.material = DeactivatedMatHovered;
            LightComponent.color = LightDeactivated;
            IsActivated = false;
            // DoorRef.Close();
            // DoorAnim.SetTrigger("Close");
        }
    }

    public void onHoverEnteredMat()
    {
        if (IsActivated == false)
        {
            MeshRenderer.material = DeactivatedMatHovered;
        } else if (IsActivated == true)
        {
            MeshRenderer.material = ActivatedMatHovered;
        }
    }

    public void onHoverExitedMat()
    {
        if (IsActivated == false)
        {
            MeshRenderer.material = DeactivatedMat;
        } else if (IsActivated == true)
        {
            MeshRenderer.material = ActivatedMat;
            if (IsCompleted == true)
            {
                MeshRenderer.material = ActivatedMatHovered;
            } else if (IsCompleted == false)
            {
                MeshRenderer.material = ActivatedMat;
            }
        }
    }

    public void ResetSphere()
    {
        MeshRenderer.material = DeactivatedMat;
        LightComponent.color = LightDeactivated;
        IsActivated = false;
    }

    public void CompletedSphere()
    {
        IsCompleted = true;
        MeshRenderer.material = ActivatedMatHovered;
        LightComponent.color = LightActivated;
    }
}
