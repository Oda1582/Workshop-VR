using UnityEngine;
using System.Collections;
using UnityEngine.XR.Interaction.Toolkit;

public class ColliderActivator : MonoBehaviour
{
    public FlashlightScript RefFL;
    Coroutine coroutine;
    public Reveal RefMod;
    [SerializeField] Material Mat;
    Shader AddReveal;
    Shader DesReveal;
    Shader Interactable;

    void Start()
    {
        AddReveal = Shader.Find("Revealing Under Light");
        DesReveal = Shader.Find("DesRevealing Under Light");
        Interactable = Shader.Find("Standard");
    }

    void update()
    {

    }

    public void HoveringEnter()
    {
        if (RefFL.grabInteractable.isSelected)
        {
            ObjCoroutine();
        }
    }

    public void ObjCoroutine()
    {
        if (RefMod.ObjDestructif == true && RefFL.ModDestructif == true)
            {
                if (RefMod.ObjInteractable == true)
                {
                    if (coroutine != null)
                    {
                    StopCoroutine(coroutine);
                    coroutine = StartCoroutine(ChangeLayerIntDes());
                    } else if (coroutine == null)
                    {
                    coroutine = StartCoroutine(ChangeLayerIntDes());
                    }
                } else if (coroutine != null)
                {
                    StopCoroutine(coroutine);
                    coroutine = StartCoroutine(ChangeLayerDes());
                } else if (coroutine == null)
                {
                    coroutine = StartCoroutine(ChangeLayerDes());
                }
            } 
            else if (RefMod.ObjAdditif == true && RefFL.ModAdditif == true)
            {
                if (RefMod.ObjInteractable == true)
                {
                    if (coroutine != null)
                    {
                    StopCoroutine(coroutine);
                    coroutine = StartCoroutine(ChangeLayerIntAdd());
                    } else if (coroutine == null)
                    {
                    coroutine = StartCoroutine(ChangeLayerIntAdd());
                    }
                } else if (coroutine != null)
                {
                StopCoroutine(coroutine);
                coroutine = StartCoroutine(ChangeLayerAdd());
                } else if (coroutine == null)
                {
                coroutine = StartCoroutine(ChangeLayerAdd());
                }
            }
    }

    public void ObjCoroutineUpdate()
    {
        if (RefMod.ObjDestructif == true)
            {
                if (RefMod.ObjInteractable == true)
                {
                    if (coroutine != null)
                    {
                    StopCoroutine(coroutine);
                    coroutine = StartCoroutine(ChangeLayerIntDes());
                    } else if (coroutine == null)
                    {
                    coroutine = StartCoroutine(ChangeLayerIntDes());
                    }
                } else if (coroutine != null)
                {
                    StopCoroutine(coroutine);
                    coroutine = StartCoroutine(ChangeLayerDes());
                } else if (coroutine == null)
                {
                    coroutine = StartCoroutine(ChangeLayerDes());
                }
            } 
            else if (RefMod.ObjAdditif == true)
            {
                if (RefMod.ObjInteractable == true)
                {
                    if (coroutine != null)
                    {
                    StopCoroutine(coroutine);
                    coroutine = StartCoroutine(ChangeLayerIntAdd());
                    } else if (coroutine == null)
                    {
                    coroutine = StartCoroutine(ChangeLayerIntAdd());
                    }
                } else if (coroutine != null)
                {
                StopCoroutine(coroutine);
                coroutine = StartCoroutine(ChangeLayerAdd());
                } else if (coroutine == null)
                {
                coroutine = StartCoroutine(ChangeLayerAdd());
                }
            }
    }
    
    public void HoveringExit()
    {

    }

    IEnumerator ChangeLayerIntDes()
    {
        int DestructiveOn = LayerMask.NameToLayer("IntDestructiveOn");
        gameObject.layer = DestructiveOn;
        Debug.Log("Coroutine started");
        Mat.shader = DesReveal;
        yield return new WaitForSeconds(5);
        int DestructiveOff = LayerMask.NameToLayer("IntDestructiveOff");
        gameObject.layer = DestructiveOff;
        Mat.shader = DesReveal;
        Debug.Log("Coroutine resumed after waiting for 2 seconds");
    }

    IEnumerator ChangeLayerDes()
    {
        int DestructiveOn = LayerMask.NameToLayer("DestructiveOn");
        gameObject.layer = DestructiveOn;
        Debug.Log("Coroutine started");
        yield return new WaitForSeconds(5);
        int DestructiveOff = LayerMask.NameToLayer("DestructiveOff");
        gameObject.layer = DestructiveOff;
        Debug.Log("Coroutine resumed after waiting for 2 seconds");
    }
        IEnumerator ChangeLayerIntAdd()
    {
        int AdditiveOn = LayerMask.NameToLayer("IntAdditiveOn");
        gameObject.layer = AdditiveOn;
        Debug.Log("Coroutine started");
        yield return new WaitForSeconds(5);
        int AdditiveOff = LayerMask.NameToLayer("IntAdditiveOff");
        gameObject.layer = AdditiveOff;
        Debug.Log("Coroutine resumed after waiting for 2 seconds");
    }
        IEnumerator ChangeLayerAdd()
    {
        int AdditiveOn = LayerMask.NameToLayer("AdditiveOn");
        gameObject.layer = AdditiveOn;
        Debug.Log("Coroutine started");
        yield return new WaitForSeconds(5);
        int AdditiveOff = LayerMask.NameToLayer("AdditiveOff");
        gameObject.layer = AdditiveOff;
        Debug.Log("Coroutine resumed after waiting for 2 seconds");
    }
}
