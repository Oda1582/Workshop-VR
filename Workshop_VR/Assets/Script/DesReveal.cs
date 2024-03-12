//Shady
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Collider))] // Add this to ensure there is always a collider component
public class DesReveal : MonoBehaviour
{
    [SerializeField] Material Mat;
    [SerializeField] Light SpotLight;
	
	void Update ()
    {
        Mat.SetVector("MyLightPosition",  SpotLight.transform.position);
        Mat.SetVector("MyLightDirection", -SpotLight.transform.forward );
        Mat.SetFloat ("MyLightAngle", SpotLight.spotAngle);
    }//Update() end
}//class end