using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterController : MonoBehaviour
{
    [SerializeField] AudioSource beepSound;
    Animator animator;
    string state;

    void Start()
    {
        animator = GetComponent<Animator>();
        state = "idle";
    }
    void PlayBeep()
    {
        beepSound.Play();
    }

    public void StartCountDown()
    {
        state = "countDown";
        animator.SetBool("countDown", true);
    }

    public void Idle()
    {
        state = "idle";
        animator.SetBool("countDown", false);
    }

    public bool IsIdle()
    {
        return state == "idle";
    }
}
