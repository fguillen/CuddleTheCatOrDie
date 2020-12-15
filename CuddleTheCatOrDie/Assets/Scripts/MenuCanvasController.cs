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

    public void ShowHighscores()
    {
        animator.SetTrigger("showHighscores");
    }

    public void HideHighscores()
    {
        animator.SetTrigger("hideHighscores");
    }

    public void ShowSettings()
    {
        animator.SetTrigger("showSettings");
    }

    public void HideSettings()
    {
        animator.SetTrigger("hideSettings");
    }
}
