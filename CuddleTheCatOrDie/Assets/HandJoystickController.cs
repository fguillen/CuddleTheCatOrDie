using System.Collections;
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
        float horizontalMove = joystick.Horizontal;
        float verticalMove = joystick.Vertical;

        Vector2 direction = new Vector2(horizontalMove, verticalMove);
        
        theRigidbody.velocity = direction * speed;
    }
}
