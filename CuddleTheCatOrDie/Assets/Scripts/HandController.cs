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
    [SerializeField] List<int> touchesOnUI = new List<int>();

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
        StoreUITouches();

        if(state == "idle" && Input.touchCount > 0)
        {
            foreach (var touch in Input.touches)
            {
                if(!IsIntoTouchesOnUI(touch))
                {
                    StartCuddling();
                }    
            }
            
        }

        if(state == "cuddling" && !IsThereAnyTouchOutOfUI())
        {
            Idle();
        }

        if(state == "cuddling")
        {
            SetPositionOnCursor();
            Cuddling();
        }

        StayIntoTheLimits();
    }

    void StoreUITouches()
    {
        foreach (var touch in Input.touches)
        {
            if(touch.phase == TouchPhase.Began && IsTouchingUI(touch.position))
            {
                print("Adding touch to touchesOnUI: " + touch);
                touchesOnUI.Add(touch.fingerId);
            }

            if(touch.phase == TouchPhase.Ended && IsIntoTouchesOnUI(touch))
            {
                print("Removing touch to touchesOnUI: " + touch);
                touchesOnUI.Remove(touch.fingerId);
            }
        }
    }

    bool IsIntoTouchesOnUI(Touch touch)
    {
        return touchesOnUI.Contains(touch.fingerId);
    }

    void SetPositionOnCursor()
    {
        Vector2 screenPosition = GetLastMousePointerPositionNotTouchingUI();

        if(screenPosition == Vector2.zero)
        {
            print("GetLastMousePointerPositionNotTouchingUI returns zero");
        }
        
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);

        transform.position = worldPosition;
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
            ObjectsInstances.instance.instructionsController.HideFinger2();
        }
    }

    public void Idle()
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
        animator.SetBool("cuddling", false);
        int score = ObjectsInstances.instance.scoreController.GetScore();
        ObjectsInstances.instance.highscoresController.SetScore(score);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject == catOnTheSpotlight)
        {
            catOnTheSpotlight.GetComponent<CatController>().StopCuddling();
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
        ObjectsInstances.instance.cameraController.StopFollow();
    }

    void StartCameraFollow()
    {
        ObjectsInstances.instance.cameraController.SetFollow(ObjectsInstances.instance.handController.gameObject);
    }

    bool IsTouchingUI(Vector3 position)
    {
        // RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), -Vector2.up, 100f, uiLayerMask);
        Collider2D hit = Physics2D.OverlapPoint(position, uiLayerMask);

        if(hit)
        {
            return true;
        } else {
            return false;
        }
    }

    public float GetSpeed()
    {
        return speed;
    }

    public bool IsIdle()
    {
        return state == "idle";
    }

    public void Pause()
    {
        state = "paused";
    }

    bool IsThereAnyTouchOutOfUI()
    {
        if(GetLastMousePointerPositionNotTouchingUI() != Vector2.zero)
        {
            return true;
        } else
        {
            return false;    
        }
    }

    Vector2 GetLastMousePointerPositionNotTouchingUI()
    {
        Vector2 result = Vector2.zero;

        foreach (var touch in Input.touches)
        {
            if(touch.phase != TouchPhase.Ended && !IsIntoTouchesOnUI(touch))
            {
                result = touch.position;
            }
        } 

        return result;
    }
}
 