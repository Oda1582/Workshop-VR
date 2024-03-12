using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasColl_Puzzle_Light : MonoBehaviour
{
    public Gas_Puzzle_Light Light;
    public Collider Coll1, Coll2, Coll3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider Coll)
    {
        if (Light != null)
        {
            if (Coll1 != null && Coll == Coll1 || Coll2 != null && Coll == Coll2 || Coll3 != null && Coll == Coll3)
            {
                Light.ActivateLight();
            } 
        }

    }

    private void OnTriggerExit(Collider Coll)
    {
        if (Light != null)
        {
            if (Coll1 != null && Coll == Coll1 || Coll2 != null && Coll == Coll2 || Coll3 != null && Coll == Coll3)
            {
                Light.DeactivateLight();
            }
        }

    }
}
