using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCanvasController : MonoBehaviour
{
    Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void ShowCredits()
    {
        animator.SetTrigger("showCredits");
    }

    public void HideCredits()
    {
        animator.SetTrigger("hideCredits");
    }

    public void ShowSettings()
    {
        animator.SetTrigger("showSettings");
    }

    public void HideSettings()
    {
        animator.SetTrigger("hideSettings");
    }

    public void ShowHigscores()
    {
        animator.SetTrigger("showHigscores");
    }

    public void HideHigscores()
    {
        animator.SetTrigger("hideHigscores");
    }
}
