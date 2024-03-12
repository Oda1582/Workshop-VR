using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;

public class FlashlightScript : MonoBehaviour
{
    public bool ModAdditif = true;
    public bool ModDestructif = false;
    public InputActionReference L_FlashlightMode;
    public InputActionReference R_FlashlightMode;
    public XRGrabInteractable grabInteractable;
    public XRRayInteractor rayInteractor;
    public Light Light;
    public float OGIntensity = 1f;
    public float NewIntensity = 0f;
    public float OGSpotAngle = 30f;
    public float NewSpotAngle = 1f;
    public Color LightColorAdd, LightColorDes;
    public XRBaseInteractor LDirect;
    public XRBaseInteractor LRay;
    public XRBaseInteractor RDirect;
    public XRBaseInteractor RRay;
    public bool isInteractableInSocket = false;
    public AudioManager audioManager;
    public bool IsUpgraded = false;

    [SerializeField]
    LayerMask m_RaycastMaskAdd = -1;
    /// <summary>
    /// Gets or sets layer mask used for limiting ray cast targets.
    /// </summary>
    public LayerMask raycastMaskAdd
    {
        get => m_RaycastMaskAdd;
        set => m_RaycastMaskAdd = value;
    }

    [SerializeField]
    LayerMask m_RaycastMaskDes = -1;
    /// <summary>
    /// Gets or sets layer mask used for limiting ray cast targets.
    /// </summary>
    public LayerMask raycastMaskDes
    {
        get => m_RaycastMaskDes;
        set => m_RaycastMaskDes = value;
    }
    
    private void Awake()
    {
        if (ModAdditif == true)
        {
            Light.color = LightColorAdd;
        } 
        else if (ModDestructif == true)
        {
            Light.color = LightColorDes;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // FlashlightMode.performed += OnChangeFlashlightMode;
        grabInteractable = GetComponent<XRGrabInteractable>();
        rayInteractor = GetComponent<XRRayInteractor>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isInteractableInSocket == true)
        {
            Light.spotAngle = NewSpotAngle;
            Light.intensity = NewIntensity;
            rayInteractor.enabled = false;
            int DeactivateColl = LayerMask.NameToLayer("Body Socket");
            SetLayerRecursively(this.gameObject, DeactivateColl);
        } else if (isInteractableInSocket == false)
        {
            Light.spotAngle = OGSpotAngle;
            Light.intensity = OGIntensity;
            int ReactivateColl = LayerMask.NameToLayer("Flashlight");
            SetLayerRecursively(this.gameObject, ReactivateColl);

            if(ModAdditif == true)
            {
                rayInteractor.raycastMask = raycastMaskAdd;
                Light.color = LightColorAdd;
            } else if (ModDestructif == true)
            {
                rayInteractor.raycastMask = raycastMaskDes;
                Light.color = LightColorDes;
            }

            // Debug.Log("FL : " + grabInteractable.isSelected);
            if (grabInteractable.isSelected)
            {
                rayInteractor.enabled = true;
                // Debug.Log("Object is currently grabbed");
            }
            else if (grabInteractable.isSelected == false)
            {
                rayInteractor.enabled = false;
                // Debug.Log("Object is not currently grabbed");
            }
        }
        
    }

    void OnChangeFlashlightMode(InputAction.CallbackContext context)
    {
        if (grabInteractable.isSelected && isInteractableInSocket == false && IsUpgraded)
        {
            audioManager.PlayOneShot("Flashlight Switch");
            // Debug.Log("Object is currently grabbed");
            if (ModAdditif == true)
            {   
                ModDestructif = true;
                ModAdditif = false;
                Light.color = LightColorDes;
                Debug.Log("ModDestructif");

            } else if (ModDestructif == true)
            {
                ModDestructif = false;
                ModAdditif = true;
                Light.color = LightColorAdd;
                Debug.Log("ModAdditif");
            }

        }
    }

    private void OnEnable()
    {
        GetComponent<XRGrabInteractable>().onSelectEntered.AddListener(OnGrabbed);
        GetComponent<XRGrabInteractable>().onSelectExited.AddListener(OnReleased);
    }

    private void OnDisable()
    {
        GetComponent<XRGrabInteractable>().onSelectEntered.RemoveListener(OnGrabbed);
        GetComponent<XRGrabInteractable>().onSelectExited.RemoveListener(OnReleased);
    }

    private void OnGrabbed(XRBaseInteractor interactor)
    {
        // currentInteractor = interactor;
        if (interactor == LDirect || interactor == LRay)
        {
            // Debug.Log("Object grabbed by Left");
            L_FlashlightMode.action.performed += OnChangeFlashlightMode;
            L_FlashlightMode.action.Enable();
            R_FlashlightMode.action.performed -= OnChangeFlashlightMode;
        } else if (interactor == RDirect || interactor == RRay)
        {
            // Debug.Log("Object grabbed by Right");
            R_FlashlightMode.action.performed += OnChangeFlashlightMode;
            R_FlashlightMode.action.Enable();
            L_FlashlightMode.action.performed -= OnChangeFlashlightMode;
        }
        // Debug.Log("Object grabbed by " + interactor.name);
    }

    private void OnReleased(XRBaseInteractor interactor)
    {
        // currentInteractor = null;
        Debug.Log("Object released by " + interactor.name);
    }

    public static void SetLayerRecursively(GameObject obj, int newLayer)
    {
    obj.layer = newLayer;

    foreach (Transform child in obj.transform)
    {
        SetLayerRecursively(child.gameObject, newLayer);
    }

    }
}
