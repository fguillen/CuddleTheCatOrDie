﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatController : MonoBehaviour
{

    [SerializeField] Sprite[] spriteTemplates;
    [SerializeField] float secondsOfCuddling;
    [SerializeField] float secondsToBeAngry;
    float secondsToBeAngryLeft;
    [SerializeField] string state;
    [SerializeField] AudioSource idleSound;
    [SerializeField] AudioSource cuddlingSound;
    [SerializeField] AudioSource angrySound;

    Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        RandomSprite();
        state = "idle";
        animator = GetComponent<Animator>();
        idleSound.Play();
        secondsToBeAngryLeft = secondsToBeAngry; 
    }

    // Update is called once per frame
    void Update()
    {
        if(state == "idle")
        {
            GettingAngry();
        }
    }

    void GettingAngry()
    {
        secondsToBeAngryLeft -= Time.deltaTime;

        if(state == "idle" && secondsToBeAngryLeft <= 0)
        {
            GetAngry();
        }

        if(ObjectsInstances.instance.counterController.IsIdle() && secondsToBeAngryLeft <= 3)
        {
            ObjectsInstances.instance.counterController.StartCountDown();
        }
    }

    void GetAngry()
    {
        state = "angry";
        idleSound.Stop();
        angrySound.Play();
        cuddlingSound.Stop();
        animator.SetBool("angry", true);
    }

    public void Explosion()
    {
        ObjectsInstances.instance.screensController.DeadScreen();
        ObjectsInstances.instance.handController.Dead();
        Destroy(this.gameObject);
    }

    void RandomSprite()
    {
        Sprite sprite = spriteTemplates[Random.Range(0, spriteTemplates.Length)];

        GetComponent<SpriteRenderer>().sprite = sprite;
    }

    public void BeingCuddled()
    {
        if(state == "idle")
        {
            state = "cuddling";
            animator.SetBool("cuddling", true);
            idleSound.Stop();
            cuddlingSound.Play();
            secondsToBeAngryLeft = secondsToBeAngry; 
        }

        if(state != "angry") 
        {
            if(!ObjectsInstances.instance.counterController.IsIdle())
            {
                ObjectsInstances.instance.counterController.Idle();
            }

            secondsOfCuddling -= Time.deltaTime;
            if(secondsOfCuddling <= 0)
            {
                ObjectsInstances.instance.handController.CatHappy(this.gameObject);
                IsHappy();
            }
        }
    }

    public void StopCuddling()
    {
        state = "idle";
        animator.SetBool("cuddling", false);
        cuddlingSound.Stop();
        idleSound.Play();
    }

    void IsHappy()
    {
        ObjectsInstances.instance.scoreController.IncreaseScore();
        ObjectsInstances.instance.catsController.SpawnCat();
        cuddlingSound.Stop();
        Destroy(this.gameObject);
    }


}
