using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterController : MonoBehaviour
{
    [SerializeField] AudioSource beepSound;

    void PlayBeep()
    {
        beepSound.Play();
    }
}
