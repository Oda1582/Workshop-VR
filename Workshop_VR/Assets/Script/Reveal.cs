using UnityEngine;
using System.Collections;
using UnityEngine.XR.Interaction.Toolkit;

[ExecuteInEditMode]
// [RequireComponent(typeof(Collider))] // Add this to ensure there is always a collider componentv
public class Reveal : MonoBehaviour
{
    [SerializeField] Material Mat;
    [SerializeField] Light SpotLight;
    [SerializeField] FlashlightScript RefFL;
    [SerializeField] Vector4 DeactivateMaterial = new Vector4(0f, 0f, 0f, 0f);
    public bool ObjAdditif = true; 
    public bool ObjDestructif = false;
    public bool ObjInteractable = false;
    public XRGrabInteractable ObjgrabInteractable;
    public XRRayInteractor FRay;

    public Coroutine coroutine;
    public Shader AddReveal;
    public Shader DesReveal;
    public Shader Standard;
    public Shader Invisible;
    public Shader BarelyVisible;
    bool IsHovered = false;
    bool IsStopped = false;
    bool NotSelectedIsStopped = false;
    bool BeforeCoroutine = true;
    bool AfterCoroutine = false;
    bool IE_IsStoppedBefore, IE_NotSelectedIsStoppedBefore, IE_IsHoveredBefore;
    bool IE_IsStoppedAfter, IE_NotSelectedIsStoppedAfter, IE_IsHoveredAfter;
    bool Hovering = false;
    public AudioManager AudioManager;
	public Renderer rendererAudio;

    void Awake()
    {
        AddReveal = Shader.Find("Revealing Under Light");
        DesReveal = Shader.Find("DesRevealing Under Light");
        Standard = Shader.Find("Standard");
        Invisible = Shader.Find("Invisible");
        BarelyVisible = Shader.Find("Barely Visible");

        if (ObjInteractable == true && ObjgrabInteractable != null)
        {
        ObjgrabInteractable = GetComponent<XRGrabInteractable>();
        }

        if (ObjDestructif == true)
        {
            if (ObjInteractable == true)
            {
                int IntObjDes = LayerMask.NameToLayer("IntDestructiveOff");
                SetLayerRecursively(this.gameObject, IntObjDes);
                SetShaderRecursively(this.gameObject, DesReveal);
                // Mat.shader = DesReveal;
                Mat.SetFloat ("MyStrengthScalor", -100f);
            } else if (ObjInteractable == false)
            {
                int ObjDes = LayerMask.NameToLayer("DestructiveOff");
                SetLayerRecursively(this.gameObject, ObjDes);
                // SetShaderRecursively(this.gameObject, DesReveal);
                Mat.shader = DesReveal;
                Mat.SetFloat ("MyStrengthScalor", -100f);
            }
        } 
        else if (ObjAdditif == true)
        {
            if (ObjInteractable == true)
            {
                int IntObjAdd = LayerMask.NameToLayer("IntAdditiveOff");
                SetLayerRecursively(this.gameObject, IntObjAdd);
                SetShaderRecursively(this.gameObject, AddReveal);
                // Mat.shader = AddReveal;
                Mat.SetFloat ("MyStrengthScalor", 100f);
            } else if (ObjInteractable == false)
            {
                int ObjAdd = LayerMask.NameToLayer("AdditiveOff");
                SetLayerRecursively(this.gameObject, ObjAdd);
                // SetShaderRecursively(this.gameObject, AddReveal);
                Mat.shader = AddReveal;
                Mat.SetFloat ("MyStrengthScalor", 100f);
            }
        }
    }

    void Start()
    {

    }

	void Update ()
    {
        if (ObjAdditif == true && RefFL.ModAdditif == true)
        {
            Mat.SetVector("MyLightPosition",  SpotLight.transform.position);
            Mat.SetVector("MyLightDirection", -SpotLight.transform.forward );
            Mat.SetFloat ("MyLightAngle", SpotLight.spotAngle);
        } 
        else if (ObjDestructif == true && RefFL.ModDestructif == true)
        {
            Mat.SetVector("MyLightPosition",  SpotLight.transform.position);
            Mat.SetVector("MyLightDirection", -SpotLight.transform.forward );
            Mat.SetFloat ("MyLightAngle", SpotLight.spotAngle);
        } 
        else 
        {
        Mat.SetVector("MyLightPosition", DeactivateMaterial);
        Mat.SetVector("MyLightDirection", DeactivateMaterial);
        Mat.SetFloat ("MyLightAngle", 0f);
        }

        // Debug.Log(SpotLight.transform.position);
        // Debug.Log(-SpotLight.transform.forward);
        // Debug.Log(SpotLight.spotAngle);
        
        if (Hovering == true)
        {
            if (coroutine != null)
            {
                StopCoroutine(coroutine);
                HoveredCoroutine();
            } else if (coroutine == null)
            {
                HoveredCoroutine();
            }
        }
        
        // Debug.Log("BeforeCoroutine : " + BeforeCoroutine);
        // Debug.Log("AfterCoroutine : " + AfterCoroutine);
        // Debug.Log("IsStopped : " + IsStopped + " + IE_IsStoppedBefore : " + IE_IsStoppedBefore + " + IE_IsStoppedAfter : " + IE_IsStoppedAfter);
        // Debug.Log("IsStopped : " + IsStopped);
        // Debug.Log("IE_IsStoppedBefore : " + IE_IsStoppedBefore);
        // Debug.Log("IE_IsStoppedAfter : " + IE_IsStoppedAfter);
        // Debug.Log("NotSelectedIsStopped : " + NotSelectedIsStopped + " + IE_NotSelectedIsStoppedBefore : " + IE_NotSelectedIsStoppedBefore + " + IE_NotSelectedIsStoppedAfter : " + IE_NotSelectedIsStoppedAfter);
        // Debug.Log("NotSelectedIsStopped : " + NotSelectedIsStopped);
        // Debug.Log("IE_NotSelectedIsStoppedBefore : " + IE_NotSelectedIsStoppedBefore);
        // Debug.Log("IE_NotSelectedIsStoppedAfter : " + IE_NotSelectedIsStoppedAfter);
        // Debug.Log("IsHovered : " + IsHovered + " + IE_IsHoveredBefore : " + IE_IsHoveredBefore + " + IE_IsHoveredAfter : " + IE_IsHoveredAfter);
        // Debug.Log("IsHovered : " + IsHovered);
        // Debug.Log("IE_IsHoveredBefore : " + IE_IsHoveredBefore);
        // Debug.Log("IE_IsHoveredAfter : " + IE_IsHoveredAfter);
        // Debug.Log("Hovering : " + Hovering);
        
        // if (ObjInteractable == true)
        // {
        // if (ObjgrabInteractable.isSelected)
        // {
        //     Debug.Log("Object is currently grabbed");
        // }
        //     else if (ObjgrabInteractable.isSelected == false)
        // {
        //     Debug.Log("not currently grabbed");
        // }
        // }

        if (IsHovered == true && ObjInteractable == true)
        {
        if (ObjgrabInteractable.isSelected && IsStopped == false)
        {
            Debug.Log("Coroutine Stopped grab");
            // BeforeCoroutine = true;
            // AfterCoroutine = false;
            IsStopped = true;
            NotSelectedIsStopped = false;
            StopCoroutine(coroutine);
        } else if (ObjgrabInteractable.isSelected == false && NotSelectedIsStopped == false)
        {
            Debug.Log("Get stopped");           
            // BeforeCoroutine = false;
            // AfterCoroutine = true;
            NotSelectedIsStopped = true;
            IsStopped = false;
            // IsHovered = false; 
            // LastCoroutine();
            HoveredCoroutine();
        }
        }
    }

    public void HoveringEnter(HoverEnterEventArgs args)
    {
        if (args.interactor == FRay)
        {
            // The ray is coming from an XR controller or hand
            // Debug.Log("Hovering over game object with " + args.interactor.name);
            if (ObjInteractable == true)
            {
                if (RefFL.grabInteractable.isSelected && ObjgrabInteractable.isSelected == false)
                {
                    Hovering = true;
                    FirstCoroutine();
                }
            } else if (ObjInteractable == false)
            {
                if (RefFL.grabInteractable.isSelected)
                {
                    Hovering = true;
                    FirstCoroutine();
                }  
            }
        }

    }

        public void HoveringExit()
    {
        Hovering = false;
    }

    public void FirstCoroutine()
    {
        if (rendererAudio.sharedMaterial.shader == AddReveal)
        {
        AudioManager.PlayOneShot("Discovered");
        }

        if (ObjDestructif == true && RefFL.ModDestructif == true)
            {
                if (ObjInteractable == true)
                {
                    if (coroutine != null)
                    {
                        StopCoroutine(coroutine);
                        coroutine = StartCoroutine(ChangeLayer(BarelyVisible, DesReveal, "IntDestructiveOn", "IntDestructiveOff", IE_IsStoppedBefore = false, IE_IsStoppedAfter = true, IE_NotSelectedIsStoppedBefore = true, IE_NotSelectedIsStoppedAfter = true, IE_IsHoveredBefore = true, IE_IsHoveredAfter = false));
                    } else if (coroutine == null)
                    {
                        coroutine = StartCoroutine(ChangeLayer(BarelyVisible, DesReveal, "IntDestructiveOn", "IntDestructiveOff", IE_IsStoppedBefore = false, IE_IsStoppedAfter = true, IE_NotSelectedIsStoppedBefore = true, IE_NotSelectedIsStoppedAfter = true, IE_IsHoveredBefore = true, IE_IsHoveredAfter = false));
                    }
                } else if (ObjInteractable == false)
                {
                    if (coroutine != null)
                    {
                        StopCoroutine(coroutine);
                        coroutine = StartCoroutine(ChangeLayer(Invisible, DesReveal, "DestructiveOn", "DestructiveOff", IE_IsStoppedBefore = false, IE_IsStoppedAfter = true, IE_NotSelectedIsStoppedBefore = true, IE_NotSelectedIsStoppedAfter = true, IE_IsHoveredBefore = true, IE_IsHoveredAfter = false));
                    } else if (coroutine == null)
                    {
                        coroutine = StartCoroutine(ChangeLayer(Invisible, DesReveal, "DestructiveOn", "DestructiveOff", IE_IsStoppedBefore = false, IE_IsStoppedAfter = true, IE_NotSelectedIsStoppedBefore = true, IE_NotSelectedIsStoppedAfter = true, IE_IsHoveredBefore = true, IE_IsHoveredAfter = false));
                    }
                }
            } 
            else if (ObjAdditif == true && RefFL.ModAdditif == true)
            {
                if (ObjInteractable == true)
                {
                    if (coroutine != null)
                    {
                        StopCoroutine(coroutine);
                        coroutine = StartCoroutine(ChangeLayer(Standard, AddReveal, "IntAdditiveOn", "IntAdditiveOff", IE_IsStoppedBefore = false, IE_IsStoppedAfter = true, IE_NotSelectedIsStoppedBefore = true, IE_NotSelectedIsStoppedAfter = true, IE_IsHoveredBefore = true, IE_IsHoveredAfter = false));
                        Debug.Log("Get Hovered");
                    } else if (coroutine == null)
                    {
                        coroutine = StartCoroutine(ChangeLayer(Standard, AddReveal, "IntAdditiveOn", "IntAdditiveOff", IE_IsStoppedBefore = false, IE_IsStoppedAfter = true, IE_NotSelectedIsStoppedBefore = true, IE_NotSelectedIsStoppedAfter = true, IE_IsHoveredBefore = true, IE_IsHoveredAfter = false));
                        Debug.Log("Get Hovered");
                    }
                } else if (ObjInteractable == false)
                {
                    if (coroutine != null)
                    {
                        StopCoroutine(coroutine);
                        coroutine = StartCoroutine(ChangeLayer(Standard, AddReveal, "AdditiveOn", "AdditiveOff", IE_IsStoppedBefore = false, IE_IsStoppedAfter = true, IE_NotSelectedIsStoppedBefore = true, IE_NotSelectedIsStoppedAfter = true, IE_IsHoveredBefore = true, IE_IsHoveredAfter = false));
                    } else if (coroutine == null)
                    {
                        coroutine = StartCoroutine(ChangeLayer(Standard, AddReveal, "AdditiveOn", "AdditiveOff", IE_IsStoppedBefore = false, IE_IsStoppedAfter = true, IE_NotSelectedIsStoppedBefore = true, IE_NotSelectedIsStoppedAfter = true, IE_IsHoveredBefore = true, IE_IsHoveredAfter = false));
                    }
                }
            }
    }

    public void LastCoroutine()
    {
        if (ObjDestructif == true)
            {
                if (ObjInteractable == true)
                {
                    if (coroutine != null)
                    {
                    StopCoroutine(coroutine);
                    coroutine = StartCoroutine(ChangeLayer(BarelyVisible, DesReveal, "IntDestructiveOn", "IntDestructiveOff", IE_IsStoppedBefore = false, IE_IsStoppedAfter = true, IE_NotSelectedIsStoppedBefore = true, IE_NotSelectedIsStoppedAfter = true, IE_IsHoveredBefore = false, IE_IsHoveredAfter = false));
                    } else if (coroutine == null)
                    {
                    coroutine = StartCoroutine(ChangeLayer(BarelyVisible, DesReveal, "IntDestructiveOn", "IntDestructiveOff", IE_IsStoppedBefore = false, IE_IsStoppedAfter = true, IE_NotSelectedIsStoppedBefore = true, IE_NotSelectedIsStoppedAfter = true, IE_IsHoveredBefore = false, IE_IsHoveredAfter = false));
                    }
                } else if (ObjInteractable == false)
                {
                    if (coroutine != null)
                    {
                        StopCoroutine(coroutine);
                        coroutine = StartCoroutine(ChangeLayer(Invisible, DesReveal, "DestructiveOn", "DestructiveOff", IE_IsStoppedBefore = false, IE_IsStoppedAfter = true, IE_NotSelectedIsStoppedBefore = true, IE_NotSelectedIsStoppedAfter = true, IE_IsHoveredBefore = false, IE_IsHoveredAfter = false));
                    } else if (coroutine == null)
                    {
                        coroutine = StartCoroutine(ChangeLayer(Invisible, DesReveal, "DestructiveOn", "DestructiveOff", IE_IsStoppedBefore = false, IE_IsStoppedAfter = true, IE_NotSelectedIsStoppedBefore = true, IE_NotSelectedIsStoppedAfter = true, IE_IsHoveredBefore = false, IE_IsHoveredAfter = false));
                    }
                }
            } 
            else if (ObjAdditif == true)
            {
                if (ObjInteractable == true)
                {
                    if (coroutine != null)
                    {
                        StopCoroutine(coroutine);
                        coroutine = StartCoroutine(ChangeLayer(Standard, AddReveal, "IntAdditiveOn", "IntAdditiveOff", IE_IsStoppedBefore = false, IE_IsStoppedAfter = true, IE_NotSelectedIsStoppedBefore = true, IE_NotSelectedIsStoppedAfter = true, IE_IsHoveredBefore = false, IE_IsHoveredAfter = false));
                    } else if (coroutine == null)
                    {
                        coroutine = StartCoroutine(ChangeLayer(Standard, AddReveal, "IntAdditiveOn", "IntAdditiveOff", IE_IsStoppedBefore = false, IE_IsStoppedAfter = true, IE_NotSelectedIsStoppedBefore = true, IE_NotSelectedIsStoppedAfter = true, IE_IsHoveredBefore = false, IE_IsHoveredAfter = false));
                    }
                } else if (ObjInteractable == false)
                {
                    if (coroutine != null)
                    {
                        StopCoroutine(coroutine);
                        coroutine = StartCoroutine(ChangeLayer(Standard, AddReveal, "AdditiveOn", "AdditiveOff", IE_IsStoppedBefore = false, IE_IsStoppedAfter = true, IE_NotSelectedIsStoppedBefore = true, IE_NotSelectedIsStoppedAfter = true, IE_IsHoveredBefore = false, IE_IsHoveredAfter = false));
                    } else if (coroutine == null)
                    {
                        coroutine = StartCoroutine(ChangeLayer(Standard, AddReveal, "AdditiveOn", "AdditiveOff", IE_IsStoppedBefore = false, IE_IsStoppedAfter = true, IE_NotSelectedIsStoppedBefore = true, IE_NotSelectedIsStoppedAfter = true, IE_IsHoveredBefore = false, IE_IsHoveredAfter = false));
                    }
                }
            }
    }

    public void HoveredCoroutine()
    {
        if (ObjDestructif == true)
            {
                if (ObjInteractable == true)
                {
                    if (coroutine != null)
                    {
                        StopCoroutine(coroutine);
                        coroutine = StartCoroutine(ChangeLayer(BarelyVisible, DesReveal, "IntDestructiveOn", "IntDestructiveOff", IE_IsStoppedBefore = false, IE_IsStoppedAfter = true, IE_NotSelectedIsStoppedBefore = true, IE_NotSelectedIsStoppedAfter = true, IE_IsHoveredBefore = true, IE_IsHoveredAfter = false));
                    } else if (coroutine == null)
                    {
                        coroutine = StartCoroutine(ChangeLayer(BarelyVisible, DesReveal, "IntDestructiveOn", "IntDestructiveOff", IE_IsStoppedBefore = false, IE_IsStoppedAfter = true, IE_NotSelectedIsStoppedBefore = true, IE_NotSelectedIsStoppedAfter = true, IE_IsHoveredBefore = true, IE_IsHoveredAfter = false));
                    }
                } else if (ObjInteractable == false)
                {
                    if (coroutine != null)
                    {
                        StopCoroutine(coroutine);
                        coroutine = StartCoroutine(ChangeLayer(Invisible, DesReveal, "DestructiveOn", "DestructiveOff", IE_IsStoppedBefore = false, IE_IsStoppedAfter = true, IE_NotSelectedIsStoppedBefore = true, IE_NotSelectedIsStoppedAfter = true, IE_IsHoveredBefore = true, IE_IsHoveredAfter = false));
                    } else if (coroutine == null)
                    {
                        coroutine = StartCoroutine(ChangeLayer(Invisible, DesReveal, "DestructiveOn", "DestructiveOff", IE_IsStoppedBefore = false, IE_IsStoppedAfter = true, IE_NotSelectedIsStoppedBefore = true, IE_NotSelectedIsStoppedAfter = true, IE_IsHoveredBefore = true, IE_IsHoveredAfter = false));
                    }
                }
            } 
            else if (ObjAdditif == true)
            {
                if (ObjInteractable == true)
                {
                    if (coroutine != null)
                    {
                        StopCoroutine(coroutine);
                        coroutine = StartCoroutine(ChangeLayer(Standard, AddReveal, "IntAdditiveOn", "IntAdditiveOff", IE_IsStoppedBefore = false, IE_IsStoppedAfter = true, IE_NotSelectedIsStoppedBefore = true, IE_NotSelectedIsStoppedAfter = true, IE_IsHoveredBefore = true, IE_IsHoveredAfter = false));
                    } else if (coroutine == null)
                    {
                        coroutine = StartCoroutine(ChangeLayer(Standard, AddReveal, "IntAdditiveOn", "IntAdditiveOff", IE_IsStoppedBefore = false, IE_IsStoppedAfter = true, IE_NotSelectedIsStoppedBefore = true, IE_NotSelectedIsStoppedAfter = true, IE_IsHoveredBefore = true, IE_IsHoveredAfter = false));
                    }
                } else if (ObjInteractable == false)
                {
                    if (coroutine != null)
                    {
                        StopCoroutine(coroutine);
                        coroutine = StartCoroutine(ChangeLayer(Standard, AddReveal, "AdditiveOn", "AdditiveOff", IE_IsStoppedBefore = false, IE_IsStoppedAfter = true, IE_NotSelectedIsStoppedBefore = true, IE_NotSelectedIsStoppedAfter = true, IE_IsHoveredBefore = true, IE_IsHoveredAfter = false));
                    } else if (coroutine == null)
                    {
                        coroutine = StartCoroutine(ChangeLayer(Standard, AddReveal, "AdditiveOn", "AdditiveOff", IE_IsStoppedBefore = false, IE_IsStoppedAfter = true, IE_NotSelectedIsStoppedBefore = true, IE_NotSelectedIsStoppedAfter = true, IE_IsHoveredBefore = true, IE_IsHoveredAfter = false));
                    }
                }
            }
    }
    
    IEnumerator ChangeLayer(Shader ApplyShader, Shader RevertShader, string ApplyLayerName, string RevertLayerName, bool IE_IsStoppedBefore, bool IE_IsStoppedAfter, bool IE_NotSelectedIsStoppedBefore, bool IE_NotSelectedIsStoppedAfter, bool IE_IsHoveredBefore, bool IE_IsHoveredAfter)
    {
        //Before
        //mettre un if before
        // if (BeforeCoroutine == true)
        // {
        IsStopped = IE_IsStoppedBefore;
        NotSelectedIsStopped = IE_NotSelectedIsStoppedBefore;
        IsHovered = IE_IsHoveredBefore;
        // }
        // Debug.Log("IE_IsHovered : " + IE_IsHovered);

        //Shader
        SetShaderRecursively(this.gameObject, ApplyShader);
        // Mat.shader = ApplyShader;

        //Layer
        int LayerBefore = LayerMask.NameToLayer(ApplyLayerName);
        SetLayerRecursively(this.gameObject, LayerBefore);

        yield return new WaitForSeconds(5);

        //After / stop
        //mettre un if after
        // if (AfterCoroutine == true)
        // {
        IsStopped = IE_IsStoppedAfter;
        NotSelectedIsStopped = IE_NotSelectedIsStoppedAfter;
        IsHovered = IE_IsHoveredAfter;
        // }

        //Shader
        SetShaderRecursively(this.gameObject, RevertShader);
        // Mat.shader = RevertShader;

        //Layer
        int LayerAfter = LayerMask.NameToLayer(RevertLayerName);
        SetLayerRecursively(this.gameObject, LayerAfter);

        if (rendererAudio.sharedMaterial.shader == AddReveal)
        {
        AudioManager.PlayOneShot("Disappear");
        }

    }

    public static void SetLayerRecursively(GameObject obj, int newLayer)
    {
    obj.layer = newLayer;

    foreach (Transform child in obj.transform)
    {
        SetLayerRecursively(child.gameObject, newLayer);
    }

    }

    public void SetShaderRecursively(GameObject obj, Shader NewShader)
    {
    
    Renderer renderer = obj.GetComponent<Renderer>();
    if (renderer != null)
    {
        renderer.sharedMaterial.shader = NewShader;
    }

    foreach (Transform child in obj.transform)
    {
        SetShaderRecursively(child.gameObject, NewShader);
    }

    }

}