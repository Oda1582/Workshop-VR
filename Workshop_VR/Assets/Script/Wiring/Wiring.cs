using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wiring : MonoBehaviour
{
    public GameObject Wiring1;
    public GameObject Wiring2;
    public GameObject Wiring3;
    public GameObject Wiring4;
    public GameObject Exit1;
    public GameObject Exit2;
    public GameObject Exit3;
    public GameObject Exit4;
    public LightController lightController;
    public bool Entry1 = false;
    public bool Entry2 = false;
    public bool Entry3 = false;
    public bool Entry4 = false;
    public float speed = 1f;
    public float height = 10f;
    private float startY;
    public DoorScript DoorScript;   
    public Animator ShutterAnim; 
    public Light LightRoom;
    public MeshRenderer MeshLight;
    public Material Mat_White, Mat_Red;
    public AudioManager AudioManager;
    public bool Onetime = false;
    public AudioSource ShutterSound;

    void Start()
    {
        
    }

    
    void Update()
    {
        if(Wiring1.transform.position == Exit1.transform.position)
        {
            Entry1 = true;
        }
        if(Wiring2.transform.position == Exit2.transform.position)
        {
            Entry2 = true;
        }
        if(Wiring3.transform.position == Exit3.transform.position)
        {
            Entry3 = true;
        }
        if(Wiring4.transform.position == Exit4.transform.position)
        {
            Entry4 = true;
        }

        if(Entry1 == true & Entry2 == true & Entry3 == true & Entry4 == true && Onetime == false)
        {
            Onetime = true;
            lightController.ScaleIntensity(3.0f, 3.0f);
            DoorScript.IsElectricityRunning = true;
            DoorScript.DoorOff = false;
            DoorScript.DoorOn = true;
            DoorScript.DoorOnMat();
            ShutterAnim.SetTrigger("Open");
            LightRoom.color = Color.white;
            MeshLight.material = Mat_White;
            AudioManager.Play("Power On");
            // AudioManager.PlayOneShot("Shutter Sound");*
            ShutterSound.Play();
        }

    }

}
