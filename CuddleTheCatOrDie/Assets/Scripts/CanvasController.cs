using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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

    public void ShowHighscores()
    {
        animator.SetTrigger("showHighscores");
    }

    public void HideHighscores()
    {
        animator.SetTrigger("hideHighscores");
    }

    public void ShowPause()
    {
        animator.SetTrigger("showPause");
    }

    public void HidePause()
    {
        animator.SetTrigger("hidePause");
    }

    public void QuitToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
