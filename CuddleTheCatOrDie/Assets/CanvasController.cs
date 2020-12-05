using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CanvasController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] GameObject arrow;

    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        OrientArrow();    
    }

    void OrientArrow()
    {
        // if(ObjectsInstances.instance.catsController.GetActiveCat())
        // {
        //     Vector2 catPosition = Camera.main.WorldToScreenPoint(ObjectsInstances.instance.catsController.GetActiveCat().transform.position);
        //     arrow.transform.right = catPosition;
        // }

        Vector2 catPosition = Camera.main.WorldToScreenPoint(ObjectsInstances.instance.handsController.gameObject.transform.position);
        arrow.transform.right = catPosition;
    }

    public void SetScore(int score)
    {
        scoreText.text = score + " cats cuddled";
        animator.SetTrigger("score");
    }

    public void DeadScreen()
    {
        animator.SetTrigger("deadScreen");
    }
}
