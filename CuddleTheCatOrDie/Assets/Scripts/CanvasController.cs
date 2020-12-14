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
        print("ShowHighscores");
        animator.SetTrigger("showHighscores");
    }

    public void HideHighscores()
    {
        animator.SetTrigger("hideHighscores");
    }

    public void ShowPause()
    {
        print("ShowPause");
        animator.SetTrigger("showPause");
        Time.timeScale = 0f;
        ObjectsInstances.instance.handController.Pause();
    }

    public void HidePause()
    {
        animator.SetTrigger("hidePause");
        Time.timeScale = 1f;
        ObjectsInstances.instance.handController.Idle();
    }

    public void QuitToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
