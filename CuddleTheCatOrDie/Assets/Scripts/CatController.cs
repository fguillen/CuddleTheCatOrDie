using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatController : MonoBehaviour
{

    [SerializeField] Sprite[] spriteTemplates;
    [SerializeField] float secondsOfCuddling;
    [SerializeField] float secondsToBeAngry;
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
        secondsToBeAngry -= Time.deltaTime;

        if(state == "idle" && secondsToBeAngry <= 0)
        {
            GetAngry();
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
        ObjectsInstances.instance.handsController.Dead();
        Destroy(this.gameObject);
    }

    void RandomSprite()
    {
        Sprite sprite = spriteTemplates[Random.Range(0, spriteTemplates.Length)];

        GetComponent<SpriteRenderer>().sprite = sprite;
    }

    public void BeingCuddled()
    {
        print("Being Cuddled");

        if(state == "idle")
        {
            state = "cuddling";
            animator.SetBool("cuddling", true);
            idleSound.Stop();
            cuddlingSound.Play();
        }

        secondsOfCuddling -= Time.deltaTime;
        if(secondsOfCuddling <= 0)
        {
            ObjectsInstances.instance.handsController.CatHappy(this.gameObject);
            IsHappy();
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
