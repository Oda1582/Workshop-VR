using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class UpgradeFlashlightScript : MonoBehaviour
{
    public FlashlightScript refFL;
    public CheckFL CheckFL;
    public DoorScript DoorScript;
    public Light LightRoom;
    public bool Onetime = false;
    public LightController LightController;
    public MeshRenderer MeshLight;
    public Material Mat_White, Mat_Red;
    public AudioManager AudioManager;
    public XRGrabInteractable WiringGrab1, WiringGrab2, WiringGrab3, WiringGrab4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpgradeFlashlight()
    {
        if(CheckFL.IsIn == true && Onetime == false)
        {
        refFL.IsUpgraded = true;
        refFL.ModDestructif = true;
        refFL.ModAdditif = false;
        refFL.Light.color = refFL.LightColorDes;
        DoorScript.IsElectricityRunning = false;
        DoorScript.DoorOn = false;
        DoorScript.DoorOff = true;
        DoorScript.DoorOffMat();
        LightController.ScaleIntensity(0.5f, 3.0f);
        LightRoom.color = Color.red;
        Onetime = true;
        MeshLight.material = Mat_Red;
        AudioManager.Play("Power Off");
        WiringGrab1.enabled = true;
        WiringGrab2.enabled = true;
        WiringGrab3.enabled = true;
        WiringGrab4.enabled = true;
        }
    }
}
