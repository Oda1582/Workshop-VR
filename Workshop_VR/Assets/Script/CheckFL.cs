using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckFL : MonoBehaviour
{

    public bool IsIn = false;
    public GameObject Flashlight;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckFLinTrigger()
    {
        
    }

    private void OnTriggerEnter(Collider Coll)
    {
        if (Coll.gameObject == Flashlight)
        {
            IsIn = true;
        }
    }

    private void OnTriggerExit(Collider Coll)
    {
        if (Coll.gameObject == Flashlight)
        {
            IsIn = false;
        }
    }
}
