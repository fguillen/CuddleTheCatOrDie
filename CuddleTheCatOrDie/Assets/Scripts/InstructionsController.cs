using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionsController : MonoBehaviour
{   
    Animator animator;

    [SerializeField] float secondsToWaitForFinger2;
    float showFinger2At;

    string state;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        state = "standby";
        if(PlayerPrefs.GetInt("instructionsShown") != 1)
        {
            ShowFinger1();
        }
    }

    void Update()
    {
        if(state == "finger1Hide" && showFinger2At < Time.time)
        {
            ShowFinger2();
        }
    }

    public void ShowFinger1()
    {
        animator.SetTrigger("finger1Show");
        state = "finger1Show";
    }

    public void HideFinger1()
    {
        if(state == "finger1Show")
        {
            animator.SetTrigger("finger1Hide");
            state = "finger1Hide";
            showFinger2At = Time.time + secondsToWaitForFinger2;
        }
    }

    public void ShowFinger2()
    {
        animator.SetTrigger("finger2Show");
        state = "finger2Show";
    }

    public void HideFinger2()
    {
        if(state == "finger2Show")
        {
            animator.SetTrigger("finger2Hide");
            state = "finger2Hide";
        }
    }

    public void NotShowInstructionsAnyMore()
    {
        PlayerPrefs.SetInt("instructionsShown", 1);
    }

    public void SetShowInstructions(bool value)
    {
        if(value)
        {
            PlayerPrefs.DeleteKey("instructionsShown");
        } else 
        {
            NotShowInstructionsAnyMore();
        }
    }

    public bool IsShowInstructionsActive()
    {
        return (PlayerPrefs.GetInt("instructionsShown") != 1);
    }

}
