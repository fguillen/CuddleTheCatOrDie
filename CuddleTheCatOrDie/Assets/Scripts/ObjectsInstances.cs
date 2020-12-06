using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsInstances : MonoBehaviour
{
    [SerializeField] public HandsController handsController;
    [SerializeField] public CatsController catsController;
    [SerializeField] public ScreensController screensController;
    [SerializeField] public ScoreController scoreController;
    [SerializeField] public CanvasController canvasController;
    [SerializeField] public CounterController counterController;

    public static ObjectsInstances instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
