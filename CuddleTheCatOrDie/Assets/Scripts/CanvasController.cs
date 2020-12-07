using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CanvasController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;

    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
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
