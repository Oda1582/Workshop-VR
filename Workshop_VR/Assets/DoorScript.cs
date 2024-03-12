using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public Animator DoorAnim;
    public bool IsElectricityRunning = true;
    public AudioManager AudioManager;
    public bool DoorOn = false, DoorOff = true;
    public Material Mat_On, Mat_Off;
    public MeshRenderer LDoor, RDoor, UDoor, FDoor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider Coll)
    {
        if (Coll.CompareTag("Player") && IsElectricityRunning)
        {
            DoorAnim.SetTrigger("Open");
            AudioManager.Play("Sci-fi Door Opening");
        }
    }

    void OnTriggerExit(Collider Coll)
    {
        if (Coll.CompareTag("Player") && IsElectricityRunning)
        {
            DoorAnim.SetTrigger("Close");
            AudioManager.Play("Sci-fi Door Opening");
        }
    }

    public void DoorOnMat()
    {
        if(DoorOn == true)
        {
            DoorOff = false;
            LDoor.material = Mat_On;

            // Update the RDoor materials array
            Material[] rDoorMaterials = RDoor.materials;
            if (rDoorMaterials.Length > 1)
            {
                rDoorMaterials[1] = Mat_On;
                RDoor.materials = rDoorMaterials;
            }
            else
            {
                Debug.LogWarning("RDoor has less than 2 materials.");
            }
            UDoor.material = Mat_On;
            FDoor.material = Mat_On;            

        }

    }

    public void DoorOffMat()
    {
        if(DoorOff == true)
        {
            DoorOn = false;
            LDoor.material = Mat_Off;
            Material[] rDoorMaterials = RDoor.materials;
            if (rDoorMaterials.Length > 1)
            {
                rDoorMaterials[1] = Mat_Off;
                RDoor.materials = rDoorMaterials;
            }
            else
            {
                Debug.LogWarning("RDoor has less than 2 materials.");
            }
            UDoor.material = Mat_Off;
            FDoor.material = Mat_Off;
        }
    }


}
