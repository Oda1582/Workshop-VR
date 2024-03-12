using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelColl_Puzzle_Script : MonoBehaviour
{
    public Wheel_Puzzle_Script WheelRef;
    public Collider Coll1, Coll2, Coll3, Coll4, Coll5, Coll6, Coll7, Coll8, Coll9, Coll10, Coll11, Coll12, Coll13, Coll14, Coll15;
    
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
        if (Coll1 != null && Coll == Coll1)
        {
            // Debug.Log("Coll1 has entered Collision.");
            WheelRef.Collision1 = true;
            // Add custom logic here
        } else if (Coll2 != null && Coll == Coll2)
        {
            // Debug.Log("Coll2 has entered Collision.");
            WheelRef.Collision2 = true;
            // Add custom logic here
        } else if (Coll3 != null && Coll == Coll3)
        {
            // Debug.Log("Coll3 has entered Collision.");
            WheelRef.Collision3 = true;
            // Add custom logic here
        } else if (Coll4 != null && Coll == Coll4)
        {
            // Debug.Log("Coll4 has entered Collision.");
            WheelRef.Collision4 = true;
            // Add custom logic here
        } else if (Coll5 != null && Coll == Coll5)
        {
            // Debug.Log("Coll5 has entered Collision.");
            WheelRef.Collision5 = true;
            // Add custom logic here
        } else if (Coll6 != null && Coll == Coll6)
        {
            // Debug.Log("Coll6 has entered Collision.");
            WheelRef.Collision6 = true;
            // Add custom logic here
        } else if (Coll7 != null && Coll == Coll7)
        {
            // Debug.Log("Coll7 has entered Collision.");
            WheelRef.Collision7 = true;
            // Add custom logic here
        } else if (Coll8 != null && Coll == Coll8)
        {
            // Debug.Log("Coll8 has entered Collision.");
            WheelRef.Collision8 = true;
            // Add custom logic here
        } else if (Coll9 != null && Coll == Coll9)
        {
            // Debug.Log("Coll9 has entered Collision.");
            WheelRef.Collision9 = true;
            // Add custom logic here
        } else if (Coll10 != null && Coll == Coll10)
        {
            // Debug.Log("Coll10 has entered Collision.");
            WheelRef.Collision10 = true;
            // Add custom logic here
        } else if (Coll11 != null && Coll == Coll11)
        {
            // Debug.Log("Coll11 has entered Collision.");
            WheelRef.Collision11 = true;
            // Add custom logic here
        } else if (Coll12 != null && Coll == Coll12)
        {
            // Debug.Log("Coll12 has entered Collision.");
            WheelRef.Collision12 = true;
            // Add custom logic here
        } else if (Coll13 != null && Coll == Coll13)
        {
            // Debug.Log("Coll13 has entered Collision.");
            WheelRef.Collision13 = true;
            // Add custom logic here
        } else if (Coll14 != null && Coll == Coll14)
        {
            // Debug.Log("Coll14 has entered Collision.");
            WheelRef.Collision14 = true;
            // Add custom logic here
        } else if (Coll15 != null && Coll == Coll15)
        {
            // Debug.Log("Coll15 has entered Collision.");
            WheelRef.Collision15 = true;
            // Add custom logic here
        }
    }

    private void OnTriggerExit(Collider Coll)
    {
        if (Coll1 != null && Coll == Coll1)
        {
            // Debug.Log("Coll1 has entered Collision.");
            WheelRef.Collision1 = false;
            // Add custom logic here
        } else if (Coll2 != null && Coll == Coll2)
        {
            // Debug.Log("Coll2 has entered Collision.");
            WheelRef.Collision2 = false;
            // Add custom logic here
        } else if (Coll3 != null && Coll == Coll3)
        {
            // Debug.Log("Coll3 has entered Collision.");
            WheelRef.Collision3 = false;
            // Add custom logic here
        } else if (Coll4 != null && Coll == Coll4)
        {
            // Debug.Log("Coll4 has entered Collision.");
            WheelRef.Collision4 = false;
            // Add custom logic here
        } else if (Coll5 != null && Coll == Coll5)
        {
            // Debug.Log("Coll5 has entered Collision.");
            WheelRef.Collision5 = false;
            // Add custom logic here
        } else if (Coll6 != null && Coll == Coll6)
        {
            // Debug.Log("Coll6 has entered Collision.");
            WheelRef.Collision6 = false;
            // Add custom logic here
        } else if (Coll7 != null && Coll == Coll7)
        {
            // Debug.Log("Coll7 has entered Collision.");
            WheelRef.Collision7 = false;
            // Add custom logic here
        } else if (Coll8 != null && Coll == Coll8)
        {
            // Debug.Log("Coll8 has entered Collision.");
            WheelRef.Collision8 = false;
            // Add custom logic here
        } else if (Coll9 != null && Coll == Coll9)
        {
            // Debug.Log("Coll9 has entered Collision.");
            WheelRef.Collision9 = false;
            // Add custom logic here
        } else if (Coll10 != null && Coll == Coll10)
        {
            // Debug.Log("Coll10 has entered Collision.");
            WheelRef.Collision10 = false;
            // Add custom logic here
        } else if (Coll11 != null && Coll == Coll11)
        {
            // Debug.Log("Coll11 has entered Collision.");
            WheelRef.Collision11 = false;
            // Add custom logic here
        } else if (Coll12 != null && Coll == Coll12)
        {
            // Debug.Log("Coll12 has entered Collision.");
            WheelRef.Collision12 = false;
            // Add custom logic here
        } else if (Coll13 != null && Coll == Coll13)
        {
            // Debug.Log("Coll13 has entered Collision.");
            WheelRef.Collision13 = false;
            // Add custom logic here
        } else if (Coll14 != null && Coll == Coll14)
        {
            // Debug.Log("Coll14 has entered Collision.");
            WheelRef.Collision14 = false;
            // Add custom logic here
        } else if (Coll15 != null && Coll == Coll15)
        {
            // Debug.Log("Coll15 has entered Collision.");
            WheelRef.Collision15 = false;
            // Add custom logic here
        }
    }
}
