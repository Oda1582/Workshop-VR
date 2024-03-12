using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel_Puzzle_Script : MonoBehaviour
{
    public bool Collision1 = false, Collision2 = false, Collision3 = false, Collision4 = false, Collision5 = false, Collision6 = false, Collision7 = false;
    public bool Collision8 = false, Collision9 = false, Collision10 = false, Collision11 = false, Collision12 = false, Collision13 = false, Collision14 = false, Collision15 = false;
    public bool Wheel1 = false, Wheel2 = false, Wheel3 = false, Wheel4 = false, Wheel5 = false, Wheel6 = false;
    public Gas_Puzzle_Script GasRef;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Wheel1 == true && Collision1 && Collision2 && Wheel1)
        {
            GasRef.Wheel1 = true;
        } else if (Wheel1 == true && Collision1 == false && Collision2 == false)
        {
            GasRef.Wheel1 = false;
        }

        if (Wheel2 == true && Collision3 && Collision4 && Collision5)
        {
            GasRef.Wheel2 = true;
        } else if (Wheel2 == true && Collision3 == false && Collision4 == false && Collision5 == false)
        {
            GasRef.Wheel2 = false;
        }

        if (Wheel3 == true && Collision6 && Collision7)
        {
            GasRef.Wheel3 = true;
        } else if (Wheel3 == true && Collision6 == false && Collision7 == false)
        {
            GasRef.Wheel3 = false;
        }
        
        if (Wheel4 == true && Collision8 && Collision9)
        {
            GasRef.Wheel4 = true;
        } else if (Wheel4 == true && Collision8 == false && Collision9 == false)
        {
            GasRef.Wheel4 = false;
        }

        if (Wheel5 == true && Collision10 && Collision11 && Collision12)
        {
            GasRef.Wheel5 = true;
        } else if (Wheel5 == true && Collision10 == false && Collision11 == false && Collision12 == false)
        {
            GasRef.Wheel5 = false;
        }

        if (Wheel6 == true && Collision13 && Collision14 && Collision15)
        {
            GasRef.Wheel6 = true;
        } else if (Wheel6 == true && Collision13 == false && Collision14 == false && Collision15 == false)
        {
            GasRef.Wheel6 = false;
        }
    }
}
