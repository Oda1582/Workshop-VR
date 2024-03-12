using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleWithPivots : MonoBehaviour
{
    public GameObject StartObject;
    public GameObject EndObject;
    public GameObject MainComp;
    private Vector3 InitialScale;
    // Start is called before the first frame update
    void Start()
    {
        InitialScale = transform.localScale;
        UpdateTransformForScale();
    }

    // Update is called once per frame
    void Update()
    {
        if(StartObject.transform.hasChanged || EndObject.transform.hasChanged)
        {
            UpdateTransformForScale();
        }
    }

    void UpdateTransformForScale()
    {
        float distance =
            Vector3.Distance(a: StartObject.transform.position, b: EndObject.transform.position);
        transform.localScale = new Vector3(InitialScale.x, y: distance/6f, InitialScale.z);

        Vector3 middlePoint = (StartObject.transform.position + EndObject.transform.position) / 2f;
        transform.position = middlePoint;

        Vector3 rotationDirection = (EndObject.transform.position - StartObject.transform.position);
        transform.up = rotationDirection;
    }
}
