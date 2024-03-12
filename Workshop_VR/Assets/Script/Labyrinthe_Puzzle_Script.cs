using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Labyrinthe_Puzzle_Script : MonoBehaviour
{
    public Labyrinthe_Sphere_Script A1, A2, A3, A4, A5, B1, B2, B3, B4, B5, C1, C2, C3, C4, C5, D1, D2, D3, D4, D5, E1, E2, E3, E4, E5, F1, F2, F3, F4, F5;
    public Animator DoorAnim;
    public GameObject CompleteChecker;
    Renderer CompleteCheckerRenderer;
    public Material CompletedMat;
    public Light CompleteCheckerLight;
    public Color CompletedLightColor;
    public bool FirstMove = false;
    public AudioManager AudioManager;
    public DoorScript DoorScript;

    // Start is called before the first frame update
    void Start()
    {
        CompleteCheckerRenderer = CompleteChecker.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
                
    }

    public void ResetPuzzle()
    {
        AudioManager.Play("Wrong");
        FirstMove = false;
        A1.ResetSphere();
        A2.ResetSphere();
        A3.ResetSphere();
        A4.ResetSphere();
        A5.ResetSphere();
        B1.ResetSphere();
        B2.ResetSphere();
        B3.ResetSphere();
        B4.ResetSphere();
        B5.ResetSphere();
        C1.ResetSphere();
        C2.ResetSphere();
        C3.ResetSphere();
        C4.ResetSphere();
        C5.ResetSphere();
        D1.ResetSphere();
        D2.ResetSphere();
        D3.ResetSphere();
        D4.ResetSphere();
        D5.ResetSphere();
        E1.ResetSphere();
        E2.ResetSphere();
        E3.ResetSphere();
        E4.ResetSphere();
        E5.ResetSphere();
        F1.ResetSphere();
        F2.ResetSphere();
        F3.ResetSphere();
        F4.ResetSphere();
        F5.ResetSphere();
    }

    public void CompletedPuzzle()
    {
        DoorAnim.SetTrigger("Open");
        DoorScript.DoorOff = false;
        DoorScript.DoorOn = true;
        DoorScript.DoorOnMat();
        AudioManager.Play("Sci-fi Door Opening");
        AudioManager.Play("Completed");
        CompleteCheckerRenderer.material = CompletedMat;
        CompleteCheckerLight.color = CompletedLightColor;
        A1.CompletedSphere();
        A2.CompletedSphere();
        A3.CompletedSphere();
        A4.CompletedSphere();
        A5.CompletedSphere();
        B1.CompletedSphere();
        B2.CompletedSphere();
        B3.CompletedSphere();
        B4.CompletedSphere();
        B5.CompletedSphere();
        C1.CompletedSphere();
        C2.CompletedSphere();
        C3.CompletedSphere();
        C4.CompletedSphere();
        C5.CompletedSphere();
        D1.CompletedSphere();
        D2.CompletedSphere();
        D3.CompletedSphere();
        D4.CompletedSphere();
        D5.CompletedSphere();
        E1.CompletedSphere();
        E2.CompletedSphere();
        E3.CompletedSphere();
        E4.CompletedSphere();
        E5.CompletedSphere();
        F1.CompletedSphere();
        F2.CompletedSphere();
        F3.CompletedSphere();
        F4.CompletedSphere();
        F5.CompletedSphere();
        A1.GetComponent<MeshCollider>().enabled = false;
        A2.GetComponent<MeshCollider>().enabled = false;
        A3.GetComponent<MeshCollider>().enabled = false;
        A4.GetComponent<MeshCollider>().enabled = false;
        A5.GetComponent<MeshCollider>().enabled = false;
        B1.GetComponent<MeshCollider>().enabled = false;
        B2.GetComponent<MeshCollider>().enabled = false;
        B3.GetComponent<MeshCollider>().enabled = false;
        B4.GetComponent<MeshCollider>().enabled = false;
        B5.GetComponent<MeshCollider>().enabled = false;
        C1.GetComponent<MeshCollider>().enabled = false;
        C2.GetComponent<MeshCollider>().enabled = false;
        C3.GetComponent<MeshCollider>().enabled = false;
        C4.GetComponent<MeshCollider>().enabled = false;
        C5.GetComponent<MeshCollider>().enabled = false;
        D1.GetComponent<MeshCollider>().enabled = false;
        D2.GetComponent<MeshCollider>().enabled = false;
        D3.GetComponent<MeshCollider>().enabled = false;
        D4.GetComponent<MeshCollider>().enabled = false;
        D5.GetComponent<MeshCollider>().enabled = false;
        E1.GetComponent<MeshCollider>().enabled = false;
        E2.GetComponent<MeshCollider>().enabled = false;
        E3.GetComponent<MeshCollider>().enabled = false;
        E4.GetComponent<MeshCollider>().enabled = false;
        E5.GetComponent<MeshCollider>().enabled = false;
        F1.GetComponent<MeshCollider>().enabled = false;
        F2.GetComponent<MeshCollider>().enabled = false;
        F3.GetComponent<MeshCollider>().enabled = false;
        F4.GetComponent<MeshCollider>().enabled = false;
        F5.GetComponent<MeshCollider>().enabled = false;
    }

    public void CheckPuzzle()
    {
        if (A1.IsActivated == true || A2.IsActivated == true || A4.IsActivated == true || A5.IsActivated == true)
        {
            if (FirstMove == true)
            {
            ResetPuzzle();
            } else {
            FirstMove = true;
            }
        }

        if (B1.IsActivated == true || B4.IsActivated == true || B5.IsActivated == true)
        {
            if (FirstMove == true)
            {
            ResetPuzzle();
            } else {
            FirstMove = true;
            }    
        }

        if (C1.IsActivated == true)
        {
            if (FirstMove == true)
            {
            ResetPuzzle();
            } else {
            FirstMove = true;
            } 
        }

        if (D1.IsActivated == true || D2.IsActivated == true || D3.IsActivated == true)
        {
            if (FirstMove == true)
            {
            ResetPuzzle();
            } else {
            FirstMove = true;
            } 
        }

        if (E1.IsActivated == true || E5.IsActivated == true)
        {
            if (FirstMove == true)
            {
            ResetPuzzle();
            } else {
            FirstMove = true;
            } 
        }

        if (F1.IsActivated == true || F3.IsActivated == true || F4.IsActivated == true || F5.IsActivated == true)
        {
            if (FirstMove == true)
            {
            ResetPuzzle();
            } else {
            FirstMove = true;
            } 
        }

        if (A3.IsActivated == true)
        {
            Debug.Log("A Passed");
            if (B3.IsActivated == true && B2.IsActivated == true)
            {
                Debug.Log("B Passed");
                if (C2.IsActivated == true && C3.IsActivated == true && C4.IsActivated == true && C5.IsActivated == true)
                {
                    Debug.Log("C Passed");
                    if (D5.IsActivated == true && D4.IsActivated == true)
                    {
                        Debug.Log("D Passed");
                        if (E4.IsActivated == true && E3.IsActivated == true && E2.IsActivated == true)
                        {
                            Debug.Log("E Passed");
                            if (F2.IsActivated == true)
                            {                                
                                CompletedPuzzle();
                            }
                        }
                    }
                }

            }
        }

    }
}
