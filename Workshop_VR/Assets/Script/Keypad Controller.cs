using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class KeypadController : MonoBehaviour
{
    public List<int> correctPassword = new List<int>();
    private List<int> inputPasswordList = new List<int>();
    [SerializeField] private TMP_InputField codeDisplay;
    [SerializeField] private TMP_Text codeDisplayText;
    [SerializeField] private float resetTime = 2f;
    [SerializeField] private string successText;
    [SerializeField] public Animator DoorAnim;
    public AudioManager AudioManager;
    [Space(15f)]
    [Header("Keypad Entry Events")]
    public UnityEvent onCorrectPassword;
    public UnityEvent onIncorrectPassword;
    public DoorScript DoorScript;
    public MeshRenderer KeypadTerminal;
    public Material KeypadOn;

    public bool allowMultipleActivations = false;
    private bool hasUsedCorrectCode = false;
    public bool HasUsedCorrectCode { get { return hasUsedCorrectCode; } }

    // Entry Number Handler
    public void UserNumberEntry(int selectedNum)
    {
        AudioManager.PlayOneShot("Keypad Input");
        // Max Entry
        if(inputPasswordList.Count >= 4)
        {
            return;
        }

        inputPasswordList.Add(selectedNum);

        UpdateDisplay();

        if(inputPasswordList.Count >= 4)
        {
            CheckPassword();
        }
    }

    //Verify if Numberlist correspond or not
    private void CheckPassword()
    {
        for (int i =0; i < correctPassword.Count; i++)
        {
            if(inputPasswordList[i] != correctPassword[i])
            {
                IncorrectPassword();
                return;
            }
        }
        correctPasswordGiven();

    }

    private void correctPasswordGiven()
    {
        KeypadTerminal.material = KeypadOn;
        DoorAnim.SetTrigger("Open");
        DoorScript.DoorOff = false;
        DoorScript.DoorOn = true;
        DoorScript.DoorOnMat();
        AudioManager.Play("Sci-fi Door Opening");
        AudioManager.PlayOneShot("Keypad Granted");
        codeDisplayText.color = new Color (0, 200, 0, 255);
        if(allowMultipleActivations)
        {
            onCorrectPassword.Invoke();
            StartCoroutine(ResetKeycode());
        }
        else if (!allowMultipleActivations && !hasUsedCorrectCode)
        {
            onCorrectPassword.Invoke();
            hasUsedCorrectCode = true;
            codeDisplay.text = successText;
                       
        }
    }

    //Wrong Answer rep
    private void IncorrectPassword()
    {
        AudioManager.PlayOneShot("Keypad Denied");
        codeDisplayText.color = new Color (200, 0, 0, 255);
        onIncorrectPassword.Invoke();
        StartCoroutine(ResetKeycode());
    }

    // Update Display On Keyboard Panel
    private void UpdateDisplay()
    {
        codeDisplay.text = null;
        for(int i = 0; i < inputPasswordList.Count; i++)
        {
            codeDisplay.text += inputPasswordList[i];
        }
    }

    // Delete Last Entered number
    public void DeleteEntry()
    {
        if ( inputPasswordList.Count <= 0)
        {
            return;
        }
        AudioManager.PlayOneShot("Keypad Delete");
        var listposition = inputPasswordList.Count - 1;
        inputPasswordList.RemoveAt(listposition);

        UpdateDisplay();
    }

    // KeyCode Reset
    IEnumerator ResetKeycode()
    {
        yield return new WaitForSeconds(resetTime);

        inputPasswordList.Clear();
        codeDisplay.text = "Enter Code...";
        codeDisplayText.color = new Color (0, 0, 0, 255);
    }
}
