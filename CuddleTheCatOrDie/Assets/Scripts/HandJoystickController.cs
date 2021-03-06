﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandJoystickController : MonoBehaviour
{
    [SerializeField] Joystick joystick;
    [SerializeField] float speed;

    Rigidbody2D theRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        theRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(ObjectsInstances.instance.handController.IsIdle())
        {
            float horizontalMove = joystick.Horizontal;
            float verticalMove = joystick.Vertical;

            Vector2 direction = new Vector2(horizontalMove, verticalMove);
            
            theRigidbody.velocity = direction * speed;

            if(direction != Vector2.zero)
            {
                ObjectsInstances.instance.instructionsController.HideFinger1();
            }
        } else 
        {
            theRigidbody.velocity = Vector3.zero;
        }
    }
}
