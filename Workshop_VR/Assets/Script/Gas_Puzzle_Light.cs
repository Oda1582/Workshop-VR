using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gas_Puzzle_Light : MonoBehaviour
{
    public Renderer MeshRenderer;
    public Color LightDeactivated;
    public Color LightActivated;
    public Material DeactivatedMat, ActivatedMat; 
    public Light LightComponent;

    // Start is called before the first frame update
    void Start()
    {
        MeshRenderer = GetComponent<MeshRenderer>();
        Transform childTransform = transform.Find("Point Light");
        if (childTransform != null)
        {
            LightComponent = childTransform.GetComponent<Light>();
        }
        else
        {
            Debug.LogWarning("Child not found.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DeactivateLight()
    {
        MeshRenderer.material = DeactivatedMat;
        LightComponent.color = LightDeactivated;
    }

    public void ActivateLight()
    {
        MeshRenderer.material = ActivatedMat;
        LightComponent.color = LightActivated;
    }
}
