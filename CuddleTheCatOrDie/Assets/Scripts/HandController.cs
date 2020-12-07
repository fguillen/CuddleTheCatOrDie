using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class HandController : MonoBehaviour
{
    [SerializeField] Transform[] limits;
    [SerializeField] float speed;
    [SerializeField] string state;
    [SerializeField] AudioSource cuddlingSound;
    [SerializeField] LayerMask uiLayerMask;

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
            // MoveTowardsCursor();
        }

        if(state == "cuddling")
        {
            SetPositionOnCursor();
            Cuddling();
        }

        if(state == "idle" && Input.GetMouseButtonDown(0))
        {
            if(!TouchingJoystick())
            {
                StartCuddling();
            }
        }

        if(state == "cuddling" && Input.GetMouseButtonUp(0))
        {
            Idle();
        }

        StayIntoTheLimits();
    }

    void SetPositionOnCursor()
    {
        Vector2 screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);

        transform.position = worldPosition;
    }

    void MoveTowardsCursor()
    {
        Vector2 screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);

        // transform.position = new Vector3(worldPosition.x, worldPosition.y, transform.position.z);

        transform.position = Vector3.MoveTowards(transform.position, worldPosition, speed * Time.deltaTime);
    }

    void StayIntoTheLimits()
    {
        if(transform.position.x > maxX) transform.position = new Vector3(maxX, transform.position.y, transform.position.z);
        if(transform.position.x < minX) transform.position = new Vector3(minX, transform.position.y, transform.position.z);
        if(transform.position.y > maxY) transform.position = new Vector3(transform.position.x, maxY, transform.position.z);
        if(transform.position.y < minY) transform.position = new Vector3(transform.position.x, minY, transform.position.z);
    }

    void StartCuddling()
    {
        state = "cuddling";
        animator.SetBool("cuddling", true);
        cuddlingSound.Play();
        StopCameraFollow();
    }

    void Cuddling()
    {
        if(catOnTheSpotlight)
        {
            catOnTheSpotlight.GetComponent<CatController>().BeingCuddled();
        }
    }

    void Idle()
    {
        state = "idle";
        animator.SetBool("cuddling", false);
        StartCameraFollow();
        if(catOnTheSpotlight)
        {
            catOnTheSpotlight.GetComponent<CatController>().StopCuddling();
        }

        cuddlingSound.Stop();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Cat"))
        {
            catOnTheSpotlight = other.gameObject;
        }    
    }

    public void Dead()
    {
        state = "dead";
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject == catOnTheSpotlight)
        {
            catOnTheSpotlight = null;
        }
    }

    public void CatHappy(GameObject cat)
    {
        if(cat == catOnTheSpotlight)
        {
            catOnTheSpotlight = null;
        }
    }

    void StopCameraFollow()
    {
        ObjectsInstances.instance.virtualCamera.m_Follow = null;
    }

    void StartCameraFollow()
    {
        ObjectsInstances.instance.virtualCamera.m_Follow = ObjectsInstances.instance.handController.gameObject.transform;
    }

    bool TouchingJoystick()
    {
        // RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), -Vector2.up, 100f, uiLayerMask);
        Collider2D hit = Physics2D.OverlapPoint(Input.mousePosition, uiLayerMask);

        if(hit)
        {
            return true;
        } else {
            return false;
        }
    }
}
 