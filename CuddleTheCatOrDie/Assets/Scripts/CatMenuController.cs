using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatMenuController : MonoBehaviour
{
    Rigidbody2D rb;
    string state;

    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        state = "grounded";
    }
    void Update()
    {
        if(state == "grounded")
        {
            Jump();
        }
    }

    void Jump()
    {
        float energy = Random.Range(200, 300);
        rb.AddForce(transform.up * energy, ForceMode2D.Impulse);
        state = "jumping";
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("MenuGround"))
        {
            state = "grounded";
            rb.velocity = Vector3.zero;
        }
    }
}
