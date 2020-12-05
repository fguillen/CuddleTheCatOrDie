using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class HandsController : MonoBehaviour
{
    [SerializeField] Transform[] limits;
    [SerializeField] float speed;
    [SerializeField] string state;

    float minX;
    float maxX;
    float minY;
    float maxY;

    Animator animator;
    GameObject catOnTheSpotlight;


    // Start is called before the first frame update
    void Start()
    {
        minX = limits.Min(e => e.position.x);
        maxX = limits.Max(e => e.position.x);
        minY = limits.Min(e => e.position.y);
        maxY = limits.Max(e => e.position.y);

        animator = GetComponent<Animator>();

        state = "idle";
    }

    void Update()
    {
        if(state == "idle")
        {
            MoveTowardsCursor();
        }

        if(state == "cuddling")
        {
            Cuddling();
        }

        if(Input.GetMouseButtonDown(0))
        {
            StartCuddling();
        }

        if(Input.GetMouseButtonUp(0))
        {
            Idle();
        }
    }

    void MoveTowardsCursor()
    {
        Vector2 screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);

        // transform.position = new Vector3(worldPosition.x, worldPosition.y, transform.position.z);

        transform.position = Vector3.MoveTowards(transform.position, worldPosition, speed * Time.deltaTime);

        if(transform.position.x > maxX) transform.position = new Vector3(maxX, transform.position.y, transform.position.z);
        if(transform.position.x < minX) transform.position = new Vector3(minX, transform.position.y, transform.position.z);
        if(transform.position.y > maxY) transform.position = new Vector3(transform.position.x, maxY, transform.position.z);
        if(transform.position.y < minY) transform.position = new Vector3(transform.position.x, minY, transform.position.z);
    }

    void StartCuddling()
    {
        state = "cuddling";
        animator.SetBool("cuddling", true);
    }

    void Cuddling()
    {
        print("Cuddling 1");

        if(catOnTheSpotlight)
        {
            print("Cuddling 2");
            catOnTheSpotlight.GetComponent<CatController>().BeingCuddled());
        }
    }

    void Idle()
    {
        state = "idle";
        animator.SetBool("cuddling", false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        print("Collision Enter: " + other.tag);

        if(other.CompareTag("Cat"))
        {
            catOnTheSpotlight = other.gameObject;
        }    
    }

    void OnTriggerExit2D(Collider2D other)
    {
        print("Collision Exit: " + other.tag);
        
        if(other.gameObject == catOnTheSpotlight)
        {
            catOnTheSpotlight = null;
        }
    }

    public void CatHappy(cat)
    {
        if(cat = catOnTheSpotLight)
        {
            catOnTheSpotlight = null;s
        }
    }
}
