using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    // Start is called before the first frame update
    int score;

    void Start()
    {
        score = 0;
    }
    
    public void IncreaseScore()
    {
        score ++;
        ObjectsInstances.instance.canvasController.SetScore(score);
    }

    public int GetScore()
    {
        return score;
    }
}
