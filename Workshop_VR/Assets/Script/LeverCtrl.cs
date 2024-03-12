using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverCtrl : MonoBehaviour
{
    public GameObject baseLever;
    public GameObject endLever;
    Quaternion firstRotation;
    Quaternion secondRotation;

    Rigidbody baseLeverRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        firstRotation = baseLever.transform.rotation;
        secondRotation = endLever.transform.rotation;

        baseLeverRigidbody = baseLever.GetComponent<Rigidbody>();  
    }

    // Update is called once per frame
    void Update()
    {
        firstRotation = baseLever.transform.rotation;
        if (firstRotation.z < secondRotation.z)
        {
            Debug.Log("coucou c moi guillaume je suis autiste et j'aime le chocolat");
            baseLeverRigidbody.isKinematic = true;

        }
    }
}
