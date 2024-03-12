using UnityEngine;
using System.Collections;
using UnityEngine.XR.Interaction.Toolkit;

public class IntColliderActivator : MonoBehaviour
{
    public FlashlightScript RefFL;
    Coroutine coroutine;
    public Reveal RefMod;
    public XRGrabInteractable ObjgrabInteractable;
    [SerializeField] Material Mat;
    Shader AddReveal;
    Shader DesReveal;
    Shader Standard;
    Shader Invisible;
    bool IsHovered = false;
    bool IsStopped = false;
    bool NotSelectedIsStopped = false;
    bool BeforeCoroutine = true;
    bool AfterCoroutine = false;
    bool IE_IsStopped, IE_NotSelectedIsStopped, IE_IsHovered;
    bool Hovering = false;

    void Start()
    {
        AddReveal = Shader.Find("Revealing Under Light");
        DesReveal = Shader.Find("DesRevealing Under Light");
        Standard = Shader.Find("Standard");
        Invisible = Shader.Find("Invisible");
        ObjgrabInteractable = GetComponent<XRGrabInteractable>();
    }

    void Update()
    {

        if (Hovering == true)
        {
            if (coroutine != null)
            {
                StopCoroutine(coroutine);
                FirstCoroutine();
            } else if (coroutine == null)
            {
                FirstCoroutine();
            }
        }

        // Debug.Log("IsHovered : " + IsHovered);
        // Debug.Log("IsStopped : " + IsStopped);
        // Debug.Log("NotSelectedIsStopped : " + NotSelectedIsStopped);
        // if (ObjgrabInteractable.isSelected)
        // {
        //     Debug.Log("Object is currently grabbed");
        // }
        //     else
        // {
        //     Debug.Log("not currently grabbed");
        // }

        if (IsHovered == true)
        {
        if (ObjgrabInteractable.isSelected && IsStopped == false)
        {
            Debug.Log("Coroutine Stopped grab");
            BeforeCoroutine = true;
            AfterCoroutine = false;
            IsStopped = true;
            NotSelectedIsStopped = false;
            StopCoroutine(coroutine);
        } else if (ObjgrabInteractable.isSelected == false && NotSelectedIsStopped == false)
        {
            Debug.Log("Get stopped");           
            BeforeCoroutine = false;
            AfterCoroutine = true;
            NotSelectedIsStopped = true;
            IsStopped = false;
            // IsHovered = false; 
            LastCoroutine();
        }
        }

    }


    public void HoveringEnter()
    {
        if (RefFL.grabInteractable.isSelected && ObjgrabInteractable.isSelected == false)
        {
            Hovering = true;
            FirstCoroutine();
        }
    }

        public void HoveringExit()
    {
        Hovering = false;
    }

    public void FirstCoroutine()
    {
        if (RefMod.ObjDestructif == true && RefFL.ModDestructif == true)
            {
                if (RefMod.ObjInteractable == true)
                {
                    if (coroutine != null)
                    {
                        StopCoroutine(coroutine);
                        coroutine = StartCoroutine(ChangeLayer(Invisible, DesReveal, "IntDestructiveOn", "IntDestructiveOff", IsStopped = false, NotSelectedIsStopped = false, IsHovered = true));
                    } else if (coroutine == null)
                    {
                        coroutine = StartCoroutine(ChangeLayer(Invisible, DesReveal, "IntDestructiveOn", "IntDestructiveOff", IsStopped = false, NotSelectedIsStopped = false, IsHovered = true));
                    }
                } else if (RefMod.ObjInteractable == false)
                {
                    if (coroutine != null)
                    {
                        StopCoroutine(coroutine);
                        coroutine = StartCoroutine(ChangeLayer(Invisible, DesReveal, "DestructiveOn", "DestructiveOff", IsStopped = false, NotSelectedIsStopped = false, IsHovered = true));
                    } else if (coroutine == null)
                    {
                        coroutine = StartCoroutine(ChangeLayer(Invisible, DesReveal, "DestructiveOn", "DestructiveOff", IsStopped = false, NotSelectedIsStopped = false, IsHovered = true));
                    }
                }
            } 
            else if (RefMod.ObjAdditif == true && RefFL.ModAdditif == true)
            {
                if (RefMod.ObjInteractable == true)
                {
                    if (coroutine != null)
                    {
                        StopCoroutine(coroutine);
                        coroutine = StartCoroutine(ChangeLayer(Standard, AddReveal, "IntAdditiveOn", "IntAdditiveOff", IsStopped = false, NotSelectedIsStopped = false, IsHovered = true));
                        Debug.Log("Get Hovered");
                    } else if (coroutine == null)
                    {
                        coroutine = StartCoroutine(ChangeLayer(Standard, AddReveal, "IntAdditiveOn", "IntAdditiveOff", IsStopped = false, NotSelectedIsStopped = false, IsHovered = true));
                        Debug.Log("Get Hovered");
                    }
                } else if (RefMod.ObjInteractable == false)
                {
                    if (coroutine != null)
                    {
                        StopCoroutine(coroutine);
                        coroutine = StartCoroutine(ChangeLayer(Standard, AddReveal, "AdditiveOn", "AdditiveOff", IE_IsStopped = false, IE_NotSelectedIsStopped = false, IE_IsHovered = true));
                    } else if (coroutine == null)
                    {
                        coroutine = StartCoroutine(ChangeLayer(Standard, AddReveal, "AdditiveOn", "AdditiveOff", IE_IsStopped = false, IE_NotSelectedIsStopped = false, IE_IsHovered = true));
                    }
                }
            }
    }

    public void LastCoroutine()
    {
        if (RefMod.ObjDestructif == true)
            {
                if (RefMod.ObjInteractable == true)
                {
                    if (coroutine != null)
                    {
                    StopCoroutine(coroutine);
                    coroutine = StartCoroutine(ChangeLayer(Invisible, DesReveal, "IntDestructiveOn", "IntDestructiveOff", IsStopped = true, NotSelectedIsStopped = true, IsHovered = false));
                    } else if (coroutine == null)
                    {
                    coroutine = StartCoroutine(ChangeLayer(Invisible, DesReveal, "IntDestructiveOn", "IntDestructiveOff", IsStopped = true, NotSelectedIsStopped = true, IsHovered = false));
                    }
                } else if (RefMod.ObjInteractable == false)
                {
                    if (coroutine != null)
                    {
                        StopCoroutine(coroutine);
                        coroutine = StartCoroutine(ChangeLayer(Invisible, DesReveal, "DestructiveOn", "DestructiveOff", IsStopped = true, NotSelectedIsStopped = true, IsHovered = false));
                    } else if (coroutine == null)
                    {
                        coroutine = StartCoroutine(ChangeLayer(Invisible, DesReveal, "DestructiveOn", "DestructiveOff", IsStopped = true, NotSelectedIsStopped = true, IsHovered = false));
                    }
                }
            } 
            else if (RefMod.ObjAdditif == true)
            {
                if (RefMod.ObjInteractable == true)
                {
                    if (coroutine != null)
                    {
                        StopCoroutine(coroutine);
                        coroutine = StartCoroutine(ChangeLayer(Standard, AddReveal, "IntAdditiveOn", "IntAdditiveOff", IE_IsStopped = true, IE_NotSelectedIsStopped = true, IE_IsHovered = false));
                    } else if (coroutine == null)
                    {
                        coroutine = StartCoroutine(ChangeLayer(Standard, AddReveal, "IntAdditiveOn", "IntAdditiveOff", IE_IsStopped = true, IE_NotSelectedIsStopped = true, IE_IsHovered = false));
                    }
                } else if (RefMod.ObjInteractable == false)
                {
                    if (coroutine != null)
                    {
                        StopCoroutine(coroutine);
                        coroutine = StartCoroutine(ChangeLayer(Standard, AddReveal, "AdditiveOn", "AdditiveOff", IE_IsStopped = true, IE_NotSelectedIsStopped = true, IE_IsHovered = false));
                    } else if (coroutine == null)
                    {
                        coroutine = StartCoroutine(ChangeLayer(Standard, AddReveal, "AdditiveOn", "AdditiveOff", IE_IsStopped = true, IE_NotSelectedIsStopped = true, IE_IsHovered = false));
                    }
                }
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

        IEnumerator ChangeLayer(Shader ApplyShader, Shader RevertShader, string ApplyLayerName, string RevertLayerName, bool IE_IsStopped, bool IE_NotSelectedIsStopped, bool IE_IsHovered)
    {
        //Before
        //mettre un if before
        if (BeforeCoroutine == true)
        {
        IE_IsStopped = IsStopped;
        IE_NotSelectedIsStopped = NotSelectedIsStopped;
        IE_IsHovered = IsHovered;
        }
        Debug.Log("IE_IsHovered : " + IE_IsHovered);

        //Shader
        Mat.shader = ApplyShader;

        //Layer
        int LayerBefore = LayerMask.NameToLayer(ApplyLayerName);
        SetLayerRecursively(this.gameObject, LayerBefore);

        yield return new WaitForSeconds(5);

        //After / stop
        //mettre un if after
        if (AfterCoroutine == true)
        {
        IsStopped = IE_IsStopped;
        NotSelectedIsStopped = IE_NotSelectedIsStopped;
        IsHovered = IE_IsHovered;
        }

        //Shader
        Mat.shader = RevertShader;

        //Layer
        int LayerAfter = LayerMask.NameToLayer(RevertLayerName);
        SetLayerRecursively(this.gameObject, LayerAfter);

    }

}
