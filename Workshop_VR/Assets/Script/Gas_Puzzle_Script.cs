using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gas_Puzzle_Script : MonoBehaviour
{
    public Wheel_Puzzle_Script WheelDes1;

    public bool Wheel1, Wheel2, Wheel3, Wheel4, Wheel5, Wheel6;
    public Animator DoorGas;
    public Material Mat_White, Mat_Red, Mat_Green;
    public LightController LightController1, LightController2, LightControllerL, LightControllerR;
    public Light LightRoom1, LightRoom2, LightRoomL, LightRoomR;
    public MeshRenderer MeshLight1, MeshLight2, MeshLightL, MeshLightR;
    public AudioManager AudioManager;
    public bool OneTime1 = false, OneTime2 = false, OneTime3 = false;
    public DoorScript DoorScript;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Wheel1 && Wheel2 && Wheel3 && OneTime1 == false)
        {
            OneTime1 = true;
            LightControllerL.ScaleIntensity(1f, 3.0f);
            LightRoomL.color = Color.green;
            MeshLightL.material = Mat_Green;
            AudioManager.PlayOneShot("Pressure");
        }

        if (Wheel4 && Wheel5 && Wheel6 && OneTime2 == false)
        {
            OneTime2 = true;
            LightControllerR.ScaleIntensity(1f, 3.0f);
            LightRoomR.color = Color.green;
            MeshLightR.material = Mat_Green;
            AudioManager.PlayOneShot("Pressure");
        }

        if (Wheel1 && Wheel2 && Wheel3 && Wheel4 && Wheel5 && Wheel6 && OneTime3 == false)
        {
            // Debug.Log("The room is now depresurized !");
            OneTime3 = true;
            DoorGas.SetTrigger("Open");
            DoorScript.DoorOff = false;
            DoorScript.DoorOn = true;
            DoorScript.DoorOnMat();
            AudioManager.Play("Sci-fi Door Opening");
            LightController1.ScaleIntensity(1f, 3.0f);
            LightController2.ScaleIntensity(1f, 3.0f);
            LightRoom1.color = Color.white;
            // LightRoom2.color = Color.white;
            MeshLight1.material = Mat_White;
            // MeshLight2.material = Mat_White;
        }
    }
}
